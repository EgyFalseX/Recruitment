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
    public partial class acc_Rep_Account_Journals : DevExpress.XtraReports.UI.XtraReport
    {
        public acc_Rep_Account_Journals()
        {
            InitializeComponent();
        }

        private void acc_Rep_Trial_Balance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrPageInfoUser.Text = xrPageInfoUser.Text + " - App:" + SecuritySystem.CurrentUserName;

            DevExpress.XtraReports.Parameters.Parameter parameter =
                Parameters[DevExpress.ExpressApp.ReportsV2.ReportDataSourceHelper.XafReportParametersObjectName];
            if (parameter == null)
                return;


            RepParam_acc_Rep_Account_Journals param = (RepParam_acc_Rep_Account_Journals)parameter.Value;

            //Set header information
            xrTableCellFrom.Text = param.Startdate.ToShortDateString();
            xrTableCellTo.Text = param.Enddate.ToShortDateString();
            xrTableCellCategory.Text = param.Account.account_name;

            Session session = ((XPObjectSpace)param.ObjectSpace).Session;

            SelectedData selectedData = SprocHelper.Execsp_acc_Account_Journals(session,
                param.Startdate, param.Enddate, param.Account.account_id);

            XPDataView ds = new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_Account_JournalsResult)), selectedData);

            DataSource = ds;
        }
    }
}
