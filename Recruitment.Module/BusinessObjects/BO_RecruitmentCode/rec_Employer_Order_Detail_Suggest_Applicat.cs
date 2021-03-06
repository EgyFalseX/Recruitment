﻿using System;
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
    [DevExpress.ExpressApp.DC.XafDisplayName("Suggested Applicant")]
    [Appearance("Apr_Status", TargetItems = "*", Criteria = "rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id IS NOT NULL " +
                                                            " And rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id <> 1" +
                                                            " And rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id <> 4", Enabled = false)]
    public partial class rec_Employer_Order_Detail_Suggest_Applicat
    {
        public rec_Employer_Order_Detail_Suggest_Applicat(Session session) : base(session) { }
        public override void AfterConstruction() {
            base.AfterConstruction();
            frec_employer_order_detail_suggest_applicat_rec_applicant_status_id = Typez.enum_rec_Suggest_Applicant_Status.WaitingConfirmation;
        }
        Typez.enum_rec_Suggest_Applicant_Status frec_employer_order_detail_suggest_applicat_rec_applicant_status_id;
        //[Association(@"rec_Employer_Order_Detail_Suggest_ApplicatReferencesrec_Applicant_Status")]
        [Indexed(Name = @"irec_employer_order_detail_suggest_applicat_rec_applicant_status_id_rec_Employer_Order_Detail_Suggest_Applicat")]
        public Typez.enum_rec_Suggest_Applicant_Status rec_employer_order_detail_suggest_applicat_rec_applicant_status_id
        {
            get { return frec_employer_order_detail_suggest_applicat_rec_applicant_status_id; }
            set { SetPropertyValue<Typez.enum_rec_Suggest_Applicant_Status>("rec_employer_order_detail_suggest_applicat_rec_applicant_status_id", ref frec_employer_order_detail_suggest_applicat_rec_applicant_status_id, value); }
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
