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

    public partial class rec_University : XPLiteObject
    {
        int funiversity_id;
        [Key(true)]
        public int university_id
        {
            get { return funiversity_id; }
            set { SetPropertyValue<int>("university_id", ref funiversity_id, value); }
        }
        string funiversity_name;
        public string university_name
        {
            get { return funiversity_name; }
            set { SetPropertyValue<string>("university_name", ref funiversity_name, value); }
        }
        [Association(@"rec_Applicant_EducationReferencesrec_University")]
        public XPCollection<rec_Applicant_Education> rec_Applicant_Educations { get { return GetCollection<rec_Applicant_Education>("rec_Applicant_Educations"); } }
    }

}
