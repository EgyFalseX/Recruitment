using System;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.Validation;

namespace Recruitment.Module.Report
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113594.aspx.
    // ReSharper disable once InconsistentNaming
    public class RepParamObjCri : ReportParametersObjectBase
    {
        public RepParamObjCri(IObjectSpaceCreator provider) : base(provider)
        {
        }

        protected override IObjectSpace CreateObjectSpace()
        {return objectSpaceCreator.CreateObjectSpace(null);
        }

        public override CriteriaOperator GetCriteria()
        {
            return CriteriaEditorHelper.GetCriteriaOperator(string.IsNullOrEmpty(Criteria) ? "1 = 2" : Criteria, ReportType, ObjectSpace);
        }

        public override SortProperty[] GetSorting()
        {
            //SortProperty[] sorting = {new SortProperty("applicant_name", SortingDirection.Ascending)};
            SortProperty[] sorting = new SortProperty[0];
            return sorting;
        }
        private Type _reportType;
        [Browsable(false)]
        public Type ReportType {
            get { return _reportType; }
            set { _reportType = value; }
        }
        
        private string _criteria;
        [RuleRequiredField("Filter-Required", DefaultContexts.Save, "An Filter must be selected!")]
        [System.ComponentModel.DisplayName("Select Filter (required)")]
        [CriteriaOptions("ReportType"), Size(SizeAttribute.Unlimited)]
        public string Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }
    }

}
