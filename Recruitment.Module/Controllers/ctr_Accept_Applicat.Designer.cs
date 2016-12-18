namespace Recruitment.Module.Controllers
{
    partial class ctr_Accept_Applicat
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
            this.actionStartActivity = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // actionStartActivity
            // 
            this.actionStartActivity.Caption = "Start Activity";
            this.actionStartActivity.Category = "Edit";
            this.actionStartActivity.ConfirmationMessage = "You select to start activity for this item, Are you sure";
            this.actionStartActivity.Id = "actionStartActivity";
            this.actionStartActivity.ImageName = "rec_Activity";
            this.actionStartActivity.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.actionStartActivity.TargetObjectsCriteria = "start_activity = false";
            this.actionStartActivity.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Accept_Applicat);
            this.actionStartActivity.ToolTip = null;
            this.actionStartActivity.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionStartActivity_Execute);
            // 
            // ctr_Accept_Applicat
            // 
            this.Actions.Add(this.actionStartActivity);
            this.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Accept_Applicat);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionStartActivity;
    }
}
