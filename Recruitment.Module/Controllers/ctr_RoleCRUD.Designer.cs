namespace Recruitment.Module.Controllers
{
    partial class ctr_RoleCRUD
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
            this.act_SetCRUD = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // act_SetCRUD
            // 
            this.act_SetCRUD.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.act_SetCRUD.Caption = "Set Privilege";
            this.act_SetCRUD.Category = "Edit";
            this.act_SetCRUD.ConfirmationMessage = null;
            this.act_SetCRUD.Id = "SetPrivilegeAction";
            this.act_SetCRUD.ImageName = "Action_Grant_Set";
            this.act_SetCRUD.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.act_SetCRUD.TargetObjectType = typeof(DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject);
            this.act_SetCRUD.ToolTip = null;
            this.act_SetCRUD.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.act_SetCRUD.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.act_SetCRUD_Execute);
            // 
            // ctr_RoleCRUD
            // 
            this.Actions.Add(this.act_SetCRUD);
            this.TargetObjectType = typeof(DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject);
            this.TypeOfView = typeof(DevExpress.ExpressApp.View);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction act_SetCRUD;
    }
}
