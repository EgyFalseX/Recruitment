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

    public partial class rec_Doc_Info : XPLiteObject
    {
        int frec_doc_info_id;
        [Key(true)]
        public int rec_doc_info_id
        {
            get { return frec_doc_info_id; }
            set { SetPropertyValue<int>("rec_doc_info_id", ref frec_doc_info_id, value); }
        }
        string frec_doc_info_name;
        public string rec_doc_info_name
        {
            get { return frec_doc_info_name; }
            set { SetPropertyValue<string>("rec_doc_info_name", ref frec_doc_info_name, value); }
        }
        [Association(@"rec_Industry_Require_Doc_InfoReferencesrec_Doc_Info")]
        public XPCollection<rec_Industry_Require_Doc_Info> rec_Industry_Require_Doc_Infos { get { return GetCollection<rec_Industry_Require_Doc_Info>("rec_Industry_Require_Doc_Infos"); } }
    }

}