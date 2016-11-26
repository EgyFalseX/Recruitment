using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Accounting.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("JournalCaption")]
    [ImageName("acc_Journal_Entry16")]
    [Appearance("Entry_period", TargetItems = "period_id", Criteria = "true = true ", Enabled = false, Priority = 0)]
    [Appearance("Entry_Closed", TargetItems = "*", Criteria = "closed = true ", Enabled = false, Priority = 1)]
    [Appearance("Entry_Closed_Must_Disabled", TargetItems = "closed", Criteria = "true = true", Enabled = false, Priority = 2)]
    [Appearance("Entry_Closed_Color_Open", TargetItems = "*", Criteria = "closed = false", Context = "ListView", FontColor = "Blue", Priority = 3)]
    [Appearance("Entry_Color_Unbalanced", TargetItems = "*", Criteria = "[acc_Journal_Entry_Details][].Sum([debit]) <> [acc_Journal_Entry_Details][].Sum([credit])", Context = "ListView", FontColor = "Red", Priority = 4)]
    [RuleCriteria("acc_Journal_Entry_period_id_vld_open", DefaultContexts.Save, "period_id.closed != true", "Selected date within closed period", SkipNullOrEmptyValues = false)]
    public partial class acc_Journal_Entry{public acc_Journal_Entry(Session session) : base(session) { }
        public override void AfterConstruction() {
            base.AfterConstruction();
            closed = false;
        }
        //Audit Trail
        private XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> auditTrail;
        public XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> AuditTrail
        {
            get
            {
                if (auditTrail == null)
                {
                    auditTrail = DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }return auditTrail;
            }
        }
        [NonPersistent]
        public string JournalCaption => $"{fjour_entry_id} - {fentry_text}";
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (IsLoading || oldValue == newValue || (propertyName != "entry_date")) return;
            acc_Period period = Session.FindObject<acc_Period>(CriteriaOperator.Parse("? BETWEEN (start_date, end_date)", newValue));
            if (period != null)
                period_id = period;
        }
    }

}
