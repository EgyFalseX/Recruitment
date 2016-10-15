using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Accounting.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("JournalCaption")]
    [ImageName("acc_Journal_Entry_Detail16")]
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
    }

}
