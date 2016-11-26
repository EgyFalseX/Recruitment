﻿using System;
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
    public partial class acc_Rep_liability_and_equity : DevExpress.XtraReports.UI.XtraReport
    {
        public acc_Rep_liability_and_equity()
        {
            InitializeComponent();
        }
        private void acc_Rep_liability_and_equity_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrPageInfoUser.Text = xrPageInfoUser.Text + " - App:" + SecuritySystem.CurrentUserName;

            DevExpress.XtraReports.Parameters.Parameter parameter =
                Parameters[DevExpress.ExpressApp.ReportsV2.ReportDataSourceHelper.XafReportParametersObjectName];
            if (parameter == null)
                return;

            RepParam_acc_Rep_liability_and_equity param = (RepParam_acc_Rep_liability_and_equity)parameter.Value;

            //Set header information
            xrTableCellYear.Text = param.FiscalYear.year_name;
            xrTableCellFrom.Text = param.Startdate.ToShortDateString();
            xrTableCellTo.Text = param.Enddate.ToShortDateString();
            xrTableCellCategory.Text = param.Cateogry.account_category_name;

            XPDataView ds = SprocHelper.Execsp_liability_and_equityIntoDataView(((XPObjectSpace)param.ObjectSpace).Session, param.FiscalYear.year_id,
               param.Startdate, param.Enddate, param.Cateogry.account_category_id);

            DataSource = ds;
        }
    }
}
