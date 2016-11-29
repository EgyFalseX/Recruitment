using System;
using System.ComponentModel;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.Validation;

namespace Accounting.Report
{
    [DomainComponent]
    [DevExpress.ExpressApp.DC.XafDisplayName("Trial Balance Parameters")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113594.aspx.
    // ReSharper disable once InconsistentNaming
    public class RepParam_acc_Rep_Trial_Balance : ReportParametersObjectBase
    {
        public RepParam_acc_Rep_Trial_Balance(IObjectSpaceCreator provider) : base(provider)
        {
        }
        protected override IObjectSpace CreateObjectSpace()
        {return objectSpaceCreator.CreateObjectSpace(null);
        }

        public override CriteriaOperator GetCriteria()
        {
            //CriteriaOperator grpOp = null;
            //grpOp = GroupOperator.And(grpOp, CriteriaOperator.Parse("[account_category_id.account_category_id] = ?", _cateogry.account_category_id));
            //grpOp = GroupOperator.And(grpOp, CriteriaOperator.Parse("[account_id.acc_Journal_Entry_Details][[jour_entry_id.year_id.year_id] = ?]", _fiscalyear.year_id));
            //grpOp = GroupOperator.And(grpOp, CriteriaOperator.Parse("[account_id.acc_Journal_Entry_Details][[jour_entry_id.entry_date] Between(?, ?)]", _startdate, _enddate));
            //grpOp = GroupOperator.And(grpOp, CriteriaOperator.Parse("[account_id.acc_Journal_Entry_Details][[jour_entry_id.closed] = True]"));
            //return CriteriaEditorHelper.GetCriteriaOperator(grpOp.LegacyToString(), typeof(sp_Trial_BalanceResult), ObjectSpace);


            //string param = "account_name='" + _fiscalyear.year_id + "; " + _startdate.ToShortDateString() + ";" + _enddate.ToShortDateString() + ";" +
            //               _cateogry.account_category_id + "'";
            
            
            return CriteriaEditorHelper.GetCriteriaOperator("1=1", typeof(sp_Trial_BalanceResult), ObjectSpace);
        }

        public override SortProperty[] GetSorting()
        {
            //SortProperty[] sorting = {new SortProperty("applicant_name", SortingDirection.Ascending)};
            SortProperty[] sorting = new SortProperty[0];
            return sorting;
        }

        private acc_Year _fiscalyear;
        [RuleRequiredField("RepParamacc_Journal_Entry_01_FiscalYear_vld_req", DefaultContexts.Save, "Fiscal Year should not be empty!")]
        [System.ComponentModel.DisplayName("Fiscal Year")]
        public acc_Year FiscalYear
        {
            get { return _fiscalyear; }
            set { _fiscalyear = value; }
        }

        private DateTime _startdate;
        [RuleRequiredField("RepParamacc_Journal_Entry_01_Startdate_vld_req", DefaultContexts.Save, "From Date should not be empty!")]
        [System.ComponentModel.DisplayName("From Date")]
        public DateTime Startdate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        private DateTime _enddate;
        [RuleRequiredField("RepParamacc_Journal_Entry_01_Enddate_vld_req", DefaultContexts.Save, "To Date should not be empty!")]
        [System.ComponentModel.DisplayName("To Date")]
        public DateTime Enddate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

        private acc_Account_Category _cateogry;
        [RuleRequiredField("RepParamacc_Journal_Entry_01_Cateogry_vld_req", DefaultContexts.Save, "Cateogry should not be empty!")]
        [System.ComponentModel.DisplayName("Cateogry")]
        public acc_Account_Category Cateogry
        {
            get { return _cateogry; }
            set { _cateogry = value; }
        }

    }

}
