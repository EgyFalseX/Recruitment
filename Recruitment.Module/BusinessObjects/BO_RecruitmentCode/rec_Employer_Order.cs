using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using Recruitment.Module.Core;
using System.Linq;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [Appearance("Apr_Status", TargetItems = "*", Criteria = "rec_employer_order_rec_employer_order_status_id <> 1 " +
                                                            " AND rec_employer_order_rec_employer_order_status_id <> 4", Enabled = false)]
    public partial class rec_Employer_Order
    {
        public rec_Employer_Order(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.frec_employer_order_rec_employer_order_status_id = Typez.enum_rec_Employer_Order_Status.InProgress;
        }
        Core.Typez.enum_rec_Employer_Order_Status frec_employer_order_rec_employer_order_status_id;
        //[Association(@"rec_Employer_OrderReferencesrec_Employer_Order_Status")]
        public Core.Typez.enum_rec_Employer_Order_Status rec_employer_order_rec_employer_order_status_id
        {
            get { return frec_employer_order_rec_employer_order_status_id; }
            set { SetPropertyValue<Core.Typez.enum_rec_Employer_Order_Status>("rec_employer_order_rec_employer_order_status_id", ref frec_employer_order_rec_employer_order_status_id, value); }
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
        public string CustomName
        {
            get
            {
                if (rec_employer_order_employer_id != null)
                {
                    return string.Format("{0} - {1}", frec_employer_order_id, rec_employer_order_employer_id.employer_company_name);
                }
                else
                {
                    return string.Format("{0}", frec_employer_order_id);

                }
                
            }
        }
        [NonPersistent]
        [EditorAlias("ProgressProperty")]
        public double RecruitmentProgress
        {
            get
            {

                //XPCollection<rec_Employer_Order> order = new XPCollection<rec_Employer_Order>(Session);
                //XPCollection<rec_Employer_Order_Detail> details = new XPCollection<rec_Employer_Order_Detail>(Session);
                //XPCollection<rec_Employer_Order_Detail_Suggest_Applicat> sug = new XPCollection<rec_Employer_Order_Detail_Suggest_Applicat>(Session);
                //return (from subQ_sugCount in
                //    (
                //        from suggested in sug
                //        join order_details in details on
                //            suggested.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_id equals
                //            order_details.rec_employer_order_detail_id
                //        where
                //            suggested.rec_employer_order_detail_suggest_applicat_rec_applicant_status_id != Typez.enum_rec_Suggest_Applicant_Status.Refused &&
                //            order_details.rec_employer_order_detail_id == this.frec_employer_order_id
                //        group suggested by
                //            suggested.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id
                //        into grp
                //        select new { Id = grp.Key, Count = grp.Count() }
                //        )
                //        join order_details in details on subQ_sugCount.Id.rec_employer_order_detail_id equals
                //            order_details.rec_employer_order_detail_id
                //        select new { Percent = subQ_sugCount.Count * 1.0 / order_details.rec_employer_order_detail_count })
                //    .Average(per => per.Percent);

                double order_Percent = 0;
                if (rec_Employer_Order_Details != null)
                {
                    foreach (rec_Employer_Order_Detail detail in rec_Employer_Order_Details)
                        order_Percent += detail.RecruitmentProgress;
                    return order_Percent / (rec_Employer_Order_Details.Count == 0 ? 1 : rec_Employer_Order_Details.Count);
                }
                else
                    return 0;
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
                                           ".rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id" +
                                           ".rec_employer_order_detail_rec_employer_order_id = ?"
                    , this.frec_employer_order_id)));

                double completed = Convert.ToDouble(Session.Evaluate<rec_Employer_Order_Detail_Accept_Applicat_Doc>(CriteriaOperator.Parse("Count"),
                    CriteriaOperator.Parse("rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id" +
                                           ".rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id" +
                                           ".rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id" +
                                           ".rec_employer_order_detail_rec_employer_order_id = ?" +
                                           " AND rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_require_doc_status_id = ?"
                    , this.frec_employer_order_id, (int)Core.Typez.enum_Doc_Status.Completed)));

                return total <= 0 ? 0.0 : completed / total;

            }
        }
    }
    }
