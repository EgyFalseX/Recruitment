namespace Recruitment.Module.Controllers
{
    partial class ctr_rec_DocSrv_Order_Detail_Srv
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
            this.act_Completed = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.act_Paid = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // act_Completed
            // 
            this.act_Completed.Caption = "Completed";
            this.act_Completed.Category = "Edit";
            this.act_Completed.ConfirmationMessage = "Are you sure?";
            this.act_Completed.Id = "act_Completed";
            this.act_Completed.ImageName = "rec_DocSrv_Order_Detail_Srv_Completed";
            this.act_Completed.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.act_Completed.ToolTip = null;
            this.act_Completed.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.act_Completed_Execute);
            // 
            // act_Paid
            // 
            this.act_Paid.Caption = "Paid";
            this.act_Paid.Category = "Edit";
            this.act_Paid.ConfirmationMessage = "Are you sure?";
            this.act_Paid.Id = "act_Paid";
            this.act_Paid.ImageName = "rec_DocSrv_Order_Detail_Srv_Paid";
            this.act_Paid.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.act_Paid.ToolTip = null;
            this.act_Paid.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.act_Paid_Execute);
            // 
            // ctr_rec_DocSrv_Order_Detail_Srv
            // 
            this.Actions.Add(this.act_Completed);
            this.Actions.Add(this.act_Paid);
            this.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_DocSrv_Order_Detail_Srv);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction act_Completed;
        private DevExpress.ExpressApp.Actions.SimpleAction act_Paid;
    }
}
