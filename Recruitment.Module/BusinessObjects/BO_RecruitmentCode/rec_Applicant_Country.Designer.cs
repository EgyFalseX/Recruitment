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

    public partial class rec_Applicant_Country : XPLiteObject
    {
        int fapp_trv_id;
        [Key(true)]
        public int app_trv_id
        {
            get { return fapp_trv_id; }
            set { SetPropertyValue<int>("app_trv_id", ref fapp_trv_id, value); }
        }
        rec_Applicant fapp_trv_applicant_id;
        [Indexed(Name = @"iapp_trv_applicant_id_rec_Applicant_Country")]
        [Association(@"rec_Applicant_CountryReferencesrec_Applicant")]
        public rec_Applicant app_trv_applicant_id
        {
            get { return fapp_trv_applicant_id; }
            set { SetPropertyValue<rec_Applicant>("app_trv_applicant_id", ref fapp_trv_applicant_id, value); }
        }
        rec_Country fapp_trv_country_id;
        [Indexed(Name = @"iapp_trv_country_id_rec_Applicant_Country")]
        [Association(@"rec_Applicant_CountryReferencesrec_Country")]
        public rec_Country app_trv_country_id
        {
            get { return fapp_trv_country_id; }
            set { SetPropertyValue<rec_Country>("app_trv_country_id", ref fapp_trv_country_id, value); }
        }
        int fapp_trv_year;
        public int app_trv_year
        {
            get { return fapp_trv_year; }
            set { SetPropertyValue<int>("app_trv_year", ref fapp_trv_year, value); }
        }
    }

}
