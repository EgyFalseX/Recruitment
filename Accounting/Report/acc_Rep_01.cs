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
using DevExpress.XtraRichEdit.Model;

namespace Accounting.Report
{
    public partial class acc_Rep_01 : DevExpress.XtraReports.UI.XtraReport
    {
        public acc_Rep_01()
        {
            InitializeComponent();
        }

        private void acc_Rep_Trial_Balance_DataSourceDemanded(object sender, EventArgs e)
        {

            if (Parameters.Count == 0)
                return;

            RepParam_acc_Rep_01 param = (RepParam_acc_Rep_01)Parameters[0].RawValue;

            //Set header information
            xrTableCellYear.Text = param.FiscalYear.year_name;
            xrTableCellFrom.Text = param.Startdate.ToShortDateString();
            xrTableCellTo.Text = param.Enddate.ToShortDateString();
            xrTableCellAccount.Text = param.Account.account_name;

            XPDataView ds = SprocHelper.Execsp_acc_01IntoDataView(((XPObjectSpace)param.ObjectSpace).Session, param.FiscalYear.year_id,
                param.Startdate, param.Enddate, param.Account.account_id);

            DataSource = ds;

        }
    }
}
