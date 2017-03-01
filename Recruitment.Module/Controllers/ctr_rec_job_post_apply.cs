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
    public partial class ctr_rec_job_post_apply : ViewController
    {
        public ctr_rec_job_post_apply()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            View.SelectionChanged += View_SelectionChanged;
        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
            ctr_rec_job_post_apply ctr = Frame.GetController<ctr_rec_job_post_apply>();
            if (View.SelectedObjects.Count == 0 || ctr == null)
            {
                actionTransferApplicant.Active.SetItemValue("No item selected", false);
                return;
            }
            IObjectSpace objSpc = Application.CreateObjectSpace();
            bool Active = true;
            foreach (rec_job_post_apply item in View.SelectedObjects)
            {
                if (item.applicant_id != null)
                {
                    Active = false;
                    break;
                }
            }
            ctr.Active["Deactivation in code"] = Active;
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
            //View.SelectionChanged -= View_SelectionChanged;
        }

        private void actionTransferApplicant_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var selectedItems = e.SelectedObjects;
            if (selectedItems.Count == 0)
                return;

            IObjectSpace objectSpace = Application.CreateObjectSpace();

            foreach (rec_job_post_apply apply in selectedItems)
            {
                rec_Applicant applicant = objectSpace.CreateObject<rec_Applicant>();
                applicant.applicant_name = apply.apply_name;
                applicant.applicant_gender_id = objectSpace.GetObject(apply.apply_gender_id);
                applicant.applicant_mobile = apply.apply_mobile;
                applicant.applicant_nationality_id = objectSpace.GetObject(apply.apply_nationality_id);
                applicant.applicant_rec_applicant_status_id = Core.Typez.enum_rec_Applicant_Status.Ready;
                if (apply.attach_file != null)
                {
                    rec_PortfolioFileData attach = objectSpace.CreateObject<rec_PortfolioFileData>();
                    attach.applicant_id = applicant;
                    attach.DocumentType = DocumentType.Unknown;
                    attach.File = objectSpace.GetObject(apply.attach_file);
                }
                //edit applicant_id within apply recored
                objectSpace.GetObject(apply).applicant_id = objectSpace.GetObject(applicant);
            }
            objectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }
    }
}
