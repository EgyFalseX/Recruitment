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
namespace Accounting.BusinessObjects.Recruitment
{

    public partial class acc_Option : XPLiteObject
    {
        string facc_option_name;
        [Key]
        [Size(50)]
        public string acc_option_name
        {
            get { return facc_option_name; }
            set { SetPropertyValue<string>("acc_option_name", ref facc_option_name, value); }
        }
        string facc_option_value;
        [Size(50)]
        public string acc_option_value
        {
            get { return facc_option_value; }
            set { SetPropertyValue<string>("acc_option_value", ref facc_option_value, value); }
        }
    }

}
