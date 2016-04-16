using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    public partial class rec_Employer_Order
    {
        public rec_Employer_Order(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        Core.Typez.enum_rec_Employer_Order_Status frec_employer_order_rec_employer_order_status_id;
        //[Association(@"rec_Employer_OrderReferencesrec_Employer_Order_Status")]
        public Core.Typez.enum_rec_Employer_Order_Status rec_employer_order_rec_employer_order_status_id
        {
            get { return frec_employer_order_rec_employer_order_status_id; }
            set { SetPropertyValue<Core.Typez.enum_rec_Employer_Order_Status>("rec_employer_order_rec_employer_order_status_id", ref frec_employer_order_rec_employer_order_status_id, value); }
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
        [NonPersistent]
        public string CustomName
        {
            get
            {
                if (rec_employer_order_employer_id != null)
                {
                    return string.Format("{0} - {1}", frec_employer_order_id, rec_employer_order_employer_id.employer_company_name);
                }
                else
                {
                    return string.Format("{0}", frec_employer_order_id);

                }
                
            }
        }
        [NonPersistent]
        [EditorAlias("ProgressProperty")]
        public double Progress
        {
            get
            {
                double order_Percent = 0;
                if (rec_Employer_Order_Details != null)
                {
                    foreach (rec_Employer_Order_Detail detail in rec_Employer_Order_Details)
                        order_Percent += detail.Progress;
                    return order_Percent / (rec_Employer_Order_Details.Count == 0 ? 1 : rec_Employer_Order_Details.Count);
                }
                else
                    return 0;
            }
        }
    }

}
