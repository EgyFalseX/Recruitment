namespace Recruitment.Module.Controllers
{
    partial class ctr_Order_Suggest_App
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
            this.action_SuggestedStatus = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // action_SuggestedStatus
            // 
            this.action_SuggestedStatus.Caption = "Change Status";
            this.action_SuggestedStatus.Category = "Edit";
            this.action_SuggestedStatus.ConfirmationMessage = "You will change status for selected applicant(s), Are you sure?";
            this.action_SuggestedStatus.Id = "action_Order_Suggest_App_Status_Changer";
            this.action_SuggestedStatus.ImageName = "Action_Grant_Set";
            this.action_SuggestedStatus.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.action_SuggestedStatus.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Suggest_Applicat);
            this.action_SuggestedStatus.ToolTip = null;
            this.action_SuggestedStatus.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.action_SuggestedStatus_Execute);
            // 
            // ctr_Order_Suggest_App
            // 
            this.Actions.Add(this.action_SuggestedStatus);
            this.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Suggest_Applicat);

        }

        #endregion
        private DevExpress.ExpressApp.Actions.SingleChoiceAction action_SuggestedStatus;
    }
}
