using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("city_name")]
    [DevExpress.ExpressApp.DC.XafDisplayName("City")]
    //[DefaultProperty("city_name")]
    public partial class rec_City
    {
        public rec_City(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            //Session.ObjectSaving += Session_ObjectSaving;
        }
        private void Session_ObjectSaving(object sender, ObjectManipulationEventArgs e)
        {
            //rec_City item = (rec_City)e.Object;
            //object userid = SecuritySystem.CurrentUserId;
            //DateTime datetime = Core.SqlOp.GetServerDateTime(Session);

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
                }
                return auditTrail;
            }
        }
        protected override void OnDeleting()
        {
            //Deleting Audit when deleting the object
            if (!(Session is NestedUnitOfWork))
            {
                AuditedObjectWeakReference auditObjectWr = Session.FindObject<AuditedObjectWeakReference>(
                    new GroupOperator(
                        new BinaryOperator("TargetType", Session.GetObjectType(this)),
                        new BinaryOperator("TargetKey",
                            AuditedObjectWeakReference.KeyToString(Session.GetKeyValue(this)))
                        ));
                for (int i = auditObjectWr.AuditDataItems.Count - 1; i >= 0; i--)
                    auditObjectWr.AuditDataItems[i].Delete();
                auditObjectWr.Delete();
            }
            base.OnDeleting();
        }
    }

}
