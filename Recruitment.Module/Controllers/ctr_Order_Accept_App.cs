using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class ctr_Order_Accept_App : ViewController
    {
        public ctr_Order_Accept_App()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            View.SelectionChanged += View_SelectionChanged;
            // Perform various tasks depending on the target View.
        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
            ctr_Order_Accept_App ctr = Frame.GetController<ctr_Order_Accept_App>();
            if (View.SelectedObjects.Count == 0 || ctr == null)
                return;

            IObjectSpace objSpc = Application.CreateObjectSpace();
            
            bool Active = true;
            
            System.Collections.ArrayList lst = (System.Collections.ArrayList)View.SelectedObjects;
            foreach (rec_Employer_Order_Detail_Suggest_Applicat item in lst)
            {
                if (item.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id == null)
                {
                    Active = false;
                    break;
                }
                if (item.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id == Core.Typez.enum_rec_Employer_Order_Status.InProgress)
                {
                    Active = false;
                    break;
                }
            }
            ctr.Active["Deactivation in code"] = Active;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            //View.SelectionChanged -= View_SelectionChanged;
        }
        private void action_Order_Accept_App_Accept_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objSpc = Application.CreateObjectSpace();
            int ObjectToSave = 0;
            rec_Applicant_Status accept_Status = objSpc.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", (int)Core.Typez.enum_rec_Applicant_Status.Ready));
            rec_Applicant_Status suggest_Status = objSpc.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", Core.Typez.enum_rec_Applicant_Status.Accepted));
            if (accept_Status == null || suggest_Status == null)
                return;

            foreach (var obj in e.SelectedObjects)
            {
                if (obj.GetType() != typeof(rec_Employer_Order_Detail_Suggest_Applicat))
                    continue;
                rec_Employer_Order_Detail_Suggest_Applicat Suggest = objSpc.GetObject<rec_Employer_Order_Detail_Suggest_Applicat>((rec_Employer_Order_Detail_Suggest_Applicat)obj);
                //check if exists
                IList< rec_Employer_Order_Detail_Accept_Applicat> exists = objSpc.GetObjects<rec_Employer_Order_Detail_Accept_Applicat>(new BinaryOperator("rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id", Suggest.rec_employer_order_detail_suggest_applicat_id));
                if (exists != null && exists.Count > 0)
                    continue;
                rec_Employer_Order_Detail_Accept_Applicat Accept = objSpc.CreateObject<rec_Employer_Order_Detail_Accept_Applicat>();
                Accept.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = Suggest;
                Accept.rec_employer_order_detail_accept_applicat_rec_applicant_status_id = accept_Status;
                ObjectToSave++;
                Suggest.rec_employer_order_detail_suggest_applicat_rec_applicant_status_id = suggest_Status;
            }
            objSpc.CommitChanges();
            View.ObjectSpace.Refresh();

        }
        private void action_Order_Accept_App_Refused_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objSpc = Application.CreateObjectSpace();
            int ObjectToSave = 0;
            rec_Applicant_Status accept_Status = objSpc.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", (int)Core.Typez.enum_rec_Applicant_Status.Ready));
            rec_Applicant_Status suggest_Status = objSpc.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", Core.Typez.enum_rec_Applicant_Status.Refused));
            if (accept_Status == null || suggest_Status == null)
                return;

            foreach (var obj in e.SelectedObjects)
            {
                if (obj.GetType() != typeof(rec_Employer_Order_Detail_Suggest_Applicat))
                    continue;
                rec_Employer_Order_Detail_Suggest_Applicat Suggest = objSpc.GetObject<rec_Employer_Order_Detail_Suggest_Applicat>((rec_Employer_Order_Detail_Suggest_Applicat)obj);
                //check if exists
                IList<rec_Employer_Order_Detail_Accept_Applicat> accepts = objSpc.GetObjects<rec_Employer_Order_Detail_Accept_Applicat>(new BinaryOperator("rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id", Suggest.rec_employer_order_detail_suggest_applicat_id));

                if (accepts != null && accepts.Count > 0)
                {
                    for (int i = 0; i < accepts.Count; i++)
                        accepts[i].Delete();
                }
                ObjectToSave++;
                Suggest.rec_employer_order_detail_suggest_applicat_rec_applicant_status_id = suggest_Status;
            }
            objSpc.CommitChanges();
            View.ObjectSpace.Refresh();
            
        }

    }
}
