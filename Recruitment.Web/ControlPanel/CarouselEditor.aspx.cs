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
    public partial class CarouselEditor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ASPxUploadControlMain_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            ASPxUploadControl uploader = (ASPxUploadControl)sender;
            Session["CarouselEditorFilename"] = uploader.UploadedFiles[0].FileNameInStorage;
        }
        protected void ASPxGridViewMain_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session["CarouselEditorFilename"] = null;
        }
        protected void SqlDataSourceMain_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            if (Session["CarouselEditorFilename"] != null)
                e.Command.Parameters["ImgPath"].Value = Session["CarouselEditorFilename"];
        }
        protected void SqlDataSourceMain_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            if (Session["CarouselEditorFilename"] != null)
                e.Command.Parameters["ImgPath"].Value = Session["CarouselEditorFilename"];
        }

    }
}