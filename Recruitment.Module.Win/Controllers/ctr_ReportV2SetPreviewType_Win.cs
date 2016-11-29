using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.ReportsV2.Win;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Recruitment.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_ReportV2SetPreviewType_Win : WinReportsController
    {
        public ctr_ReportV2SetPreviewType_Win()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            Frame.GetController<ReportServiceController>().CreateCustomParametersDetailView += Ctr_ReportV2SetPreviewType_CreateCustomParametersDetailView;
        }
        private Type _currentReportType;
        protected override void ShowReportPreview(SimpleActionExecuteEventArgs args)
        {
            _currentReportType = ((IReportDataV2)args.CurrentObject).DataType;
            base.ShowReportPreview(args);

        }
        private void Ctr_ReportV2SetPreviewType_CreateCustomParametersDetailView(object sender, CreateCustomParametersDetailViewEventArgs e)
        {
            if (e.ReportParametersObject.GetType() == typeof(Module.Report.RepParamObjCri))
            {
                ((Module.Report.RepParamObjCri)e.ReportParametersObject).ReportType = _currentReportType;
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
