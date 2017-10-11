using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Recruitment.Web.BO.Recruitment
{

    public partial class rec_job_post
    {
        public rec_job_post(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
