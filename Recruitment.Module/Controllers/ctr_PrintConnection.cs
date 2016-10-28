using System;
using System.Collections;
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
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using Recruitment.Module.BusinessObjects.Recruitment;
using Recruitment.Module.Report;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_PrintConnection : ViewController
    {
        public ctr_PrintConnection()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated(){
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void act_PrintConnection_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (e.SelectedObjects.Count == 0)
                return;
            
            if (e.SelectedObjects.Count == 0)
                return;
            //string criteria = "[Order Connection][[ID] In (";
            //string criteria = "[rec_Employer_Order_Detail_Connection_Details][[rec_Employer_Order_Detail_Connection_Details.rec_employer_order_detail_connection_id] In (";
            string criteria = "[rec_Employer_Order_Detail_Connection_Details][[rec_employer_order_detail_connection_id.rec_employer_order_detail_connection_id] In (";
            foreach (rec_Employer_Order_Detail_Connection recEmployerOrderDetailConnection in e.SelectedObjects)
            {
                criteria += recEmployerOrderDetailConnection.rec_employer_order_detail_connection_id + ",";
            }
            criteria = criteria.Substring(0, criteria.Length - 1) + ")]";

            IObjectSpace objectSpace = ReportDataProvider.ReportObjectSpaceProvider.CreateObjectSpace(typeof(ReportDataV2));
            IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(CriteriaOperator.Parse("[DisplayName] = 'Applicant Information'"));
            string handle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData);Frame.GetController<ReportServiceController>().ShowPreview(handle, CriteriaOperator.Parse(criteria));
            
        }
    }
}
