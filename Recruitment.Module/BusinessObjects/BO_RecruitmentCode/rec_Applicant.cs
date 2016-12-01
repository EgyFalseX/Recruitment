using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Validation;
using Recruitment.Module.Core;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    //[NavigationItem("Data Entry")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("applicant_name")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Applicant")]
    [RuleObjectExists(
     "MyObject.Exists", DefaultContexts.Save
     ,
        @"([applicant_id]<>'@applicant_id')
        AND (applicant_mobile = '@applicant_mobile' OR applicant_mobile2 = '@applicant_mobile' OR applicant_mobile = '@applicant_mobile2' OR applicant_mobile2 = '@applicant_mobile2')
        ", "Mobile or Mobile 2 Already Exist"
     , CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction
     , InvertResult = true
     , LooksFor = typeof(rec_Applicant)
     , SkipNullOrEmptyValues = false
     )
 ]
    public partial class rec_Applicant
    {
        public rec_Applicant(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction(); 
            this.applicant_rec_applicant_status_id = Typez.enum_rec_Applicant_Status.Ready;
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
        [Association(@"rec_Applicant-PortfolioFileData")]
        public XPCollection<rec_PortfolioFileData> rec_Applicant_rec_PortfolioFileData
        { get { return GetCollection<rec_PortfolioFileData>("rec_Applicant_rec_PortfolioFileData"); } }
        Typez.enum_rec_Applicant_Status fapplicant_rec_applicant_status_id;
        [Indexed(Name = @"iapplicant_rec_applicant_status_id_rec_Applicant")]
        //[Association(@"rec_ApplicantReferencesrec_Applicant_Status")]
        public Typez.enum_rec_Applicant_Status applicant_rec_applicant_status_id
        {
            get { return fapplicant_rec_applicant_status_id; }
            set { SetPropertyValue<Typez.enum_rec_Applicant_Status>("applicant_rec_applicant_status_id", ref fapplicant_rec_applicant_status_id, value); }
        }
        //byte[] frec_Applicant_image;
        //[Size(SizeAttribute.Unlimited)]
        //[ImageEditor(DetailViewImageEditorFixedHeight = 64, DetailViewImageEditorFixedWidth = 64, ListViewImageEditorCustomHeight = 64, ImageSizeMode = ImageSizeMode.Zoom)]
        //public byte[] rec_Applicant_image
        //{
        //    get { return frec_Applicant_image; }
        //    set { SetPropertyValue<byte[]>("rec_Applicant_image", ref frec_Applicant_image, value); }
        //}
    }

}
