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
namespace Recruitment.Web.BO.Recruitment
{

    public partial class Symbol : XPLiteObject
    {
        string fSymbol1;
        [Key]
        [Size(255)]
        [Persistent(@"Symbol")]
        public string Symbol1
        {
            get { return fSymbol1; }
            set { SetPropertyValue<string>("Symbol1", ref fSymbol1, value); }
        }
        [Association(@"ServiceReferencesSymbol")]
        public XPCollection<Service> Services { get { return GetCollection<Service>("Services"); } }
    }

}