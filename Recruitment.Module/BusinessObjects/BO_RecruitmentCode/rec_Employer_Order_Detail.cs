using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using Recruitment.Module.Core;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [Appearance("Apr_Status", TargetItems = "*", Criteria = "rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id IS NOT NULL " +
                                                            " And rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id <> 1 " +
                                                            " And rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id <> 4", Enabled = false)]
    public partial class rec_Employer_Order_Detail
    {
        public rec_Employer_Order_Detail(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); frec_employer_order_detail_count = 1; }
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
        }[NonPersistent]
        public string CustomName
        {
            get
            {
                if (rec_employer_order_detail_rec_employer_order_id != null && rec_employer_order_detail_industry_id != null)
                {
                    return string.Format("{0} - {1} - {2}", rec_employer_order_detail_rec_employer_order_id.rec_employer_order_id
                                    , rec_employer_order_detail_id
                                    , rec_employer_order_detail_industry_id.industry_name);
                }
                else
                {
                    return string.Format("{0}", rec_employer_order_detail_id);
                }
            }
        }
        [NonPersistent]
        [EditorAlias("ProgressProperty")]
        public double RecruitmentProgress
        {
            get
            {
                //XPView view = new XPView(Session, typeof(rec_Employer_Order_Detail));view.AddProperty("RealPrice", "iif(RebatePercent == 0, ArticlePrice, ArticlePrice - (ArticlePrice * RebatePercent / 100))");
                double completed = Convert.ToDouble(Session.Evaluate<rec_Employer_Order_Detail_Suggest_Applicat>(CriteriaOperator.Parse("Count"),
                   CriteriaOperator.Parse("rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id = ? " +
                                          "AND rec_employer_order_detail_suggest_applicat_rec_applicant_status_id != ?"
                                          , this.frec_employer_order_detail_id
                                          , (int)Typez.enum_rec_Suggest_Applicant_Status.Refused)));

                return this.rec_employer_order_detail_count <= 0 ? 0.0 : completed / this.rec_employer_order_detail_count;
                //double accepted_app = 0;
                return 0.0;
                double accepted_doc = 0;
                if (rec_Employer_Order_Detail_Suggest_Applicats != null)
                {
                    foreach (rec_Employer_Order_Detail_Suggest_Applicat Suggest in rec_Employer_Order_Detail_Suggest_Applicats)
                    {
                        if (Suggest.rec_Employer_Order_Detail_Accept_Applicats == null)
                            continue;
                        foreach (rec_Employer_Order_Detail_Accept_Applicat Accept in Suggest.rec_Employer_Order_Detail_Accept_Applicats)
                            accepted_doc += Accept.OperationProgress;
                    }
                }
                return accepted_doc / (frec_employer_order_detail_count == 0 ? 1 : frec_employer_order_detail_count);
            }
        }
        [NonPersistent]
        [DevExpress.Persistent.Base.EditorAlias("ProgressProperty")]
        public double OperationProgress
        {
            get
            {
                double total = Convert.ToDouble(Session.Evaluate<rec_Employer_Order_Detail_Accept_Applicat_Doc>(CriteriaOperator.Parse("Count"),
                    CriteriaOperator.Parse("rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id" +
                                           ".rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id" +
                                           ".rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id = ?"
                    , this.frec_employer_order_detail_id)));

                double completed = Convert.ToDouble(Session.Evaluate<rec_Employer_Order_Detail_Accept_Applicat_Doc>(CriteriaOperator.Parse("Count"),
                    CriteriaOperator.Parse("rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id" +
                                           ".rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id" +
                                           ".rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id = ?" +
                                           " AND rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_require_doc_status_id = ?"
                    , this.frec_employer_order_detail_id, (int)Core.Typez.enum_Doc_Status.Completed)));

                return total <= 0 ? 0.0 : completed / total;

            }
        }

    }
}
