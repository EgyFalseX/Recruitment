using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Security;
using DevExpress.XtraReports.UI;
using Recruitment.Module.Report;

namespace Recruitment.Module.Win.Report
{
    [DomainComponent]
    public class ReportWizardParametersX : NewReportWizardParameters
    {
        public ReportWizardParametersX(XtraReport report, Type reportDataType) : 
        base(report, reportDataType) { }
        public string ReportModule { get; set; }
        public override void AssignData(IReportDataV2Writable reportData)
        {
            base.AssignData(reportData);
            ReportDataX reportDataX = reportData as ReportDataX;
            if (reportDataX == null) return;
            reportDataX.ReportModule = ReportModule;
            ISecurityUser currentUser = SecuritySystem.CurrentUser as ISecurityUser;
            if (currentUser != null) reportDataX.ModifiedBy = currentUser.UserName;
        }

    }
}
