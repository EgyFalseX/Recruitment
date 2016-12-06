namespace Accounting.Controllers
{
    partial class ctr_Journal_Entry_Closed
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
            this.act_Closed = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.act_Refund = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // act_Closed
            // 
            this.act_Closed.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.act_Closed.Caption = "Close Entry";
            this.act_Closed.Category = "Edit";
            this.act_Closed.ConfirmationMessage = "You are about to closed Entries, Are you sure you want to continue?";
            this.act_Closed.Id = "SetEntryClosed";
            this.act_Closed.ImageName = "Action_Grant";
            this.act_Closed.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.act_Closed.TargetObjectType = typeof(Accounting.BusinessObjects.Recruitment.acc_Journal_Entry);
            this.act_Closed.ToolTip = null;
            this.act_Closed.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.act_Closed_Execute);
            // 
            // act_Refund
            // 
            this.act_Refund.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.act_Refund.Caption = "Refund";
            this.act_Refund.Category = "Edit";
            this.act_Refund.ConfirmationMessage = "You are about to refund Entry, Are you sure you want to continue?";
            this.act_Refund.Id = "SetEntryRefund";
            this.act_Refund.ImageName = "Action_StateMachine";
            this.act_Refund.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.act_Refund.TargetObjectType = typeof(Accounting.BusinessObjects.Recruitment.acc_Journal_Entry);
            this.act_Refund.ToolTip = null;
            this.act_Refund.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.act_Refund_Execute);
            // 
            // ctr_Journal_Entry_Closed
            // 
            this.Actions.Add(this.act_Closed);
            this.Actions.Add(this.act_Refund);
            this.TargetObjectType = typeof(Accounting.BusinessObjects.Recruitment.acc_Journal_Entry);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction act_Closed;
        private DevExpress.ExpressApp.Actions.SimpleAction act_Refund;
    }
}
