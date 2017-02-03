using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    
    [DevExpress.ExpressApp.DC.XafDefaultProperty("activity_type_name")]
    [Appearance("ActionAccessPermission22", AppearanceItemType = "ViewItem", TargetItems = "*", Enabled = false, Criteria = "ActionId = 'a'")]

    public partial class rec_Activity_Type
    {
        public rec_Activity_Type(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
