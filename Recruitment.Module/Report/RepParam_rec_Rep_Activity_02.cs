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
using Recruitment.Module.BusinessObjects.Recruitment;

namespace Recruitment.Module.Report
{
    [DomainComponent]
    [DevExpress.ExpressApp.DC.XafDisplayName("Employer Activity Parameters")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113594.aspx.
    // ReSharper disable once InconsistentNaming
    public class RepParam_rec_Rep_Activity_02 : ReportParametersObjectBase
    {
        public RepParam_rec_Rep_Activity_02(IObjectSpaceCreator provider) : base(provider)
        {
        }
        protected override IObjectSpace CreateObjectSpace()
        {return objectSpaceCreator.CreateObjectSpace(null);
        }

        public override CriteriaOperator GetCriteria()
        {
            return CriteriaEditorHelper.GetCriteriaOperator("1=1", typeof(sp_Trial_BalanceResult), ObjectSpace);
        }

        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = {new SortProperty("entry_date", SortingDirection.Ascending)};
            //SortProperty[] sorting = new SortProperty[0];
            return sorting;
        }

        private rec_Employer _employer;
        //[RuleRequiredField("RepParam_rec_Rep_Activity_02_Employer_vld_req", DefaultContexts.Save, "Employer should not be empty!")]
        [System.ComponentModel.DisplayName("Employer")]
        public rec_Employer Employer
        {
            get { return _employer; }
            set { _employer = value; }
        }
        private rec_Applicant _applicant;
        [System.ComponentModel.DisplayName("Applicant")]
        public rec_Applicant Applicant
        {
            get { return _applicant; }
            set { _applicant = value; }
        }

        private DateTime _startdate;
        [RuleRequiredField("RepParam_rec_Rep_Activity_02_Startdate_vld_req", DefaultContexts.Save, "From Date should not be empty!")]
        [System.ComponentModel.DisplayName("From Date")]
        public DateTime Startdate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        private DateTime _enddate;
        [RuleRequiredField("RepParam_rec_Rep_Activity_02_Enddate_vld_req", DefaultContexts.Save, "To Date should not be empty!")]
        [System.ComponentModel.DisplayName("To Date")]
        public DateTime Enddate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

    }

}
