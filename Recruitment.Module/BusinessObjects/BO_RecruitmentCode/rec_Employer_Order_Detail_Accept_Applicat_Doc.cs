using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [Appearance("Apr_Status", TargetItems = "*", Criteria = "frec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id IS NOT NULL " +
                                                            " And frec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id.frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id <> 1 " +
                                                            "And frec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id.frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id <> 4", Enabled = false)]
    public partial class rec_Employer_Order_Detail_Accept_Applicat_Doc
    {
        public rec_Employer_Order_Detail_Accept_Applicat_Doc(Session session) : base(session) { }
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
    }

}
