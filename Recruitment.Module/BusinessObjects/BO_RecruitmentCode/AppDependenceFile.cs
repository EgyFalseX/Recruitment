using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Recruitment.Module.BusinessObjects.Recruitment
{

    public partial class AppDependenceFile
    {
        public AppDependenceFile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
