namespace ControllerManagement.Module.Controllers
{
    partial class ControllerSettingsViewController
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
            this.actionDisableCustomControllers = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.actionEnableControllers = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.actionDisableControllers = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // actionDisableCustomControllers
            // 
            this.actionDisableCustomControllers.Caption = "Disable Custom Controllers";
            this.actionDisableCustomControllers.Category = "RecordEdit";
            this.actionDisableCustomControllers.ConfirmationMessage = null;
            this.actionDisableCustomControllers.Id = "actionDisableCustomControllers";
            this.actionDisableCustomControllers.ToolTip = null;
            this.actionDisableCustomControllers.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionDisableCustomControllers_Execute);
            // 
            // actionEnableControllers
            // 
            this.actionEnableControllers.Caption = "Enable";
            this.actionEnableControllers.Category = "RecordEdit";
            this.actionEnableControllers.ConfirmationMessage = null;
            this.actionEnableControllers.Id = "actionEnableControllers";
            this.actionEnableControllers.ImageName = "Action_Workflow_Activate";
            this.actionEnableControllers.ToolTip = null;
            this.actionEnableControllers.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionEnableControllers_Execute);
            // 
            // actionDisableControllers
            // 
            this.actionDisableControllers.Caption = "Disable";
            this.actionDisableControllers.Category = "RecordEdit";
            this.actionDisableControllers.ConfirmationMessage = null;
            this.actionDisableControllers.Id = "actionDisableControllers";
            this.actionDisableControllers.ImageName = "Action_Workflow_Deactivate";
            this.actionDisableControllers.ToolTip = null;
            this.actionDisableControllers.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionDisableControllers_Execute);
            // 
            // ControllerSettingsViewController
            // 
            this.Actions.Add(this.actionDisableCustomControllers);
            this.Actions.Add(this.actionEnableControllers);
            this.Actions.Add(this.actionDisableControllers);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionDisableCustomControllers;
        private DevExpress.ExpressApp.Actions.SimpleAction actionEnableControllers;
        private DevExpress.ExpressApp.Actions.SimpleAction actionDisableControllers;
    }
}
