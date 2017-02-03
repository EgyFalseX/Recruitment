using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Accounting")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Employee Activity")]
    [DevExpress.Persistent.Base.ImageName("rec_Employee_Activity")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("employee_name")]
    [Appearance("rec_Employee_jour_entry_id_Must_Disabled", TargetItems = "jour_entry_id", Criteria = "true = true", Enabled = false, Priority = 1)]
    [Appearance("rec_Employee_activity_id_Must_Disabled_For_Edit", TargetItems = "activity_id", Criteria = "jour_entry_id != null", Enabled = false, Priority = 2)]
    [RuleCriteria("rec_Employee_period_id_vld_Create", DefaultContexts.Save, "jour_entry_id.period_id.closed != true", "Can't create item in closed period", SkipNullOrEmptyValues = false)]
    [RuleCriteria("rec_Employee_period_id_vld_Delete", DefaultContexts.Delete, "jour_entry_id.period_id.closed != true", "Can't delete item in closed period", SkipNullOrEmptyValues = false)]
    public partial class rec_Employee_Activity
    {
        public rec_Employee_Activity(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        public string CustomName => $"{activity_id?.activity_name} - {activity_date.ToShortDateString()}";
        //Audit Trail
        private XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> auditTrail;
        public XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> AuditTrail
        {
            get
            {
                if (auditTrail == null)
                {
                    auditTrail = DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return auditTrail;
            }
        }

        private void CreateEntry()
        {
            string employeeName = employee_id.employee_name;

            string entryText = $"{activity_id.description} - {employeeName}";

            acc_Journal_Entry entry = new acc_Journal_Entry(Session)
            {
                entry_date = activity_date,
                closed = true,
                entry_text = activity_id.description == null
                    ? string.Empty
                    : entryText,
                voucher_no = voucher_no ?? string.Empty
            };
            if (entry.period_id.closed)
                throw new Exception("Can't create item in closed period");
            jour_entry_id = entry;

            acc_Journal_Entry_Detail detailAct = new acc_Journal_Entry_Detail(Session)
            {
                account_id = activity_id.account_id,
                credit = activity_id.credit ? value1 : 0f,
                debit = activity_id.debit ? value1 : 0f,
                credit_currency = activity_id.credit ? org_value : 0f,
                debit_currency = activity_id.debit ? org_value : 0f,
                currency_id = currency_id,
                entry_text = entryText,
                jour_entry_id = entry
            };
            acc_Journal_Entry_Detail detailCash = new acc_Journal_Entry_Detail(Session)
            {
                account_id = cash_id.account_id,
                credit = !activity_id.credit ? value1 : 0f,
                debit = !activity_id.debit ? value1 : 0f,
                credit_currency = !activity_id.credit ? org_value : 0f,
                debit_currency = !activity_id.debit ? org_value : 0f,
                currency_id = currency_id,
                entry_text = entryText,
                jour_entry_id = entry
            };
        }
        private void EditEntry()
        {
            string employeeName = employee_id.employee_name;

            string entryText = $"{activity_id.description} - {employeeName}";
            //Edit Entry
            acc_Journal_Entry entry = Session.GetObjectByKey<acc_Journal_Entry>(jour_entry_id.jour_entry_id);
            entry.entry_date = activity_date;
            entry.closed = true;
            entry.entry_text = activity_id.description == null
                ? string.Empty
                : entryText;
            entry.voucher_no = voucher_no ?? string.Empty;
            //Edit Entry Details
            acc_Journal_Entry_Detail detailsAccount = Session.FindObject<acc_Journal_Entry_Detail>(CriteriaOperator.And(CriteriaOperator.Parse("jour_entry_id = ?", jour_entry_id.jour_entry_id), CriteriaOperator.Parse("account_id = ?", activity_id.account_id)));
            if (detailsAccount != null)
            {
                detailsAccount.account_id = activity_id.account_id;
                detailsAccount.credit = activity_id.credit ? value1 : 0f;
                detailsAccount.debit = activity_id.debit ? value1 : 0f;
                detailsAccount.credit_currency = activity_id.credit ? org_value : 0f;
                detailsAccount.debit_currency = activity_id.debit ? org_value : 0f;
                detailsAccount.currency_id = currency_id;
                detailsAccount.entry_text = entryText;
            }
            acc_Journal_Entry_Detail detailsCash = Session.FindObject<acc_Journal_Entry_Detail>(CriteriaOperator.And(CriteriaOperator.Parse("jour_entry_id = ?", jour_entry_id.jour_entry_id), CriteriaOperator.Parse("account_id = ?", cash_id.account_id)));
            if (detailsCash != null)
            {
                detailsCash.account_id = cash_id.account_id;
                detailsCash.credit = !activity_id.credit ? value1 : 0f;
                detailsCash.debit = !activity_id.debit ? value1 : 0f;
                detailsCash.credit_currency = !activity_id.credit ? org_value : 0f;
                detailsCash.debit_currency = !activity_id.debit ? org_value : 0f;
                detailsCash.currency_id = currency_id;
                detailsCash.entry_text = entryText;
            }
        }
        protected override void OnSaving()
        {
            if (IsDeleted)
                return;
            if (jour_entry_id == null)// Add
                CreateEntry();
            else// Edit
                EditEntry();
            base.OnSaving();
        }
        protected override void OnSaved()
        {
            base.OnSaved();
        }
        protected override void OnDeleting()
        {
            if (jour_entry_id == null)
                return;
            acc_Journal_Entry entry = Session.GetObjectByKey<acc_Journal_Entry>(jour_entry_id.jour_entry_id);
            entry.Delete();
            Session.Delete(entry);
            base.OnDeleting();
        }
        //[NonPersistent]
        //public double NetValue
        //{
        //    get { return fcash_id; }
        //}
    }

}
