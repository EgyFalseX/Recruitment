using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("employer_company_name")]
    public partial class rec_Employer
    {
        public rec_Employer(Session session) : base(session) { }
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
        [Association(@"rec_Employer-PortfolioFileData")]
        public XPCollection<rec_PortfolioFileData_Emp> rec_Employer_rec_PortfolioFileData_Emp
        { get { return GetCollection<rec_PortfolioFileData_Emp>("rec_Employer_rec_PortfolioFileData_Emp"); } }
        byte[] femployer_logo;
        [Size(SizeAttribute.Unlimited)]
        [ImageEditor(DetailViewImageEditorFixedHeight = 128, DetailViewImageEditorFixedWidth = 128, ListViewImageEditorCustomHeight = 64, ImageSizeMode = ImageSizeMode.StretchImage)]
        public byte[] employer_logo
        {
            get { return femployer_logo; }
            set { SetPropertyValue<byte[]>("employer_logo", ref femployer_logo, value); }
        }
    }

}
