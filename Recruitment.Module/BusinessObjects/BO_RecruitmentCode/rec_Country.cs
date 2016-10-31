using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("country_name")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Country")]
    public partial class rec_Country
    {
        public rec_Country(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); rec_Citys.ListChanged += Rec_Citys_ListChanged; }

        private void Rec_Citys_ListChanged(object sender, ListChangedEventArgs e)
        {
            
            int inx = e.NewIndex;
            object obj = this.rec_Citys;
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

    }

}
