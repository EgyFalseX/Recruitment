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

    public partial class rec_Employer_Order_Detail_Accept_Applicat : XPLiteObject
    {
        rec_Employer_Order_Detail_Suggest_Applicat frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id;
        [Key]
        [Association(@"rec_Employer_Order_Detail_Accept_ApplicatReferencesrec_Employer_Order_Detail_Suggest_Applicat")]
        public rec_Employer_Order_Detail_Suggest_Applicat rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
        {
            get { return frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id; }
            set { SetPropertyValue<rec_Employer_Order_Detail_Suggest_Applicat>("rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id", ref frec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id, value); }
        }
        string frec_employer_order_detail_accept_applicat_description;
        [Size(1000)]
        public string rec_employer_order_detail_accept_applicat_description
        {
            get { return frec_employer_order_detail_accept_applicat_description; }
            set { SetPropertyValue<string>("rec_employer_order_detail_accept_applicat_description", ref frec_employer_order_detail_accept_applicat_description, value); }
        }
        rec_Applicant_Status frec_employer_order_detail_accept_applicat_rec_applicant_status_id;
        [Indexed(Name = @"irec_employer_order_detail_accept_applicat_rec_applicant_status_id_rec_Employer_Order_Detail_Accept_Applicat")]
        [Association(@"rec_Employer_Order_Detail_Accept_ApplicatReferencesrec_Applicant_Status")]
        public rec_Applicant_Status rec_employer_order_detail_accept_applicat_rec_applicant_status_id
        {
            get { return frec_employer_order_detail_accept_applicat_rec_applicant_status_id; }
            set { SetPropertyValue<rec_Applicant_Status>("rec_employer_order_detail_accept_applicat_rec_applicant_status_id", ref frec_employer_order_detail_accept_applicat_rec_applicant_status_id, value); }
        }
        [Association(@"rec_Employer_Order_Detail_Accept_Applicat_DocReferencesrec_Employer_Order_Detail_Accept_Applicat")]
        public XPCollection<rec_Employer_Order_Detail_Accept_Applicat_Doc> rec_Employer_Order_Detail_Accept_Applicat_Docs { get { return GetCollection<rec_Employer_Order_Detail_Accept_Applicat_Doc>("rec_Employer_Order_Detail_Accept_Applicat_Docs"); } }
    }

}
