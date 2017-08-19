using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace Recruitment.Web
{
    public partial class GalleryEditor : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Infrastructure.UserManager.Authenticated)
                Response.Redirect("Login.aspx");
        }
        protected void ASPxUploadControlMain_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            ASPxUploadControl uploader = (ASPxUploadControl)sender;
            Session["GallaryEditorFilename"] = uploader.UploadedFiles[0].FileNameInStorage;
        }
        protected void ASPxGridViewMain_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session["GallaryEditorFilename"] = null;
        }
        protected void SqlDataSourceMain_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            if (Session["GallaryEditorFilename"] != null)
                e.Command.Parameters["ImageURL"].Value = Session["GallaryEditorFilename"];
        }
        protected void SqlDataSourceMain_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            if (Session["GallaryEditorFilename"] != null)
                e.Command.Parameters["ImageURL"].Value = Session["GallaryEditorFilename"];
        }

    }
}