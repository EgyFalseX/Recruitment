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

    public partial class rec_DocSrv_Order_Detail : XPLiteObject
    {
        int fdocsrv_order_detail;
        [Key(true)]
        [DevExpress.Xpo.DisplayName(@"ID")]
        public int docsrv_order_detail
        {
            get { return fdocsrv_order_detail; }
            set { SetPropertyValue<int>("docsrv_order_detail", ref fdocsrv_order_detail, value); }
        }
        rec_DocSrv_Order fdocsrv_order_id;
        [Association(@"rec_DocSrv_Order_DetailReferencesrec_DocSrv_Order")]
        [DevExpress.Xpo.DisplayName(@"Document Service Order")]
        public rec_DocSrv_Order docsrv_order_id
        {
            get { return fdocsrv_order_id; }
            set { SetPropertyValue<rec_DocSrv_Order>("docsrv_order_id", ref fdocsrv_order_id, value); }
        }
        rec_Doc_Info frec_doc_info_id;
        [Association(@"rec_DocSrv_Order_DetailReferencesrec_Doc_Info")]
        [DevExpress.Xpo.DisplayName(@"Document")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_DocSrv_Order_Detail_rec_doc_info_id_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Select Document")]
        public rec_Doc_Info rec_doc_info_id
        {
            get { return frec_doc_info_id; }
            set { SetPropertyValue<rec_Doc_Info>("rec_doc_info_id", ref frec_doc_info_id, value); }
        }
        DateTime freceive_date;
        [DevExpress.Xpo.DisplayName(@"Receive Date")]
        public DateTime receive_date
        {
            get { return freceive_date; }
            set { SetPropertyValue<DateTime>("receive_date", ref freceive_date, value); }
        }
        string fdoc_owner;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Document Owner Name")]
        public string doc_owner
        {
            get { return fdoc_owner; }
            set { SetPropertyValue<string>("doc_owner", ref fdoc_owner, value); }
        }
        DateTime fdelivered_date;
        [DevExpress.Xpo.DisplayName(@"Delivered Date")]
        public DateTime delivered_date
        {
            get { return fdelivered_date; }
            set { SetPropertyValue<DateTime>("delivered_date", ref fdelivered_date, value); }
        }
        string frecipient_name;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Recipient Name")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_DocSrv_Order_Detail_recipient_name_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Enter Recipient Name")]
        public string recipient_name
        {
            get { return frecipient_name; }
            set { SetPropertyValue<string>("recipient_name", ref frecipient_name, value); }
        }
        string frecipient_mobile;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Recipient Mobile")]
        [DevExpress.Persistent.Validation.RuleRequiredField("rec_DocSrv_Order_Detail_recipient_mobile_vld_req", DevExpress.Persistent.Validation.DefaultContexts.Save, "Please Enter Recipient Mobile")]
        public string recipient_mobile
        {
            get { return frecipient_mobile; }
            set { SetPropertyValue<string>("recipient_mobile", ref frecipient_mobile, value); }
        }
        string frecipient_phone;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Recipient Phone")]
        public string recipient_phone
        {
            get { return frecipient_phone; }
            set { SetPropertyValue<string>("recipient_phone", ref frecipient_phone, value); }
        }
        string fnotes;
        [Size(1000)]
        [DevExpress.Xpo.DisplayName(@"Notes")]
        public string notes
        {
            get { return fnotes; }
            set { SetPropertyValue<string>("notes", ref fnotes, value); }
        }
        bool fdelivered;
        [DevExpress.Xpo.DisplayName(@"Delivered")]
        public bool delivered
        {
            get { return fdelivered; }
            set { SetPropertyValue<bool>("delivered", ref fdelivered, value); }
        }
        [DevExpress.Xpo.DisplayName(@"Document Services")]
        [Association(@"rec_DocSrv_Order_Detail_SrvReferencesrec_DocSrv_Order_Detail")]
        public XPCollection<rec_DocSrv_Order_Detail_Srv> rec_DocSrv_Order_Detail_Srvs { get { return GetCollection<rec_DocSrv_Order_Detail_Srv>("rec_DocSrv_Order_Detail_Srvs"); } }
    }

}