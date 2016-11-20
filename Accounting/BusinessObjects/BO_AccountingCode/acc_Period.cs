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
    [DevExpress.ExpressApp.DC.XafDisplayName("Period")]
    [DevExpress.Persistent.Base.ImageName("acc_Year16")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("period_name")]
    public partial class acc_Period
    {
        public acc_Period(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
