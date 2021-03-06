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
namespace Recruitment.Web.BO.Recruitment
{

    public partial class rec_job_post_apply : XPLiteObject
    {
        rec_Applicant fapplicant_id;
        [Indexed(Name = @"rec_Applicantrec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_Applicant")]
        public rec_Applicant applicant_id
        {
            get { return fapplicant_id; }
            set { SetPropertyValue<rec_Applicant>("applicant_id", ref fapplicant_id, value); }
        }
        DateTime fapply_date;
        public DateTime apply_date
        {
            get { return fapply_date; }
            set { SetPropertyValue<DateTime>("apply_date", ref fapply_date, value); }
        }
        rec_Gender fapply_gender_id;
        [Indexed(Name = @"rec_Genderrec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_Gender")]
        public rec_Gender apply_gender_id
        {
            get { return fapply_gender_id; }
            set { SetPropertyValue<rec_Gender>("apply_gender_id", ref fapply_gender_id, value); }
        }
        string fapply_mobile;
        [Size(20)]
        public string apply_mobile
        {
            get { return fapply_mobile; }
            set { SetPropertyValue<string>("apply_mobile", ref fapply_mobile, value); }
        }
        string fapply_name;
        public string apply_name
        {
            get { return fapply_name; }
            set { SetPropertyValue<string>("apply_name", ref fapply_name, value); }
        }
        rec_Nationality fapply_nationality_id;
        [Indexed(Name = @"rec_Nationalityrec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_Nationality")]
        public rec_Nationality apply_nationality_id
        {
            get { return fapply_nationality_id; }
            set { SetPropertyValue<rec_Nationality>("apply_nationality_id", ref fapply_nationality_id, value); }
        }
        string fattach_file;
        [Size(255)]
        public string attach_file
        {
            get { return fattach_file; }
            set { SetPropertyValue<string>("attach_file", ref fattach_file, value); }
        }
        int fjob_post_apply_id;
        [Key(true)]
        public int job_post_apply_id
        {
            get { return fjob_post_apply_id; }
            set { SetPropertyValue<int>("job_post_apply_id", ref fjob_post_apply_id, value); }
        }
        rec_job_post fjob_post_id;
        [Indexed(Name = @"rec_job_postrec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_job_post")]
        public rec_job_post job_post_id
        {
            get { return fjob_post_id; }
            set { SetPropertyValue<rec_job_post>("job_post_id", ref fjob_post_id, value); }
        }
    }

}
