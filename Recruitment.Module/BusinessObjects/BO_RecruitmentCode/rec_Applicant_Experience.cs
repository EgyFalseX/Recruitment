using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [Appearance("rec_Applicant_Experience_app_exp_end_date", TargetItems = "app_exp_end_date"
        , Visibility = ViewItemVisibility.Hide, Criteria = "app_exp_end_date_till_now", Context = "DetailView")]
    
    public partial class rec_Applicant_Experience
    {
        public rec_Applicant_Experience(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        //Audit Trail
        private XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> auditTrail;
        public XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> AuditTrail
        {
            get
            {
                if (auditTrail == null)
                {
                    auditTrail = DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return auditTrail;
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (!IsLoading && oldValue != newValue && (propertyName == "app_exp_end_date_till_now") && Convert.ToBoolean((newValue)))
            {
                app_exp_end_date = Core.SqlOp.GetServerDateTime(Session);            }
        }

    }

}
