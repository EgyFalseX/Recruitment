
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using System.Drawing;
using DevExpress.ExpressApp.Utils;

namespace Accounting.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("account_name")]
    [ImageName("acc_Account16")]

    public partial class acc_Account : ITreeNode, ITreeNodeImageProvider
    {
        public acc_Account(Session session) : base(session)
        {
            closed = false;
        }
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
        [NonPersistent]
        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Browsable(false)]
        public string Name => account_name;
        [NonPersistent]
        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Browsable(false)]
        public ITreeNode Parent => parent_account_id;
        [NonPersistent]
        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Browsable(false)]
        public IBindingList Children => acc_AccountCollection;
        public Image GetImage(out string imageName)
        {
            if (acc_AccountCollection != null && acc_AccountCollection.Count > 0)
                imageName = "Flowchart";
            else
                imageName = "BO_Product";
            return ImageLoader.Instance.GetImageInfo(imageName).Image;
        }

    }

}
