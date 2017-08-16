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
            if (Request.Url.AbsolutePath.EndsWith("CarouselEditor.aspx"))
            {
                CarouselLink.Attributes["class"] = "active-menu";
            }else if (Request.Url.AbsolutePath.EndsWith("ServiceEditor.aspx"))
            {
                ServicesLink.Attributes["class"] = "active-menu";
            }
        }
    }
}