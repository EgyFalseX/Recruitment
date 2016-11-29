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

    public partial class acc_Journal_Entry : XPLiteObject
    {
        int fjour_entry_id;
        [Key(true)]
        [DevExpress.Xpo.DisplayName(@"ID")]
        public int jour_entry_id
        {
            get { return fjour_entry_id; }
            set { SetPropertyValue<int>("jour_entry_id", ref fjour_entry_id, value); }
        }
        DateTime fentry_date;
        [DevExpress.Xpo.DisplayName(@"Entry Date")]
        [DevExpress.Persistent.Validation.RuleRequiredField("acc_Journal_Entry_entry_date_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Enter A Date")]
        public DateTime entry_date
        {
            get { return fentry_date; }
            set { SetPropertyValue<DateTime>("entry_date", ref fentry_date, value); }
        }
        bool fclosed;
        [DevExpress.Xpo.DisplayName(@"Close Entry")]
        [DevExpress.Persistent.Validation.RuleRequiredField("acc_Journal_Entry_closed_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Closed")]
        public bool closed
        {
            get { return fclosed; }
            set { SetPropertyValue<bool>("closed", ref fclosed, value); }
        }
        string fvoucher_no;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Voucher number")]
        public string voucher_no
        {
            get { return fvoucher_no; }
            set { SetPropertyValue<string>("voucher_no", ref fvoucher_no, value); }
        }
        string fdescription;
        [Size(500)]
        [DevExpress.Xpo.DisplayName(@"Description")]
        public string description
        {
            get { return fdescription; }
            set { SetPropertyValue<string>("description", ref fdescription, value); }
        }
        string fentry_text;
        [DevExpress.Xpo.DisplayName(@"Entry text")]
        public string entry_text
        {
            get { return fentry_text; }
            set { SetPropertyValue<string>("entry_text", ref fentry_text, value); }
        }
        acc_Period fperiod_id;
        [Association(@"acc_Journal_EntryReferencesacc_Period")]
        [DevExpress.Xpo.DisplayName(@"Period")]
        [DevExpress.Persistent.Validation.RuleRequiredField("acc_Journal_Entry_period_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select A Period")]
        public acc_Period period_id
        {
            get { return fperiod_id; }
            set { SetPropertyValue<acc_Period>("period_id", ref fperiod_id, value); }
        }
        [DevExpress.Xpo.DisplayName(@"Journal Entry Details")]
        [Association(@"acc_Journal_Entry_DetailReferencesacc_Journal_Entry")]
        public XPCollection<acc_Journal_Entry_Detail> acc_Journal_Entry_Details { get { return GetCollection<acc_Journal_Entry_Detail>("acc_Journal_Entry_Details"); } }
    }

}
