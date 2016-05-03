using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using System.Linq;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions][Appearance("Apr_Status", TargetItems = "*", Criteria = "frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id IS NOT NULL And frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id <> 1", Enabled = false)]
    public partial class rec_Employer_Order_Detail_Accept_Applicat
    {
       
        public rec_Employer_Order_Detail_Accept_Applicat(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction();
            this.frec_employer_order_detail_accept_applicat_rec_applicant_status_id = Session.FindObject<rec_Applicant_Status>(CriteriaOperator.Parse("rec_applicant_status_id = ?", 1));
                }

        protected override void OnSaving()
        {
            base.OnSaving();
            //stop audit
            //DevExpress.Persistent.AuditTrail.AuditTrailService.Instance.EndSessionAudit(Session);
            if (this.IsDeleted)
            {
                return;
            }
            int industry = this.frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_industry_id.industry_id;
            XPCollection<rec_Industry_Require_Doc_Info> Docs = new XPCollection<rec_Industry_Require_Doc_Info>(Session, new BinaryOperator("rec_industry_require_doc_info_industry_id", industry));
            XPCollection<rec_Require_Doc_Status> doc_status = new XPCollection<rec_Require_Doc_Status>(Session);
            if (doc_status.Count == 0)
                return;
            foreach (rec_Industry_Require_Doc_Info doc_info in Docs)
            {
                rec_Employer_Order_Detail_Accept_Applicat_Doc doc = new rec_Employer_Order_Detail_Accept_Applicat_Doc(Session);
                doc.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_industry_require_doc_info_id = doc_info;
                doc.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id = this;
                doc.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_require_doc_status_id = doc_status[1];
                this.rec_Employer_Order_Detail_Accept_Applicat_Docs.Add(doc);
            }
            //stop audit
            //DevExpress.Persistent.AuditTrail.AuditTrailService.Instance.BeginSessionAudit(Session, DevExpress.Persistent.AuditTrail.AuditTrailStrategy.OnObjectChanged);
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
        [DevExpress.Persistent.Base.EditorAlias("ProgressProperty")]
        public double Progress
        {
            get
            {
                return 0.0;
                double output = 0.0;
                double completed = 0.0;
                if (rec_Employer_Order_Detail_Accept_Applicat_Docs != null)
                {
                    foreach (rec_Employer_Order_Detail_Accept_Applicat_Doc item in rec_Employer_Order_Detail_Accept_Applicat_Docs)
                    {
                        if (item.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_require_doc_status_id.rec_require_doc_status_id == (int)Core.Typez.enum_Doc_Status.Completed)
                            completed++;
                    }
                    output = completed / rec_Employer_Order_Detail_Accept_Applicat_Docs.Count;
                }
                return output;
            }
        }

    }

}
