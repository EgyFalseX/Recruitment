using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Online")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Posted Jobs")]
    [DevExpress.Persistent.Base.ImageName("rec_job_post")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("jp_title")]
    public partial class rec_job_post
    {
        public rec_job_post(Session session) : base(session) { }
        public override void AfterConstruction() {
            base.AfterConstruction();
            jp_visible = true;
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
    }

}
