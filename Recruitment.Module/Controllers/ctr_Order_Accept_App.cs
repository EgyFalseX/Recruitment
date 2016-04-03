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

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_Order_Accept_App : ViewController
    {
        public ctr_Order_Accept_App()
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
        private void action_Order_Accept_App_Accept_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objSpc = Application.CreateObjectSpace();
            int ObjectToSave = 0;
            //DevExpress.Persistent.AuditTrail.AuditTrailService.Instance.EndSessionAudit(((DevExpress.ExpressApp.Xpo.XPObjectSpace)objSpc).Session);
            IList<rec_Applicant_Status> status = objSpc.GetObjects<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", (int)Core.Typez.enum_rec_Applicant_Status.Ready));
            if (status == null || status.Count == 0)
                return;

            foreach (var obj in e.SelectedObjects)
            {
                if (obj.GetType() != typeof(rec_Employer_Order_Detail_Suggest_Applicat))
                    continue;
                rec_Employer_Order_Detail_Suggest_Applicat Suggest = objSpc.GetObject<rec_Employer_Order_Detail_Suggest_Applicat>((rec_Employer_Order_Detail_Suggest_Applicat)obj);
                //check if exists
                IList< rec_Employer_Order_Detail_Accept_Applicat> exists = objSpc.GetObjects<rec_Employer_Order_Detail_Accept_Applicat>(new BinaryOperator("rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id", Suggest.rec_employer_order_detail_suggest_applicat_id));
                if (exists != null && exists.Count > 0)
                    continue;
                rec_Employer_Order_Detail_Accept_Applicat Accept = objSpc.CreateObject<rec_Employer_Order_Detail_Accept_Applicat>();
                Accept.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = Suggest;
                Accept.rec_employer_order_detail_accept_applicat_rec_applicant_status_id = status[0];
                ObjectToSave++;

            }
            objSpc.CommitChanges();
            //DevExpress.Persistent.AuditTrail.AuditTrailService.Instance.BeginSessionAudit(((DevExpress.ExpressApp.Xpo.XPObjectSpace)objSpc).Session, DevExpress.Persistent.AuditTrail.AuditTrailStrategy.OnObjectChanged);

        }
        private void action_Order_Accept_App_Refused_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

        }
    }
}
