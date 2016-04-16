using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Recruitment.Module.BusinessObjects.Recruitment
{

    public partial class rec_Employer_Industry
    {
        public rec_Employer_Industry(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
