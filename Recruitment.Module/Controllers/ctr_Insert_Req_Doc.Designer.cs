namespace Recruitment.Module.Controllers
{
    partial class ctr_Insert_Req_Doc
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
            this.action_Insert_Req_Doc = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // action_Insert_Req_Doc
            // 
            this.action_Insert_Req_Doc.Caption = "Add Required Document";
            this.action_Insert_Req_Doc.Category = "Edit";
            this.action_Insert_Req_Doc.Id = "action_Insert_Req_Doc";
            this.action_Insert_Req_Doc.ImageName = "rec_Doc_Info32";
            this.action_Insert_Req_Doc.TargetObjectType = typeof(Recruitment.Module.BusinessObjects.Recruitment.rec_Employer_Order_Detail_Accept_Applicat);
            this.action_Insert_Req_Doc.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.action_Insert_Req_Doc.ToolTip = null;
            this.action_Insert_Req_Doc.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.action_Insert_Req_Doc.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.action_Insert_Req_Doc_Execute);
            // 
            // ctr_Insert_Req_Doc
            // 
            this.Actions.Add(this.action_Insert_Req_Doc);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction action_Insert_Req_Doc;
    }
}
