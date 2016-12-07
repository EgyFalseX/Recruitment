namespace Accounting.Report
{
    public partial class acc_Rep_Account_Journals_SubAcc : DevExpress.XtraReports.UI.XtraReport
    {
        public acc_Rep_Account_Journals_SubAcc()
        {
            InitializeComponent();

            DevExpress.XtraReports.Parameters.Parameter parameter = Parameters[DevExpress.ExpressApp.ReportsV2.ReportDataSourceHelper.XafReportParametersObjectName];
            if (parameter == null)
                return;

            Accounting.Report.RepParam_acc_Rep_Account_Journals_SubAcc param = (Accounting.Report.RepParam_acc_Rep_Account_Journals_SubAcc)parameter.Value;

            //Set header information
            xrTableCellFrom.Text = param.Startdate.ToShortDateString();
            xrTableCellTo.Text = param.Enddate.ToShortDateString();
            xrTableCellCategory.Text = param.Account.account_name;

            DevExpress.Xpo.Session session = ((DevExpress.ExpressApp.Xpo.XPObjectSpace)param.ObjectSpace).Session;

            DataSource = Accounting.BusinessObjects.Recruitment.SprocHelper.Execsp_acc_Account_Journals_SubAccIntoDataView(session,
                param.FiscalYear.year_id, param.Startdate, param.Enddate, param.Account.account_id);

        }
    }
}
