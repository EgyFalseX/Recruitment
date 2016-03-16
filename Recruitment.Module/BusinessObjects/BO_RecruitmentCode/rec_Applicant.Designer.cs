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

    public partial class rec_Applicant : XPLiteObject
    {
        int fapplicant_id;
        [Key]
        public int applicant_id
        {
            get { return fapplicant_id; }
            set { SetPropertyValue<int>("applicant_id", ref fapplicant_id, value); }
        }
        string fapplicant_name;
        public string applicant_name
        {
            get { return fapplicant_name; }
            set { SetPropertyValue<string>("applicant_name", ref fapplicant_name, value); }
        }
        string fapplicant_email;
        [Size(50)]
        public string applicant_email
        {
            get { return fapplicant_email; }
            set { SetPropertyValue<string>("applicant_email", ref fapplicant_email, value); }
        }
        rec_City fapplicant_city_id;
        [Association(@"rec_ApplicantReferencesrec_City")]
        public rec_City applicant_city_id
        {
            get { return fapplicant_city_id; }
            set { SetPropertyValue<rec_City>("applicant_city_id", ref fapplicant_city_id, value); }
        }
        string fapplicant_phone;
        [Size(50)]
        public string applicant_phone
        {
            get { return fapplicant_phone; }
            set { SetPropertyValue<string>("applicant_phone", ref fapplicant_phone, value); }
        }
        string fapplicant_mobile;
        [Size(50)]
        public string applicant_mobile
        {
            get { return fapplicant_mobile; }
            set { SetPropertyValue<string>("applicant_mobile", ref fapplicant_mobile, value); }
        }
        rec_Nationality fapplicant_nationality_id;
        [Association(@"rec_ApplicantReferencesrec_Nationality")]
        public rec_Nationality applicant_nationality_id
        {
            get { return fapplicant_nationality_id; }
            set { SetPropertyValue<rec_Nationality>("applicant_nationality_id", ref fapplicant_nationality_id, value); }
        }
        rec_Marital_Status fapplicant_marital_status_id;
        [Association(@"rec_ApplicantReferencesrec_Marital_Status")]
        public rec_Marital_Status applicant_marital_status_id
        {
            get { return fapplicant_marital_status_id; }
            set { SetPropertyValue<rec_Marital_Status>("applicant_marital_status_id", ref fapplicant_marital_status_id, value); }
        }
        rec_Military_Status fapplicant_military_id;
        [Association(@"rec_ApplicantReferencesrec_Military_Status")]
        public rec_Military_Status applicant_military_id
        {
            get { return fapplicant_military_id; }
            set { SetPropertyValue<rec_Military_Status>("applicant_military_id", ref fapplicant_military_id, value); }
        }
        DateTime fapplicant_birth_date;
        public DateTime applicant_birth_date
        {
            get { return fapplicant_birth_date; }
            set { SetPropertyValue<DateTime>("applicant_birth_date", ref fapplicant_birth_date, value); }
        }
        rec_Work_Type fapplicant_work_type_id;
        [Association(@"rec_ApplicantReferencesrec_Work_Type")]
        public rec_Work_Type applicant_work_type_id
        {
            get { return fapplicant_work_type_id; }
            set { SetPropertyValue<rec_Work_Type>("applicant_work_type_id", ref fapplicant_work_type_id, value); }
        }
        double fapplicant_salary;
        public double applicant_salary
        {
            get { return fapplicant_salary; }
            set { SetPropertyValue<double>("applicant_salary", ref fapplicant_salary, value); }
        }
        rec_Industry fapplicant_industry_id;
        [Association(@"rec_ApplicantReferencesrec_Industry")]
        public rec_Industry applicant_industry_id
        {
            get { return fapplicant_industry_id; }
            set { SetPropertyValue<rec_Industry>("applicant_industry_id", ref fapplicant_industry_id, value); }
        }
        rec_Position fapplicant_position_id;
        [Association(@"rec_ApplicantReferencesrec_Position")]
        public rec_Position applicant_position_id
        {
            get { return fapplicant_position_id; }
            set { SetPropertyValue<rec_Position>("applicant_position_id", ref fapplicant_position_id, value); }
        }
        bool fapplicant_driving_license;
        public bool applicant_driving_license
        {
            get { return fapplicant_driving_license; }
            set { SetPropertyValue<bool>("applicant_driving_license", ref fapplicant_driving_license, value); }
        }
        string fapplicant_skill;
        [Size(1000)]
        public string applicant_skill
        {
            get { return fapplicant_skill; }
            set { SetPropertyValue<string>("applicant_skill", ref fapplicant_skill, value); }
        }
        string fapplicant_summary;
        [Size(1000)]
        public string applicant_summary
        {
            get { return fapplicant_summary; }
            set { SetPropertyValue<string>("applicant_summary", ref fapplicant_summary, value); }
        }
        int fapplicant_user_id;
        public int applicant_user_id
        {
            get { return fapplicant_user_id; }
            set { SetPropertyValue<int>("applicant_user_id", ref fapplicant_user_id, value); }
        }
        DateTime fapplicant_date_in;
        public DateTime applicant_date_in
        {
            get { return fapplicant_date_in; }
            set { SetPropertyValue<DateTime>("applicant_date_in", ref fapplicant_date_in, value); }
        }
        [Association(@"rec_Applicant_CourseReferencesrec_Applicant")]
        public XPCollection<rec_Applicant_Course> rec_Applicant_Courses { get { return GetCollection<rec_Applicant_Course>("rec_Applicant_Courses"); } }
        [Association(@"rec_Applicant_EducationReferencesrec_Applicant")]
        public XPCollection<rec_Applicant_Education> rec_Applicant_Educations { get { return GetCollection<rec_Applicant_Education>("rec_Applicant_Educations"); } }
        [Association(@"rec_Applicant_ExperienceReferencesrec_Applicant")]
        public XPCollection<rec_Applicant_Experience> rec_Applicant_Experiences { get { return GetCollection<rec_Applicant_Experience>("rec_Applicant_Experiences"); } }
        [Association(@"rec_Applicant_ProjectReferencesrec_Applicant")]
        public XPCollection<rec_Applicant_Project> rec_Applicant_Projects { get { return GetCollection<rec_Applicant_Project>("rec_Applicant_Projects"); } }
        [Association(@"rec_Applicant_StudyReferencesrec_Applicant")]
        public XPCollection<rec_Applicant_Study> rec_Applicant_Studys { get { return GetCollection<rec_Applicant_Study>("rec_Applicant_Studys"); } }
    }

}
