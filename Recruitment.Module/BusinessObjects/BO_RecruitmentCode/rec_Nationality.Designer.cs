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

    public partial class rec_Nationality : XPLiteObject
    {
        int fnationality_id;
        [Key]
        public int nationality_id
        {
            get { return fnationality_id; }
            set { SetPropertyValue<int>("nationality_id", ref fnationality_id, value); }
        }
        string fnationality_name;
        public string nationality_name
        {
            get { return fnationality_name; }
            set { SetPropertyValue<string>("nationality_name", ref fnationality_name, value); }
        }
        [Association(@"rec_ApplicantReferencesrec_Nationality")]
        public XPCollection<rec_Applicant> rec_Applicants { get { return GetCollection<rec_Applicant>("rec_Applicants"); } }
    }

}
