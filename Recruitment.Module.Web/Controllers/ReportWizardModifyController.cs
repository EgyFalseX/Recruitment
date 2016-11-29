using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2.Web;
using Recruitment.Module.Report;
using Recruitment.Module.Web.Report;


namespace Recruitment.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public class ReportWizardModifyController : ViewController
    {
        WebReportServiceController _reportServiceController;

        protected override void OnActivated()
        {
            base.OnActivated();
            _reportServiceController = Frame.GetController<WebReportServiceController>();
            _reportServiceController.NewReportWizardShowing += reportServiceController_NewXafReportWizardShowing;
        }
        void reportServiceController_NewXafReportWizardShowing(object sender,
        WebNewReportWizardShowingEventArgs e)
        {
            if (e.ReportDataType != typeof(ReportDataX)) return;
            ReportWizardParametersX newReportParamsObject = new ReportWizardParametersX(e.WizardParameters.Report,
                e.WizardParameters.ReportDataType) {ReportModule = "Custom Report"};
            e.WizardParameters = newReportParamsObject;
        }
        protected override void OnDeactivated()
        {
            _reportServiceController.NewReportWizardShowing -= reportServiceController_NewXafReportWizardShowing;
            _reportServiceController = null;
            base.OnDeactivated();
        }

    }
}
