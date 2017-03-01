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

    public partial class rec_job_post_apply : XPLiteObject
    {
        int fjob_post_apply_id;
        [Key(true)]
        [DevExpress.Xpo.DisplayName(@"ID")]
        public int job_post_apply_id
        {
            get { return fjob_post_apply_id; }
            set { SetPropertyValue<int>("job_post_apply_id", ref fjob_post_apply_id, value); }
        }
        rec_job_post fjob_post_id;
        [Indexed(Name = @"ijob_post_id_rec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_job_post")]
        [DevExpress.Xpo.DisplayName(@"Post")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_job_post_apply_job_post_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Job Post")]
        public rec_job_post job_post_id
        {
            get { return fjob_post_id; }
            set { SetPropertyValue<rec_job_post>("job_post_id", ref fjob_post_id, value); }
        }
        DateTime fapply_date;
        [DevExpress.Xpo.DisplayName(@"Apply Date")]
        public DateTime apply_date
        {
            get { return fapply_date; }
            set { SetPropertyValue<DateTime>("apply_date", ref fapply_date, value); }
        }
        string fapply_name;
        [DevExpress.Xpo.DisplayName(@"Name")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_job_post_apply_apply_name_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Enter Name")]
        public string apply_name
        {
            get { return fapply_name; }
            set { SetPropertyValue<string>("apply_name", ref fapply_name, value); }
        }
        rec_Gender fapply_gender_id;
        [Indexed(Name = @"iapply_gender_id_rec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_Gender")]
        [DevExpress.Xpo.DisplayName(@"Gender")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_job_post_apply_apply_gender_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Gender")]
        public rec_Gender apply_gender_id
        {
            get { return fapply_gender_id; }
            set { SetPropertyValue<rec_Gender>("apply_gender_id", ref fapply_gender_id, value); }
        }
        rec_Nationality fapply_nationality_id;
        [Indexed(Name = @"iapply_nationality_id_rec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_Nationality")]
        [DevExpress.Xpo.DisplayName(@"Nationality")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_job_post_apply_apply_nationality_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Nationality")]
        public rec_Nationality apply_nationality_id
        {
            get { return fapply_nationality_id; }
            set { SetPropertyValue<rec_Nationality>("apply_nationality_id", ref fapply_nationality_id, value); }
        }
        string fapply_mobile;
        [Size(20)]
        [DevExpress.Xpo.DisplayName(@"Mobile")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_job_post_apply_apply_mobile_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Enter Mobile")]
        public string apply_mobile
        {
            get { return fapply_mobile; }
            set { SetPropertyValue<string>("apply_mobile", ref fapply_mobile, value); }
        }
        DevExpress.Persistent.BaseImpl.FileData fattach_file;
        [Indexed(Name = @"iattach_file_rec_job_post_apply")]
        [DevExpress.Xpo.DisplayName(@"Attached file")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_job_post_apply_attach_file_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select CV")]
        public DevExpress.Persistent.BaseImpl.FileData attach_file
        {
            get { return fattach_file; }
            set { SetPropertyValue<DevExpress.Persistent.BaseImpl.FileData>("attach_file", ref fattach_file, value); }
        }
        rec_Applicant fapplicant_id;
        [Indexed(Name = @"iapplicant_id_rec_job_post_apply")]
        [Association(@"rec_job_post_applyReferencesrec_Applicant")]
        [DevExpress.Xpo.DisplayName(@"Applicant")]
        public rec_Applicant applicant_id
        {
            get { return fapplicant_id; }
            set { SetPropertyValue<rec_Applicant>("applicant_id", ref fapplicant_id, value); }
        }
    }

}
