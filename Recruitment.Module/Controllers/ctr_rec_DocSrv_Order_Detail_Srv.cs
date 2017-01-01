using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Recruitment.Module.BusinessObjects.Recruitment;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_rec_DocSrv_Order_Detail_Srv : ViewController
    {
        public ctr_rec_DocSrv_Order_Detail_Srv()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            //Perform various tasks depending on the target View.
            View.SelectionChanged += (sender, args) =>
            {
                ActivateControls();
            };
        }
        private void ActivateControls()
        {
            bool activeCompleted = View.SelectedObjects.Cast<rec_DocSrv_Order_Detail_Srv>().All(item => !item.is_completed);
            act_Completed.Active.SetItemValue("Active For Not Completed Service Only", activeCompleted);

            bool activePaid = View.SelectedObjects.Cast<rec_DocSrv_Order_Detail_Srv>().All(item => !item.paid);
            act_Paid.Active.SetItemValue("Active or Not Paid Service Only", activePaid);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            ActivateControls();
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        private void act_Completed_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(rec_DocSrv_Order_Detail_Srv));
            DateTime serviceDateTime = Core.SqlOp.GetServerDateTime(objectSpace);
            foreach (rec_DocSrv_Order_Detail_Srv item in e.SelectedObjects)
            {
                rec_DocSrv_Order_Detail_Srv srv = objectSpace.GetObject(item);
                srv.is_completed = true;
                srv.completion_date = serviceDateTime;
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
        private void act_Paid_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            DateTime serviceDateTime = Core.SqlOp.GetServerDateTime(objectSpace);
            acc_Account account = Core.SqlOp.GetOptionAccount(objectSpace, Core.Typez.OptionRevenueDue);
            acc_Account cash = Core.SqlOp.GetOptionAccount(objectSpace, Core.Typez.OptionCash);

            
            foreach (rec_DocSrv_Order_Detail_Srv item in e.SelectedObjects)
            {
                rec_DocSrv_Order_Detail_Srv srv = objectSpace.GetObject(item);
                srv.paid = true;
                //Create Entry
                acc_Journal_Entry paidEntry = objectSpace.CreateObject<acc_Journal_Entry>();
                paidEntry.entry_date = serviceDateTime;
                paidEntry.closed = true;
                paidEntry.entry_text = $"Document Service [Paid] - {srv.docsrv_type_id.docsrv_type_name} - {srv.docsrv_order_detail.doc_owner} - {srv.notes}";
                srv.jour_entry_id_Paid = paidEntry;
                //Create Entry Detail For Paid Account
                acc_Journal_Entry_Detail paidDetailAccount = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                paidDetailAccount.jour_entry_id = paidEntry;
                paidDetailAccount.account_id = account;
                paidDetailAccount.debit = 0;
                paidDetailAccount.credit = srv.price;
                paidDetailAccount.entry_text = paidEntry.entry_text;
                paidDetailAccount.debit_currency = 0;
                paidDetailAccount.credit_currency = 0;
                //Create Entry Detail For Cash Account
                acc_Journal_Entry_Detail cashDetailAccount = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                cashDetailAccount.jour_entry_id = paidEntry;
                cashDetailAccount.account_id = cash;
                cashDetailAccount.debit = srv.price;
                cashDetailAccount.credit = 0;
                cashDetailAccount.entry_text = paidEntry.entry_text;
                cashDetailAccount.debit_currency = 0;
                cashDetailAccount.credit_currency = 0;
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
    }
}
