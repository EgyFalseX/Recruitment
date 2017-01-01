using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Document Service")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Document Service")]
    [DevExpress.Persistent.Base.ImageName("rec_DocSrv_Order_Detail_Srv")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("docsrv_type_id")]
    public partial class rec_DocSrv_Order_Detail_Srv
    {
        public rec_DocSrv_Order_Detail_Srv(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction();
            fpaid = false;
        }
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
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (IsLoading || oldValue == newValue || (propertyName != "docsrv_type_id")) return;
            if (docsrv_type_id != null)
                fprice = docsrv_type_id.docsrv_type_price;
        }
        protected override void OnSaving()
        {
            if (IsDeleted)
                return;
            if (jour_entry_id == null)// Add
                CreateEntry();
            base.OnSaving();
        }
        private void CreateEntry()
        {
            DateTime serverDatetime = Core.SqlOp.GetServerDateTime(Session);
            string ownerName = this.docsrv_order_detail.doc_owner;
            acc_Account account = Core.SqlOp.GetOptionAccount(Session, Core.Typez.OptionDocumentRevenue);
            acc_Account cash = Core.SqlOp.GetOptionAccount(Session, Core.Typez.OptionRevenueDue);
            string entryText = $"Document Service - {docsrv_type_id.docsrv_type_name} - {ownerName} - {notes}";

            acc_Journal_Entry entry = new acc_Journal_Entry(Session)
            {
                entry_date = serverDatetime,
                closed = true,
                entry_text = entryText,
                //voucher_no = string.Empty,
            };
            if (entry.period_id.closed)
                throw new Exception("Can't create item in closed period");
            jour_entry_id = entry;

            acc_Journal_Entry_Detail detailAct = new acc_Journal_Entry_Detail(Session)
            {
                account_id = account,
                credit = price,
                debit = 0,
                credit_currency = 0,
                debit_currency = 0,
                entry_text = entryText,
                jour_entry_id = entry
            };
            acc_Journal_Entry_Detail detailCash = new acc_Journal_Entry_Detail(Session)
            {
                account_id = cash,
                credit = 0,
                debit = price,
                credit_currency = 0,
                debit_currency = 0,
                entry_text = entryText,
                jour_entry_id = entry
            };
        }
        protected override void OnDeleting()
        {
            if (jour_entry_id != null)
            {
            acc_Journal_Entry entry = Session.GetObjectByKey<acc_Journal_Entry>(jour_entry_id.jour_entry_id);
            entry.Delete();
            Session.Delete(entry);
            }
            if (jour_entry_id_Paid != null)
            {
                acc_Journal_Entry entryPaid = Session.GetObjectByKey<acc_Journal_Entry>(jour_entry_id_Paid.jour_entry_id);
                entryPaid.Delete();
                Session.Delete(entryPaid);
            }
            base.OnDeleting();
        }
    }

}
