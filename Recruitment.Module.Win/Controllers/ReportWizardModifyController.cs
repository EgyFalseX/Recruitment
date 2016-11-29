using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2.Win;
using Recruitment.Module.Report;
using Recruitment.Module.Win.Report;

namespace Recruitment.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public class ReportWizardModifyController : ViewController
    {
        WinReportServiceController _reportServiceController;

        protected override void OnActivated()
        {
            base.OnActivated();
            _reportServiceController = Frame.GetController<WinReportServiceController>();
            _reportServiceController.NewXafReportWizardShowing +=
                reportServiceController_NewXafReportWizardShowing;
        }
        void reportServiceController_NewXafReportWizardShowing(object sender,
        NewXafReportWizardShowingEventArgs e)
        {
            if (e.ReportDataType != typeof(ReportDataX)) return;
            ReportWizardParametersX newReportParamsObject = new ReportWizardParametersX(e.WizardParameters.Report,
                e.WizardParameters.ReportDataType) {ReportModule = "Custom Report"};
            e.WizardParameters = newReportParamsObject;
        }
        protected override void OnDeactivated()
        {
            _reportServiceController.NewXafReportWizardShowing -= reportServiceController_NewXafReportWizardShowing;
            _reportServiceController = null;
            base.OnDeactivated();
        }

    }
}
