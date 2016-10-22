using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace Recruitment.Module.BusinessObjects.Recruitment
{
    [DefaultClassOptions]
    [ImageName("BO_FileAttachment")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class rec_PortfolioFileData_Emp : FileAttachmentBase
    {
        // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public rec_PortfolioFileData_Emp(Session session) : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            documentType = DocumentType.Unknown;
        }
        protected Recruitment.rec_Employer femployer_id;
        [Persistent, Association("rec_Employer-PortfolioFileData")]
        public Recruitment.rec_Employer employer_id
        {
            get { return femployer_id; }
            set
            {
                SetPropertyValue("applicant_id", ref femployer_id, value);
            }
        }
        private DocumentType documentType;
        public DocumentType DocumentType
        {
            get { return documentType; }
            set { SetPropertyValue("DocumentType", ref documentType, value); }
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
