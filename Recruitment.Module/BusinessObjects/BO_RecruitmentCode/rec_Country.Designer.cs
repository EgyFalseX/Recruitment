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

    public partial class rec_Country : XPLiteObject
    {
        int fcountry_id;
        [Key(true)]
        public int country_id
        {
            get { return fcountry_id; }
            set { SetPropertyValue<int>("country_id", ref fcountry_id, value); }
        }
        string fcountry_name;
        public string country_name
        {
            get { return fcountry_name; }
            set { SetPropertyValue<string>("country_name", ref fcountry_name, value); }
        }
        [Association(@"rec_CityReferencesrec_Country")]
        public XPCollection<rec_City> rec_Citys { get { return GetCollection<rec_City>("rec_Citys"); } }
    }

}
