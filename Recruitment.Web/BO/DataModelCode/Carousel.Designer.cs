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

    public partial class Carousel : XPLiteObject
    {
        int fAutoId;
        [Key(true)]
        public int AutoId
        {
            get { return fAutoId; }
            set { SetPropertyValue<int>("AutoId", ref fAutoId, value); }
        }
        bool fEnabled;
        public bool Enabled
        {
            get { return fEnabled; }
            set { SetPropertyValue<bool>("Enabled", ref fEnabled, value); }
        }
        string fHeader;
        [Size(SizeAttribute.Unlimited)]
        public string Header
        {
            get { return fHeader; }
            set { SetPropertyValue<string>("Header", ref fHeader, value); }
        }
        string fImgPath;
        [Size(255)]
        public string ImgPath
        {
            get { return fImgPath; }
            set { SetPropertyValue<string>("ImgPath", ref fImgPath, value); }
        }
        int fSortNumber;
        public int SortNumber
        {
            get { return fSortNumber; }
            set { SetPropertyValue<int>("SortNumber", ref fSortNumber, value); }
        }
    }

}
