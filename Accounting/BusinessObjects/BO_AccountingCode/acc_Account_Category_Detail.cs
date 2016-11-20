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
    [DevExpress.ExpressApp.DC.XafDisplayName("Account Cateogry Details")]
    [DevExpress.Persistent.Base.ImageName("acc_Account_Category16")]
    
    public partial class acc_Account_Category_Detail
    {
        public acc_Account_Category_Detail(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
