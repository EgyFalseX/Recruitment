﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Recruitment.Module.BusinessObjects.Recruitment
{

    public partial class rec_Employer_Order_Detail_Accept_Applicat_FollowUp : XPLiteObject
    {
        int ffollow_id;
        [Key(true)]
        [DevExpress.Xpo.DisplayName(@"ID")]
        public int follow_id
        {
            get { return ffollow_id; }
            set { SetPropertyValue<int>("follow_id", ref ffollow_id, value); }
        }
        rec_Employer_Order_Detail_Accept_Applicat frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id;
        [Indexed(Name = @"irec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id_rec_Employer_Order_Detail_Acce_859162E2")]
        [Association(@"rec_Employer_Order_Detail_Accept_Applicat_FollowUpReferencesrec_Employer_Order_Detail_Accept_Applicat")]
        [DevExpress.Xpo.DisplayName(@"Accepted Applicant")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_Employer_Order_Detail_Accept_Applicat_FollowUp_rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Accepted Applicant")]
        public rec_Employer_Order_Detail_Accept_Applicat rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
        {
            get { return frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id; }
            set { SetPropertyValue<rec_Employer_Order_Detail_Accept_Applicat>("rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id", ref frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id, value); }
        }
        DateTime ffollow_date;
        [DevExpress.Xpo.DisplayName(@"Follow Date")]
        public DateTime follow_date
        {
            get { return ffollow_date; }
            set { SetPropertyValue<DateTime>("follow_date", ref ffollow_date, value); }
        }
        string fnotes;
        [Size(1000)]
        [DevExpress.Xpo.DisplayName(@"Notes")]
        public string notes
        {
            get { return fnotes; }
            set { SetPropertyValue<string>("notes", ref fnotes, value); }
        }
    }

}
