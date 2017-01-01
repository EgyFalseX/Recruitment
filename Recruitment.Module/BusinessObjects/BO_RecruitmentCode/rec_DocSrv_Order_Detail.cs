using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [NavigationItem("Document Service")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Document Service Order Detail")]
    [DevExpress.Persistent.Base.ImageName("rec_DocSrv_Order_Detail")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("rec_doc_info_id")]
    public partial class rec_DocSrv_Order_Detail
    {
        public rec_DocSrv_Order_Detail(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            freceive_date = Core.SqlOp.GetServerDateTime(Session);
            if (fdocsrv_order_id != null)
            {
                recipient_name = fdocsrv_order_id.person_name;
                recipient_mobile = fdocsrv_order_id.person_mobile;
                recipient_phone = fdocsrv_order_id.person_phone;
            }
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

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (IsLoading || oldValue == newValue || (propertyName != "docsrv_order_id")) return;
            if (recipient_name == null)
                recipient_name = fdocsrv_order_id.person_name;
            if (recipient_mobile == null)
                recipient_mobile = fdocsrv_order_id.person_mobile;
            if (recipient_phone == null)
                recipient_phone = fdocsrv_order_id.person_phone;
        }
        protected override void OnDeleting()
        {
            if (rec_DocSrv_Order_Detail_Srvs != null && rec_DocSrv_Order_Detail_Srvs.Count > 0)
                throw new Exception("Must delete services before delete the document");
            //foreach (rec_DocSrv_Order_Detail_Srv recDocSrvOrderDetailSrv in rec_DocSrv_Order_Detail_Srvs)
            //{
            //    if (recDocSrvOrderDetailSrv.jour_entry_id != null)
            //    {
            //        acc_Journal_Entry entry = Session.GetObjectByKey<acc_Journal_Entry>(recDocSrvOrderDetailSrv.jour_entry_id.jour_entry_id);
            //        entry.Delete();
            //        Session.Delete(entry);
            //    }
            //    if (recDocSrvOrderDetailSrv.jour_entry_id_Paid != null)
            //    {
            //        acc_Journal_Entry entryPaid = Session.GetObjectByKey<acc_Journal_Entry>(recDocSrvOrderDetailSrv.jour_entry_id_Paid.jour_entry_id);
            //        entryPaid.Delete();
            //        Session.Delete(entryPaid);
            //    }
            //}
            base.OnDeleting();
            //Session.CommitTransaction();
        }
    }
}
