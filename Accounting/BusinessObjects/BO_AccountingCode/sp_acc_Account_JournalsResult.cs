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

    [NonPersistent]
    public partial class sp_acc_Account_JournalsResult
    {
        public string entry_text { get; set; }
        public string costcenter_name { get; set; }
        public string account_name { get; set; }
        public DateTime entry_date { get; set; }
        public string voucher_no { get; set; }
        public int factor { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        public double Balance { get; set; }
    }

}
