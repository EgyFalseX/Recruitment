using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ServiceModel;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraRichEdit.Model;

namespace Accounting.Report
{
    public partial class acc_Rep_01 : DevExpress.XtraReports.UI.XtraReport
    {
        public acc_Rep_01()
        {
            InitializeComponent();
        }

        private void acc_Rep_01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DevExpress.XtraReports.Parameters.Parameter parameter =
                Parameters[DevExpress.ExpressApp.ReportsV2.ReportDataSourceHelper.XafReportParametersObjectName];
            if (parameter == null)
                return;

            RepParam_acc_Rep_01 param = (RepParam_acc_Rep_01)parameter.Value;

            //Set header information
            xrTableCellYear.Text = param.FiscalYear.year_name;
            xrTableCellFrom.Text = param.Startdate.ToShortDateString();
            xrTableCellTo.Text = param.Enddate.ToShortDateString();
            xrTableCellAccount.Text = param.Account.account_name;


            Session session = ((XPObjectSpace)param.ObjectSpace).Session;

            SelectedData selectedData = SprocHelper.Execsp_acc_01(session,
                param.FiscalYear.year_id,
                param.Startdate, param.Enddate, param.Account.account_id);

            XPDataView ds = new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_01Result)), selectedData);

            DataSource = ds;

        }
    }
}
