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

    public partial class rec_Degree : XPLiteObject
    {
        int fdegree_id;
        [Key(true)]
        public int degree_id
        {
            get { return fdegree_id; }
            set { SetPropertyValue<int>("degree_id", ref fdegree_id, value); }
        }
        string fdegree_name;
        [Size(50)]
        public string degree_name
        {
            get { return fdegree_name; }
            set { SetPropertyValue<string>("degree_name", ref fdegree_name, value); }
        }
        [Association(@"rec_Applicant_EducationReferencesrec_Degree")]
        public XPCollection<rec_Applicant_Education> rec_Applicant_Educations { get { return GetCollection<rec_Applicant_Education>("rec_Applicant_Educations"); } }
    }

}
