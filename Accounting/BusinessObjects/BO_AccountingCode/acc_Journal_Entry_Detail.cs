using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Accounting.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("JournalCaption")]
    [ImageName("acc_Journal_Entry_Detail")]
    [Appearance("Entry_Details_Closed", TargetItems = "*", Criteria = "jour_entry_id.period_id.closed = true ", Enabled = false, Priority = 1)]
    public partial class acc_Journal_Entry_Detail
    {
        public acc_Journal_Entry_Detail(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            debit = 0;
            credit = 0;
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

        [NonPersistent]
        public string JournalCaption => fjour_entry_id != null ? $"{fjour_entry_id.jour_entry_id} - {fentry_text}" : fentry_text;

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (IsLoading || IsDeleted || oldValue == newValue || currency_id == null || (propertyName != "debit" && propertyName != "credit" && propertyName != "debit_currency" && propertyName != "credit_currency" && propertyName != "currency_id")) return;
            double exchangePrice = currency_id.exchange_price;
            if (Math.Abs(exchangePrice) < 0.001) return;

            switch (propertyName)
            {
                case "debit":
                    if (Math.Abs(debit_currency - debit / exchangePrice) > 0.001)
                        debit_currency = debit / exchangePrice;
                    break;
                case "credit":
                    if (Math.Abs(credit_currency - credit / exchangePrice) > 0.001)
                        credit_currency = credit / exchangePrice;
                    break;

                case "debit_currency":
                    if (Math.Abs(debit - debit_currency * exchangePrice) > 0.001)
                        debit = debit_currency * exchangePrice;
                    break;
                case "credit_currency":
                    if (Math.Abs(credit - credit_currency * exchangePrice) > 0.001)
                        credit = credit_currency * exchangePrice;
                    break;
                case "currency_id":
                    if (credit > 0 && Math.Abs(credit_currency - credit / exchangePrice) > 0.001)
                        credit_currency = credit / exchangePrice;
                    else if (debit > 0 && Math.Abs(debit_currency - debit / exchangePrice) > 0.001)
                        debit_currency = debit / exchangePrice;
                    else if (credit_currency > 0 && Math.Abs(credit - credit_currency * exchangePrice) > 0.001)
                        credit = credit_currency * exchangePrice;
                    else if (debit_currency > 0 && Math.Abs(debit - debit_currency * exchangePrice) > 0.001)
                        debit = debit_currency * exchangePrice;
                    break;
            }
        }
    }

}
