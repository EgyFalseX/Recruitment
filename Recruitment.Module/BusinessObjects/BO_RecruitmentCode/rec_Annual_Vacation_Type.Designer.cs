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

    public partial class rec_Annual_Vacation_Type : XPLiteObject
    {
        int frec_annual_vacation_type_id;
        [Key(true)]
        public int rec_annual_vacation_type_id
        {
            get { return frec_annual_vacation_type_id; }
            set { SetPropertyValue<int>("rec_annual_vacation_type_id", ref frec_annual_vacation_type_id, value); }
        }
        string frec_annual_vacation_type_name;
        [Size(50)]
        public string rec_annual_vacation_type_name
        {
            get { return frec_annual_vacation_type_name; }
            set { SetPropertyValue<string>("rec_annual_vacation_type_name", ref frec_annual_vacation_type_name, value); }
        }
        [Association(@"rec_Employer_Order_DetailReferencesrec_Annual_Vacation_Type")]
        public XPCollection<rec_Employer_Order_Detail> rec_Employer_Order_Details { get { return GetCollection<rec_Employer_Order_Detail>("rec_Employer_Order_Details"); } }
    }

}