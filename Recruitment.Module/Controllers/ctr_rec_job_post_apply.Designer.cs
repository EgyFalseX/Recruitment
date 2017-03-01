namespace Recruitment.Module.Controllers
{
    partial class ctr_rec_job_post_apply
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.actionTransferApplicant = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // actionTransferApplicant
            // 
            this.actionTransferApplicant.Caption = "Transfer Applicant";
            this.actionTransferApplicant.ConfirmationMessage = "You select to transfer those applicant, Are you sure";
            this.actionTransferApplicant.Id = "actionTransferApplicant";
            this.actionTransferApplicant.ImageName = "actionTransferApplicant";
            this.actionTransferApplicant.TargetObjectsCriteria = "applicant_id is null";
            this.actionTransferApplicant.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_job_post_apply);
            this.actionTransferApplicant.ToolTip = "Transfer online applied person into applicant";
            this.actionTransferApplicant.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionTransferApplicant_Execute);
            // 
            // ctr_rec_job_post_apply
            // 
            this.Actions.Add(this.actionTransferApplicant);
            this.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_job_post_apply);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionTransferApplicant;
    }
}
