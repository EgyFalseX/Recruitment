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

    public partial class rec_Job : XPLiteObject
    {
        int fjob_id;
        [Key(true)]
        [DevExpress.Xpo.DisplayName(@"Id")]
        public int job_id
        {
            get { return fjob_id; }
            set { SetPropertyValue<int>("job_id", ref fjob_id, value); }
        }
        string fjob_name;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Job name")]
        [DevExpress.Persistent.Validation.RuleUniqueValue("", DevExpress.Persistent.Validation.DefaultContexts.Save, "Object with the same name exists")]
        public string job_name
        {
            get { return fjob_name; }
            set { SetPropertyValue<string>("job_name", ref fjob_name, value); }
        }
        [DevExpress.Xpo.DisplayName(@"Applicant Experiences")]
        [Association(@"rec_Applicant_ExperienceReferencesrec_Job")]
        public XPCollection<rec_Applicant_Experience> rec_Applicant_Experiences { get { return GetCollection<rec_Applicant_Experience>("rec_Applicant_Experiences"); } }
    }

}
