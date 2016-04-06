namespace Recruitment.Module.Controllers
{
    partial class ctr_Order_Accept_App
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
            this.action_Order_Accept_App_Accept = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.action_Order_Accept_App_Refused = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // action_Order_Accept_App_Accept
            // 
            this.action_Order_Accept_App_Accept.Caption = "Applicant Accepted";
            this.action_Order_Accept_App_Accept.Category = "Edit";
            this.action_Order_Accept_App_Accept.ConfirmationMessage = "You will add selected applicant(s) to accepted list, Are you sure?";
            this.action_Order_Accept_App_Accept.Id = "action_Order_Accept_App_Accept";
            this.action_Order_Accept_App_Accept.ImageName = "Action_Grant";
            this.action_Order_Accept_App_Accept.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Suggest_Applicat);
            this.action_Order_Accept_App_Accept.ToolTip = null;
            this.action_Order_Accept_App_Accept.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.action_Order_Accept_App_Accept_Execute);
            // 
            // action_Order_Accept_App_Refused
            // 
            this.action_Order_Accept_App_Refused.Caption = "Applicant Refused";
            this.action_Order_Accept_App_Refused.Category = "Edit";
            this.action_Order_Accept_App_Refused.ConfirmationMessage = "You will remove selected applicant(s) from accepted list, Are you sure?";
            this.action_Order_Accept_App_Refused.Id = "action_Order_Accept_App_Refused";
            this.action_Order_Accept_App_Refused.ImageName = "Action_Deny";
            this.action_Order_Accept_App_Refused.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Suggest_Applicat);
            this.action_Order_Accept_App_Refused.ToolTip = null;
            this.action_Order_Accept_App_Refused.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.action_Order_Accept_App_Refused_Execute);
            // 
            // ctr_Order_Accept_App
            // 
            this.Actions.Add(this.action_Order_Accept_App_Accept);
            this.Actions.Add(this.action_Order_Accept_App_Refused);
            this.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Suggest_Applicat);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction action_Order_Accept_App_Accept;
        private DevExpress.ExpressApp.Actions.SimpleAction action_Order_Accept_App_Refused;
    }
}
