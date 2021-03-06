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

    public partial class rec_City : XPLiteObject
    {
        int fcity_id;
        [Key(true)]
        [DevExpress.Xpo.DisplayName(@"Id")]
        public int city_id
        {
            get { return fcity_id; }
            set { SetPropertyValue<int>("city_id", ref fcity_id, value); }
        }
        string fcity_name;
        [DevExpress.Xpo.DisplayName(@"City Name")]
        [DevExpress.Persistent.Validation.RuleUniqueValue("", DevExpress.Persistent.Validation.DefaultContexts.Save, "Object with the same name exists")]
        public string city_name
        {
            get { return fcity_name; }
            set { SetPropertyValue<string>("city_name", ref fcity_name, value); }
        }
        rec_Country fcity_country_id;
        [Indexed(Name = @"icity_country_id_rec_City")]
        [Association(@"rec_CityReferencesrec_Country")]
        [DevExpress.Xpo.DisplayName(@"Country")]
        public rec_Country city_country_id
        {
            get { return fcity_country_id; }
            set { SetPropertyValue<rec_Country>("city_country_id", ref fcity_country_id, value); }
        }
        [DevExpress.Xpo.DisplayName(@"Applicants")]
        [Association(@"rec_ApplicantReferencesrec_City")]
        public XPCollection<rec_Applicant> rec_Applicants { get { return GetCollection<rec_Applicant>("rec_Applicants"); } }
        [DevExpress.Xpo.DisplayName(@"Employers")]
        [Association(@"rec_EmployerReferencesrec_City")]
        public XPCollection<rec_Employer> rec_Employers { get { return GetCollection<rec_Employer>("rec_Employers"); } }
    }

}
