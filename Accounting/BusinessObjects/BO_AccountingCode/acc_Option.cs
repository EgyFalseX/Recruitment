using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Accounting.BusinessObjects.Recruitment
{
    [ImageName("acc_Option16")]
    public partial class acc_Option
    {
        public acc_Option(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
