using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Recruitment.Module.Report
{
    [System.ComponentModel.DisplayName("Reports")]
    [NavigationItem("Reports")]
    public class ReportDataX : ReportDataV2
    {
        public ReportDataX(Session session) : base(session) { }
        private string _reportModule;
        public string ReportModule
        {
            get { return _reportModule; }
            set { SetPropertyValue("ReportModule", ref _reportModule, value); }
        }

        private string _modifiedBy;
        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set { SetPropertyValue<string>("ModifiedBy ", ref _modifiedBy, value); }
        }

    }
}
 