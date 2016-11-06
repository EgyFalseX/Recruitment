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
    public partial class acc_Rep_Trial_Balance : DevExpress.XtraReports.UI.XtraReport
    {
        public acc_Rep_Trial_Balance()
        {
            InitializeComponent();
        }

        private void acc_Rep_Trial_Balance_DataSourceDemanded(object sender, EventArgs e)
        {
            //xrPageInfoUser.Text = xrPageInfoUser.Text + " - App:" + SecuritySystem.CurrentUserName;

            if (Parameters.Count == 0)
                return;

            RepParam_acc_Rep_Trial_Balance param = (RepParam_acc_Rep_Trial_Balance) Parameters[0].RawValue;

            //Set header information
            xrTableCellYear.Text = param.FiscalYear.year_name;
            xrTableCellFrom.Text = param.Startdate.ToShortDateString();
            xrTableCellTo.Text = param.Enddate.ToShortDateString();
            xrTableCellCategory.Text = param.Cateogry.account_category_name;

            XPDataView ds = SprocHelper.Execsp_Trial_BalanceIntoDataView(((XPObjectSpace)param.ObjectSpace).Session, param.FiscalYear.year_id,
                param.Startdate, param.Enddate, param.Cateogry.account_category_id);

            DataSource = ds;
            
        }
    }
}
