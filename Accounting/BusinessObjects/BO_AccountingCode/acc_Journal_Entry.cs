using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;

namespace Accounting.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("JournalCaption")]
    [ImageName("acc_Journal_Entry32")]
    [Appearance("Entry_Closed", TargetItems = "*", Criteria = "closed = true ", Enabled = false, Priority = 0)]
    [Appearance("Entry_Closed_Must_Disabled", TargetItems = "closed", Criteria = "true = true", Enabled = false, Priority = 1)]
    [Appearance("Entry_Closed_Color_Open", TargetItems = "*", Criteria = "closed = false", Context = "ListView", FontColor = "Blue", Priority = 2)]
    [Appearance("Entry_Color_Unbalanced", TargetItems = "*", Criteria = "[acc_Journal_Entry_Details][].Sum([debit]) <> [acc_Journal_Entry_Details][].Sum([credit])", Context = "ListView", FontColor = "Red", Priority = 3)]
    public partial class acc_Journal_Entry{public acc_Journal_Entry(Session session) : base(session) { }public override void AfterConstruction() { base.AfterConstruction();
            closed = false;
        }
        //Audit Trail
        private XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> auditTrail;public XPCollection<DevExpress.Persistent.BaseImpl.AuditDataItemPersistent> AuditTrail
        {get
            {
                if (auditTrail == null)
                {
                    auditTrail = DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }return auditTrail;
            }
        }
        [NonPersistent]public string JournalCaption => $"{fjour_entry_id} - {fentry_text}";
    }

}
