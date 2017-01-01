using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Document Service")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Document Service Order")]
    [DevExpress.Persistent.Base.ImageName("rec_DocSrv_Order")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("CustomName")]
    public partial class rec_DocSrv_Order
    {
        public rec_DocSrv_Order(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction();
            forder_date = Core.SqlOp.GetServerDateTime(Session);
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
        public string CustomName => $"{forder_date.ToShortDateString()} - {fperson_name}";
    }

}
