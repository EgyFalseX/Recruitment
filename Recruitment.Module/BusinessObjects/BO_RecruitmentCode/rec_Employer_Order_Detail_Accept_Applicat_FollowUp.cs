using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Employer")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Accepted Applicant Follow Up")]
    [DevExpress.Persistent.Base.ImageName("FollowUp")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("CustomName")]
    public partial class rec_Employer_Order_Detail_Accept_Applicat_FollowUp
    {
        public rec_Employer_Order_Detail_Accept_Applicat_FollowUp(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); ffollow_date = Core.SqlOp.GetServerDateTime(Session); }

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
        [DevExpress.Xpo.DisplayName(@"Date - Applicant")]
        [NonPersistent]
        public string CustomName
            =>
                frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id == null
                    ? string.Empty
                    : ffollow_date.ToShortDateString() + " -" +
                      frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          .rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          .rec_employer_order_detail_suggest_applicat_applicant_id.applicant_name;
    }

}
