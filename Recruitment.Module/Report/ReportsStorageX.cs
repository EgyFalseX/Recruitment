using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Security;
using DevExpress.XtraReports.UI;

namespace Recruitment.Module.Report
{
    public class ReportsStorageX : ReportsStorage
    {
        public override void SaveReport(IReportDataV2Writable reportData, XtraReport report)
        {
            ReportDataX reportDataX = reportData as ReportDataX;
            if (reportDataX != null)
            {
                var obj = reportDataX.PredefinedReportType;

                reportDataX.ReportModule = "Custom Reports";
                ISecurityUser currentUser = SecuritySystem.CurrentUser as ISecurityUser;
                if (currentUser != null) reportDataX.ModifiedBy = currentUser.UserName;
            }
            base.SaveReport(reportData, report);
        }
    }

}
