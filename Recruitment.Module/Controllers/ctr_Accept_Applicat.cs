using System;
using System.Collections.Generic;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Recruitment.Module.BusinessObjects.Recruitment;

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
            acc_Option optionAdvanceRevenue = objectSpace.GetObjectByKey<acc_Option>(Core.Typez.OptionAdvanceRevenue);
            acc_Account accountAdvanceRevenue = objectSpace.GetObjectByKey<acc_Account>(Convert.ToInt32(optionAdvanceRevenue.acc_option_value));
            acc_Option optionCustomers = objectSpace.GetObjectByKey<acc_Option>(Core.Typez.OptionCustomers);
            acc_Account accountCustomers = objectSpace.GetObjectByKey<acc_Account>(Convert.ToInt32(optionCustomers.acc_option_value));
            acc_Option optionRevenueDue = objectSpace.GetObjectByKey<acc_Option>(Core.Typez.OptionRevenueDue);
            acc_Account accountRevenueDue = objectSpace.GetObjectByKey<acc_Account>(Convert.ToInt32(optionRevenueDue.acc_option_value));
            // Create Entry
            acc_Journal_Entry entry = objectSpace.CreateObject<acc_Journal_Entry>();
            entry.closed = true;
            entry.entry_date = Core.SqlOp.GetServerDateTime(ObjectSpace);
            entry.entry_text = $"{employer.account_id.account_name} - {applicant.applicant_name} - {employer.employer_company_name}";
            // Load Activities
            IList<rec_Accept_App_Activity> activities =
                objectSpace.GetObjects<rec_Accept_App_Activity>(
                    CriteriaOperator.Parse(
                        "rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = ?",
                        accepted.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                            .rec_employer_order_detail_suggest_applicat_id, BinaryOperatorType.Equal));
            // Search activities for Adv Rev and create details entry
            foreach (rec_Accept_App_Activity recAcceptAppActivity in activities)
            {
                if (recAcceptAppActivity.jour_entry_id == null)
                    continue;
                foreach (acc_Journal_Entry_Detail accJournalEntryDetail in recAcceptAppActivity.jour_entry_id.acc_Journal_Entry_Details)
                {
                    if (accJournalEntryDetail.account_id.account_id != Convert.ToInt32(optionAdvanceRevenue.acc_option_value))
                        continue;
                    // Create Advance Revenue Entry Details
                    acc_Journal_Entry_Detail detailAdvanceRevenue = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    detailAdvanceRevenue.account_id = accountAdvanceRevenue; detailAdvanceRevenue.credit = accJournalEntryDetail.debit;
                    detailAdvanceRevenue.debit = accJournalEntryDetail.credit;
                    detailAdvanceRevenue.credit_currency = accJournalEntryDetail.debit_currency;
                    detailAdvanceRevenue.debit_currency = accJournalEntryDetail.credit_currency;
                    detailAdvanceRevenue.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    detailAdvanceRevenue.entry_text = $"{accountAdvanceRevenue.account_name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    detailAdvanceRevenue.jour_entry_id = entry;
                    // Create Employer Account Entry Details
                    acc_Journal_Entry_Detail detailEmployerAccount = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    detailEmployerAccount.account_id = objectSpace.GetObject(employer.account_id);
                    detailEmployerAccount.credit = accJournalEntryDetail.credit;
                    detailEmployerAccount.debit = accJournalEntryDetail.debit;
                    detailEmployerAccount.credit_currency = accJournalEntryDetail.credit_currency;
                    detailEmployerAccount.debit_currency = accJournalEntryDetail.debit_currency;
                    detailEmployerAccount.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    detailEmployerAccount.entry_text = $"{detailEmployerAccount.account_id.Name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    detailEmployerAccount.jour_entry_id = entry;
                    // Create Revenue Due Entry Details
                    acc_Journal_Entry_Detail detailRevenueDue = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    detailRevenueDue.account_id = accountRevenueDue; detailRevenueDue.credit = accJournalEntryDetail.debit;
                    detailRevenueDue.debit = accJournalEntryDetail.credit;
                    detailRevenueDue.credit_currency = accJournalEntryDetail.debit_currency;
                    detailRevenueDue.debit_currency = accJournalEntryDetail.credit_currency;
                    detailRevenueDue.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    detailRevenueDue.entry_text = $"{detailRevenueDue.account_id.Name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    detailRevenueDue.jour_entry_id = entry;
                    // Create Customers Entry Details
                    acc_Journal_Entry_Detail detailCustomers = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    detailCustomers.account_id = accountCustomers;
                    detailCustomers.credit = accJournalEntryDetail.credit;
                    detailCustomers.debit = accJournalEntryDetail.debit;
                    detailCustomers.credit_currency = accJournalEntryDetail.credit_currency;
                    detailCustomers.debit_currency = accJournalEntryDetail.debit_currency;
                    detailCustomers.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    detailCustomers.entry_text = $"{detailCustomers.account_id.Name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    detailCustomers.jour_entry_id = entry;
                }
            }
            // Rollback if didn't find any Adv Rev            
            if (entry.acc_Journal_Entry_Details == null || entry.acc_Journal_Entry_Details.Count == 0)
            {
                objectSpace.Rollback();
                IObjectSpace objectSpace2 = Application.CreateObjectSpace();
                rec_Employer_Order_Detail_Accept_Applicat accepted2 = objectSpace2.GetObject((rec_Employer_Order_Detail_Accept_Applicat)e.SelectedObjects[0]);
                accepted2.start_activity = true;
                objectSpace2.CommitChanges();
            }
            else
                objectSpace.CommitChanges();
            
            ObjectSpace.Refresh();
        }

    }
}
