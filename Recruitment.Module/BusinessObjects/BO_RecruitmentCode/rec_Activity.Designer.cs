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

    public partial class rec_Activity : XPLiteObject
    {
        int factivity_id;
        [Key(true)]
        [DevExpress.Xpo.DisplayName(@"ID")]
        public int activity_id
        {
            get { return factivity_id; }
            set { SetPropertyValue<int>("activity_id", ref factivity_id, value); }
        }
        string factivity_name;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Name")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_Activity_activity_activity_name_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Enter Name")]
        public string activity_name
        {
            get { return factivity_name; }
            set { SetPropertyValue<string>("activity_name", ref factivity_name, value); }
        }
        Accounting.BusinessObjects.Recruitment.acc_Account faccount_id;
        [Indexed(Name = @"iaccount_id_rec_Activity")]
        [DevExpress.Xpo.DisplayName(@"Account")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_Activity_activity_account_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Account")]
        public Accounting.BusinessObjects.Recruitment.acc_Account account_id
        {
            get { return faccount_id; }
            set { SetPropertyValue<Accounting.BusinessObjects.Recruitment.acc_Account>("account_id", ref faccount_id, value); }
        }
        bool fadvance_activity;
        [DevExpress.Xpo.DisplayName(@"Advance Activity")]
        public bool advance_activity
        {
            get { return fadvance_activity; }
            set { SetPropertyValue<bool>("advance_activity", ref fadvance_activity, value); }
        }
        bool fcredit;
        [DevExpress.Xpo.DisplayName(@"Credit")]
        public bool credit
        {
            get { return fcredit; }
            set { SetPropertyValue<bool>("credit", ref fcredit, value); }
        }
        bool fdebit;
        [DevExpress.Xpo.DisplayName(@"Debit")]
        public bool debit
        {
            get { return fdebit; }
            set { SetPropertyValue<bool>("debit", ref fdebit, value); }
        }
        string fdescription;
        [DevExpress.Xpo.DisplayName(@"Description")]
        public string description
        {
            get { return fdescription; }
            set { SetPropertyValue<string>("description", ref fdescription, value); }
        }
        rec_Activity_Type factivity_type_id;
        [Indexed(Name = @"iactivity_type_id_rec_Activity")]
        [Association(@"rec_ActivityReferencesrec_Activity_Type")]
        [DevExpress.Xpo.DisplayName(@"Activity Type")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_Activity_activity_activity_type_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Activity Type")]
        public rec_Activity_Type activity_type_id
        {
            get { return factivity_type_id; }
            set { SetPropertyValue<rec_Activity_Type>("activity_type_id", ref factivity_type_id, value); }
        }
        [DevExpress.Xpo.DisplayName(@"Accepted Applicant Activities")]
        [Association(@"rec_Accept_App_ActivityReferencesrec_Activity")]
        public XPCollection<rec_Accept_App_Activity> rec_Accept_App_Activitys { get { return GetCollection<rec_Accept_App_Activity>("rec_Accept_App_Activitys"); } }
        [DevExpress.Xpo.DisplayName(@"Employer Order Activities")]
        [Association(@"rec_Employer_Order_ActivityReferencesrec_Activity")]
        public XPCollection<rec_Employer_Order_Activity> rec_Employer_Order_Activitys { get { return GetCollection<rec_Employer_Order_Activity>("rec_Employer_Order_Activitys"); } }
        [DevExpress.Xpo.DisplayName(@"Employee Activities")]
        [Association(@"rec_Employee_ActivityReferencesrec_Activity")]
        public XPCollection<rec_Employee_Activity> rec_Employee_Activitys { get { return GetCollection<rec_Employee_Activity>("rec_Employee_Activitys"); } }
        [DevExpress.Xpo.DisplayName(@"Document Service Activities")]
        [Association(@"rec_DocSrv_ActivityReferencesrec_Activity")]
        public XPCollection<rec_DocSrv_Activity> rec_DocSrv_Activitys { get { return GetCollection<rec_DocSrv_Activity>("rec_DocSrv_Activitys"); } }
    }

}
