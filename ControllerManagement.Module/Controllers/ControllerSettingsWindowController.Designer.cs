namespace ControllerManagement.Module.Controllers
{
    partial class ControllerSettingsWindowController
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
            this.actionShowControllerSettings = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // actionShowControllerSettings
            // 
            this.actionShowControllerSettings.AcceptButtonCaption = null;
            this.actionShowControllerSettings.CancelButtonCaption = null;
            this.actionShowControllerSettings.Caption = "Show Controller Settings";
            this.actionShowControllerSettings.Category = "Tools";
            this.actionShowControllerSettings.ConfirmationMessage = null;
            this.actionShowControllerSettings.Id = "actionShowControllerSettings";
            this.actionShowControllerSettings.ImageName = "Navigation_Item_View";
            this.actionShowControllerSettings.ToolTip = null;
            this.actionShowControllerSettings.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.actionShowControllerSettings_CustomizePopupWindowParams);
            // 
            // ControllerSettingsWindowController
            // 
            this.Actions.Add(this.actionShowControllerSettings);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction actionShowControllerSettings;

    }
}
