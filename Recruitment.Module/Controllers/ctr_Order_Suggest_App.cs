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
using Recruitment.Module.Core;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_Order_Suggest_App : ViewController
    {
        public ctr_Order_Suggest_App()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            View.SelectionChanged += View_SelectionChanged;
            // Perform various tasks depending on the target View.

            var list = ((IList<Typez.enum_rec_Suggest_Applicant_Status>)Enum.GetValues(typeof(Typez.enum_rec_Suggest_Applicant_Status)))
                .Select(t => new ChoiceActionItem(t.ToString(), t)).ToArray();

            action_SuggestedStatus.Items.Clear();
            action_SuggestedStatus.Items.AddRange(list);
        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
            ctr_Order_Suggest_App ctr = Frame.GetController<ctr_Order_Suggest_App>();
            if (View.SelectedObjects.Count == 0 || ctr == null)
            {
                action_SuggestedStatus.Active.SetItemValue("No item selected", false);
                return;
            }
            IObjectSpace objSpc = Application.CreateObjectSpace();
            bool Active = true;
            
            //System.Collections.ArrayList lst = (System.Collections.ArrayList)View.SelectedObjects;
            foreach (rec_Employer_Order_Detail_Suggest_Applicat item in View.SelectedObjects)
            {
                if (item.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id == null)
                {
                    Active = false;
                    break;
                }
                if (item.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id != Core.Typez.enum_rec_Employer_Order_Status.InProgress)
                {
                    Active = false;
                    break;}
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

        private void action_SuggestedStatus_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var selectedItems = e.SelectedObjects;
            Typez.enum_rec_Suggest_Applicant_Status selectedPriv = (Typez.enum_rec_Suggest_Applicant_Status)e.SelectedChoiceActionItem.Data;
            if (selectedItems.Count == 0)
                return;
            IObjectSpace objectSpace = Application.CreateObjectSpace();

            rec_Applicant_Status acceptStatus = objectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", (int)Core.Typez.enum_rec_Suggest_Applicant_Status.Accepted));
            rec_Applicant_Status refusedStatus = objectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", (int)Core.Typez.enum_rec_Suggest_Applicant_Status.Refused));
            rec_Applicant_Status waitingStatus = objectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", (int)Core.Typez.enum_rec_Suggest_Applicant_Status.WaitingConfirmation));


            foreach (object item in selectedItems)
            {
                if (item is rec_Employer_Order_Detail_Suggest_Applicat == false)
                    continue;
                var suggested = objectSpace.GetObject((rec_Employer_Order_Detail_Suggest_Applicat)item);
                if (selectedPriv == suggested.rec_employer_order_detail_suggest_applicat_rec_applicant_status_id)
                    return;

                switch (selectedPriv)
                {
                    case Typez.enum_rec_Suggest_Applicant_Status.Accepted:
                        IList<rec_Employer_Order_Detail_Accept_Applicat> exists = objectSpace.GetObjects<rec_Employer_Order_Detail_Accept_Applicat>(new BinaryOperator("rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id", suggested.rec_employer_order_detail_suggest_applicat_id));
                        if (exists != null && exists.Count > 0)
                            continue;
                        rec_Employer_Order_Detail_Accept_Applicat accept = objectSpace.CreateObject<rec_Employer_Order_Detail_Accept_Applicat>();
                        accept.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = suggested;
                        accept.rec_employer_order_detail_accept_applicat_rec_applicant_status_id = acceptStatus;

                        break;
                    case Typez.enum_rec_Suggest_Applicant_Status.Refused:
                    case Typez.enum_rec_Suggest_Applicant_Status.WaitingConfirmation:
                        IList<rec_Employer_Order_Detail_Accept_Applicat> accepts = objectSpace.GetObjects<rec_Employer_Order_Detail_Accept_Applicat>(new BinaryOperator("rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id", suggested.rec_employer_order_detail_suggest_applicat_id));
                        if (accepts != null && accepts.Count > 0)
                        {
                            for (int i = 0; i < accepts.Count; i++)
                                accepts[i].Delete();
                        }
                        break;
                }
                suggested.rec_employer_order_detail_suggest_applicat_rec_applicant_status_id = selectedPriv;
            }
            objectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }
    }
}
