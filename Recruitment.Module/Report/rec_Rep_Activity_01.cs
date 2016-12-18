using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;

namespace Recruitment.Module.Report
{
    public partial class rec_Rep_Activity_01 : DevExpress.XtraReports.UI.XtraReport
    {
        public rec_Rep_Activity_01()
        {
            InitializeComponent();
            //            dsMain.CriteriaString = @"[year_id.year_id] = ?paramYear And [entry_date] Between(?paramStartDate, ?paramEndDate) And 
            //([acc_Journal_Entry_Details][[account_id.account_id] In(?paramAccount) )";//Or[account_id.parent_account_id.account_id] In(?paramAccount)]

            


        }

    }
}
