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
    [DevExpress.ExpressApp.DC.XafDisplayName("Cost center Balance Parameters")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113594.aspx.
    // ReSharper disable once InconsistentNaming
    public class RepParam_acc_Rep_Costcenter_Balance : ReportParametersObjectBase
    {
        public RepParam_acc_Rep_Costcenter_Balance(IObjectSpaceCreator provider) : base(provider)
        {
        }
        protected override IObjectSpace CreateObjectSpace()
        {return objectSpaceCreator.CreateObjectSpace(null);
        }

        public override CriteriaOperator GetCriteria()
        {
            //return CriteriaEditorHelper.GetCriteriaOperator("1=1", typeof(sp_Trial_BalanceResult), ObjectSpace);

            CriteriaOperator grpOp = null;
            grpOp = GroupOperator.And(new BetweenOperator("jour_entry_id.entry_date", Startdate, Enddate));
            grpOp = GroupOperator.And(grpOp, CriteriaOperator.Parse("costcenter_id IS NOT NULL"));

            return CriteriaEditorHelper.GetCriteriaOperator(grpOp.LegacyToString(), typeof(acc_Journal_Entry_Detail), ObjectSpace);

            //return CriteriaEditorHelper.GetCriteriaOperator(new BetweenOperator("jour_entry_id.entry_date", Startdate, Enddate).LegacyToString(), typeof(acc_Journal_Entry_Detail), ObjectSpace);
        }

        public override SortProperty[] GetSorting()
        {
            //SortProperty[] sorting = {new SortProperty("applicant_name", SortingDirection.Ascending)};
            SortProperty[] sorting = new SortProperty[0];
            return sorting;
        }

        private DateTime _startdate;
        [RuleRequiredField("RepParam_acc_Rep_Costcenter_Balance_Startdate_vld_req", DefaultContexts.Save, "From Date should not be empty!")]
        [System.ComponentModel.DisplayName("From Date")]
        public DateTime Startdate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        private DateTime _enddate;
        [RuleRequiredField("RepParam_acc_Rep_Costcenter_Balance_Enddate_vld_req", DefaultContexts.Save, "To Date should not be empty!")]
        [System.ComponentModel.DisplayName("To Date")]
        public DateTime Enddate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

    }

}
