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

    public partial class acc_Nature : XPLiteObject
    {
        int facc_nature_id;
        [Key(true)]
        public int acc_nature_id
        {
            get { return facc_nature_id; }
            set { SetPropertyValue<int>("acc_nature_id", ref facc_nature_id, value); }
        }
        string facc_nature_name;
        [Size(50)]
        public string acc_nature_name
        {
            get { return facc_nature_name; }
            set { SetPropertyValue<string>("acc_nature_name", ref facc_nature_name, value); }
        }
        [Association(@"acc_AccountReferencesacc_Nature")]
        public XPCollection<acc_Account> acc_Accounts { get { return GetCollection<acc_Account>("acc_Accounts"); } }
    }

}