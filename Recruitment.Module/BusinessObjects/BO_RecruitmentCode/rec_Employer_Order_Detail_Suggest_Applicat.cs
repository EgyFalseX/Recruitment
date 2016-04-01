using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    public partial class rec_Employer_Order_Detail_Suggest_Applicat
    {
        public rec_Employer_Order_Detail_Suggest_Applicat(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
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
        public string CustomName
        {
            get
            {
                if (rec_employer_order_detail_suggest_applicat_applicant_id != null && rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id != null && rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_industry_id != null)
                {
                    
                    return string.Format("{0} - ({1})", rec_employer_order_detail_suggest_applicat_applicant_id.applicant_name, rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_industry_id.industry_name);
                }
                else
                {
                    return string.Format("{0}", "");

                }

            }
        }
    }

}
