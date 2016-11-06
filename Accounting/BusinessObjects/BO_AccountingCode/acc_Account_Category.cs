using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Accounting.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Accounting")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Account Cateogry")]
    [DevExpress.Persistent.Base.ImageName("acc_Account_Category32")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("account_category_name")]
    public partial class acc_Account_Category
    {
        public acc_Account_Category(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
