﻿using System;
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
            acc_Journal_Entry entry = objectSpace.CreateObject<acc_Journal_Entry>();
            entry.closed = true;
            entry.entry_date = Core.SqlOp.GetServerDateTime(ObjectSpace);
            entry.entry_text = $"Start Activity - {applicant.applicant_name} - {employer.employer_company_name}";
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
                    if (accJournalEntryDetail.account_id.account_id != Convert.ToInt32(accountAdvanceRevenue.account_id))
                        continue;
                    // Create Advance Revenue Entry Details
                    acc_Journal_Entry_Detail detailAdvanceRevenue = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    detailAdvanceRevenue.account_id = accountAdvanceRevenue;
                    detailAdvanceRevenue.credit = accJournalEntryDetail.debit;
                    detailAdvanceRevenue.debit = accJournalEntryDetail.credit;
                    detailAdvanceRevenue.credit_currency = accJournalEntryDetail.debit_currency;
                    detailAdvanceRevenue.debit_currency = accJournalEntryDetail.credit_currency;
                    detailAdvanceRevenue.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    detailAdvanceRevenue.entry_text = $"{accountAdvanceRevenue.account_name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    detailAdvanceRevenue.jour_entry_id = entry;
                    // Create Revenue Due Entry Details
                    acc_Journal_Entry_Detail detailaccountRevenueDue = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    detailaccountRevenueDue.account_id = objectSpace.GetObject(accountRevenueDue);
                    detailaccountRevenueDue.credit = accJournalEntryDetail.credit;
                    detailaccountRevenueDue.debit = accJournalEntryDetail.debit;
                    detailaccountRevenueDue.credit_currency = accJournalEntryDetail.credit_currency;
                    detailaccountRevenueDue.debit_currency = accJournalEntryDetail.debit_currency;
                    detailaccountRevenueDue.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    detailaccountRevenueDue.entry_text = $"{detailaccountRevenueDue.account_id.Name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    detailaccountRevenueDue.jour_entry_id = entry;
                    //// Create Revenue Due Entry Details
                    //acc_Journal_Entry_Detail detailRevenueDue = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    //detailRevenueDue.account_id = accountRevenueDue;
                    //detailRevenueDue.credit = accJournalEntryDetail.credit;
                    //detailRevenueDue.debit = accJournalEntryDetail.debit;
                    //detailRevenueDue.credit_currency = accJournalEntryDetail.credit_currency;
                    //detailRevenueDue.debit_currency = accJournalEntryDetail.debit_currency;
                    //detailRevenueDue.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    //detailRevenueDue.entry_text = $"{detailRevenueDue.account_id.Name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    //detailRevenueDue.jour_entry_id = entry;
                    //// Create Customers Entry Details
                    //acc_Journal_Entry_Detail detailCustomers = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                    //detailCustomers.account_id = accountCustomers;
                    //detailCustomers.credit = accJournalEntryDetail.debit;
                    //detailCustomers.debit = accJournalEntryDetail.credit;
                    //detailCustomers.credit_currency = accJournalEntryDetail.debit_currency;
                    //detailCustomers.debit_currency = accJournalEntryDetail.credit_currency;
                    //detailCustomers.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
                    //detailCustomers.entry_text = $"{detailCustomers.account_id.Name} - {applicant.applicant_name} - {employer.employer_company_name}";
                    //detailCustomers.jour_entry_id = entry;
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
