using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Accounting")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Employee")]
    [DevExpress.Persistent.Base.ImageName("rec_Employee")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("employee_name")]
    public partial class rec_Employee
    {
        public rec_Employee(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction();
            active = true;
            salary = 0;
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
