using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Recruitment.Module.BusinessObjects.Recruitment;
using DevExpress.Xpo;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_Insert_Req_Doc : ViewController
    {
        public ctr_Insert_Req_Doc()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void action_Insert_Req_Doc_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (e.CurrentObject.GetType() != typeof(rec_Employer_Order_Detail_Accept_Applicat))
                return;
            IObjectSpace objSpc = Application.CreateObjectSpace();
            DevExpress.Persistent.AuditTrail.AuditTrailService.Instance.EndSessionAudit(((DevExpress.ExpressApp.Xpo.XPObjectSpace)objSpc).Session);
            
            rec_Employer_Order_Detail_Accept_Applicat item = objSpc.GetObject<rec_Employer_Order_Detail_Accept_Applicat>((rec_Employer_Order_Detail_Accept_Applicat)e.CurrentObject);
            int industry = item.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_industry_id.industry_id;
            IList<rec_Industry_Require_Doc_Info> Docs = objSpc.GetObjects<rec_Industry_Require_Doc_Info>(new BinaryOperator("rec_industry_require_doc_info_industry_id", industry));
            IList<rec_Require_Doc_Status> doc_status = objSpc.GetObjects<rec_Require_Doc_Status>(new BinaryOperator("rec_require_doc_status_id", 1));
            if (doc_status.Count == 0)
                return;
            foreach (rec_Industry_Require_Doc_Info doc_info in Docs)
            {
                rec_Employer_Order_Detail_Accept_Applicat_Doc doc = objSpc.CreateObject<rec_Employer_Order_Detail_Accept_Applicat_Doc>();
                doc.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_description = string.Empty;
                doc.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_industry_require_doc_info_id = doc_info;
                doc.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id = item;
                doc.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_require_doc_status_id = doc_status[0];
                //item.rec_Employer_Order_Detail_Accept_Applicat_Docs.Add(doc);
            }
            objSpc.CommitChanges();

            DevExpress.Persistent.AuditTrail.AuditTrailService.Instance.BeginSessionAudit(((DevExpress.ExpressApp.Xpo.XPObjectSpace)objSpc).Session, DevExpress.Persistent.AuditTrail.AuditTrailStrategy.OnObjectChanged);

        }
    }
}
