using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruitment.Web.ControlPanel
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.EndsWith("CompanyInforEditor.aspx"))
            {
                OutCompanyInfo.Attributes["class"] = "active-menu";
            }else if (Request.Url.AbsolutePath.EndsWith("CarouselEditor.aspx"))
            {
                CarouselLink.Attributes["class"] = "active-menu";
            }else if (Request.Url.AbsolutePath.EndsWith("ServiceEditor.aspx"))
            {
                ServicesLink.Attributes["class"] = "active-menu";
            }
            else if (Request.Url.AbsolutePath.EndsWith("CompanyEditor.aspx"))
            {
                CompaniesLink.Attributes["class"] = "active-menu";
            }
            else if (Request.Url.AbsolutePath.EndsWith("GalleryEditor.aspx"))
            {
                GalleryLink.Attributes["class"] = "active-menu";
            }
            else if (Request.Url.AbsolutePath.EndsWith("ContactUsEditor.aspx"))
            {
                FeedbackLink.Attributes["class"] = "active-menu";
            }
            else if (Request.Url.AbsolutePath.EndsWith("IndustryEditor.aspx"))
            {
                IndustryEditorLink.Attributes["class"] = "active-menu";
            }
            else if (Request.Url.AbsolutePath.EndsWith("JobsEditor.aspx"))
            {
                JobsEditorLink.Attributes["class"] = "active-menu";
            }
            else if (Request.Url.AbsolutePath.EndsWith("JobApplyEditor.aspx"))
            {
                JobApplyEditorLink.Attributes["class"] = "active-menu";
            }
        }
    }
}