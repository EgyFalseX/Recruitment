using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor;

namespace Recruitment.Web
{
    public partial class JobsEditor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Infrastructure.UserManager.Authenticated)
                Response.Redirect("Login.aspx");
        }
        protected void ASPxUploadControlMain_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            ASPxUploadControl uploader = (ASPxUploadControl)sender;
            Session["jobEditorFilename"] = uploader.UploadedFiles[0].FileNameInStorage;
        }
        protected void ASPxGridViewMain_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session["jobEditorFilename"] = null;
        }
        protected void SqlDataSourceMain_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            if (Session["jobEditorFilename"] != null)
                e.Command.Parameters["jp_image"].Value = Session["jobEditorFilename"];
        }
        protected void SqlDataSourceMain_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            if (Session["jobEditorFilename"] != null)
                e.Command.Parameters["jp_image"].Value = Session["jobEditorFilename"];
        }

    }
}