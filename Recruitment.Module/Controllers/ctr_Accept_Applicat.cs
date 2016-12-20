using System;
using System.Collections.Generic;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Xpo;
using Recruitment.Module.BusinessObjects.Recruitment;
using Recruitment.Module.Core;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_Accept_Applicat : ViewController
    {
        public ctr_Accept_Applicat()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            this.ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;
        }
        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
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
        }
        private void actionStartActivity_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //rec_Employer_Order_Detail_Accept_Applicat item = (rec_Employer_Order_Detail_Accept_Applicat)e.SelectedObjects[0];
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            rec_Employer_Order_Detail_Accept_Applicat accepted = objectSpace.GetObject((rec_Employer_Order_Detail_Accept_Applicat)e.SelectedObjects[0]);
            accepted.start_activity = true;

            rec_Employer employer =
                accepted.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                    .rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id
                    .rec_employer_order_detail_rec_employer_order_id.rec_employer_order_employer_id;
            rec_Applicant applicant =
                accepted.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                    .rec_employer_order_detail_suggest_applicat_applicant_id;
            // Load Options Accounts
            acc_Account accountAdvanceRevenue = SqlOp.GetOptionAccount(objectSpace, Typez.OptionAdvanceRevenue);
            acc_Account accountRevenueDue = SqlOp.GetOptionAccount(objectSpace, Typez.OptionRevenueDue);
            //acc_Option optionCustomers = objectSpace.GetObjectByKey<acc_Option>(Core.Typez.OptionCustomers);
            //acc_Account accountCustomers = objectSpace.GetObjectByKey<acc_Account>(Convert.ToInt32(optionCustomers.acc_option_value));
            
            // Create Entry
            //acc_Journal_Entry entry = objectSpace.CreateObject<acc_Journal_Entry>();
            //entry.closed = true;
            //entry.entry_date = 
            //entry.entry_text = $"{employer.account_id.account_name} - {applicant.applicant_name} - {employer.employer_company_name}";
            // Load Activities
            IList<rec_Accept_App_Activity> activities =
                objectSpace.GetObjects<rec_Accept_App_Activity>(
                    CriteriaOperator.Parse(
                        "rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = ?",
                        accepted.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                            .rec_employer_order_detail_suggest_applicat_id, BinaryOperatorType.Equal));
            // Search activities for Adv Rev and create details entry
            double value = 0;
            foreach (rec_Accept_App_Activity recAcceptAppActivity in activities)
            {
                if (recAcceptAppActivity.jour_entry_id == null)
                    continue;
                foreach (acc_Journal_Entry_Detail accJournalEntryDetail in recAcceptAppActivity.jour_entry_id.acc_Journal_Entry_Details)
                {
                    if (accJournalEntryDetail.account_id.account_id != Convert.ToInt32(accountAdvanceRevenue.account_id))
                        continue;
                    value += accJournalEntryDetail.credit;
                }
            }
            rec_Activity activityRevenueDue = objectSpace.FindObject<rec_Activity>(
                        CriteriaOperator.And(CriteriaOperator.Parse("activity_type_id = ?", (int)Typez.enum_rec_Activity_Type.BudgetRevenue),
                        CriteriaOperator.Parse("account_id = ?", accountRevenueDue.account_id)));
            rec_Cash cashAdvanceRevenue = objectSpace.FindObject<rec_Cash>(CriteriaOperator.Parse("account_id = ?", accountAdvanceRevenue.account_id));
            rec_Accept_App_Activity activity = objectSpace.CreateObject<rec_Accept_App_Activity>();
            activity.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id =
                accepted;
            activity.activity_date = Core.SqlOp.GetServerDateTime(ObjectSpace);
            activity.activity_id = activityRevenueDue;
            activity.cash_id = cashAdvanceRevenue;
            activity.value1 = value;
            activity.org_value = 0;
            activity.description = "Start Activity";

            // Rollback if didn't find any Adv Rev            
            if (value > 0)
            {
                objectSpace.CommitChanges();
            }
            else
            {
                objectSpace.Rollback();
                IObjectSpace objectSpace2 = Application.CreateObjectSpace();
                rec_Employer_Order_Detail_Accept_Applicat accepted2 =
                    objectSpace2.GetObject((rec_Employer_Order_Detail_Accept_Applicat)e.SelectedObjects[0]);
                accepted2.start_activity = true;
                objectSpace2.CommitChanges();
            }

            ObjectSpace.Refresh();
        }

    }
}
