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

    public partial class AppCompany : XPLiteObject
    {
        int fcompany_id;
        [Key]
        [DevExpress.Xpo.DisplayName(@"ID")]
        public int company_id
        {
            get { return fcompany_id; }
            set { SetPropertyValue<int>("company_id", ref fcompany_id, value); }
        }
        string fcompany_name;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Company Name")]
        [DevExpress.Persistent.Validation.RulePropertiesRequired(true)]
        public string company_name
        {
            get { return fcompany_name; }
            set { SetPropertyValue<string>("company_name", ref fcompany_name, value); }
        }
        string fcompany_address;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Address")]
        public string company_address
        {
            get { return fcompany_address; }
            set { SetPropertyValue<string>("company_address", ref fcompany_address, value); }
        }
        string fcompany_mobile;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Mobile")]
        [DevExpress.Persistent.Validation.RulePropertiesRequired(true)]
        public string company_mobile
        {
            get { return fcompany_mobile; }
            set { SetPropertyValue<string>("company_mobile", ref fcompany_mobile, value); }
        }
        string fcompany_phone;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Phone")]
        public string company_phone
        {
            get { return fcompany_phone; }
            set { SetPropertyValue<string>("company_phone", ref fcompany_phone, value); }
        }
        string fcompany_fax;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Fax")]
        public string company_fax
        {
            get { return fcompany_fax; }
            set { SetPropertyValue<string>("company_fax", ref fcompany_fax, value); }
        }
        System.Drawing.Image fcompany_logo;
        [Size(SizeAttribute.Unlimited)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        [DevExpress.Xpo.DisplayName(@"Company Logo")]
        [DevExpress.Persistent.Validation.RulePropertiesRequired(true)]
        public System.Drawing.Image company_logo
        {
            get { return fcompany_logo; }
            set { SetPropertyValue<System.Drawing.Image>("company_logo", ref fcompany_logo, value); }
        }
    }

}