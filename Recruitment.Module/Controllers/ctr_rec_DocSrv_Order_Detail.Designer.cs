namespace Recruitment.Module.Controllers
{
    partial class ctr_rec_DocSrv_Order_Detail
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
            this.act_Delivered = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // act_Delivered
            // 
            this.act_Delivered.Caption = "Delivered";
            this.act_Delivered.Category = "Edit";
            this.act_Delivered.ConfirmationMessage = "Are you sure?";
            this.act_Delivered.Id = "act_Delivered";
            this.act_Delivered.ImageName = "rec_DocSrv_Order_Detail_Delivered";
            this.act_Delivered.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.act_Delivered.ToolTip = null;
            this.act_Delivered.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.act_Delivered_Execute);
            // 
            // ctr_rec_DocSrv_Order_Detail
            // 
            this.Actions.Add(this.act_Delivered);
            this.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_DocSrv_Order_Detail);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction act_Delivered;
    }
}
