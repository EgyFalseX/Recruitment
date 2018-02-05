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
    public partial class IndustryEditor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Infrastructure.UserManager.Authenticated)
                Response.Redirect("Login.aspx");
        }

    }
}