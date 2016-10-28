namespace Recruitment.Module.Controllers
{
    partial class ctr_PrintConnection
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
            this.act_PrintConnection = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // act_PrintConnection
            // 
            this.act_PrintConnection.Caption = "Print Connection";
            this.act_PrintConnection.Category = "Edit";
            this.act_PrintConnection.ConfirmationMessage = null;
            this.act_PrintConnection.Id = "act_PrintConnection";
            this.act_PrintConnection.ImageName = "Action_Printing_Print";
            this.act_PrintConnection.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Connection);
            this.act_PrintConnection.ToolTip = null;
            this.act_PrintConnection.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.act_PrintConnection_Execute);
            // 
            // ctr_PrintConnection
            // 
            this.Actions.Add(this.act_PrintConnection);
            this.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Connection);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction act_PrintConnection;
    }
}
