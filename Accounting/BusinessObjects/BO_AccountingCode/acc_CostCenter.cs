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
    [DevExpress.ExpressApp.DC.XafDisplayName("Cost Center")]
    [DevExpress.Persistent.Base.ImageName("acc_CostCenter")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("costcenter_name")]
    public partial class acc_CostCenter
    {
        public acc_CostCenter(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
