using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Xpo;

namespace Recruitment.Web
{
    public partial class Jobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XpoDS.Session.ConnectionString = WebApplication.Instance.ConnectionString;
            //XpoDS.CriteriaParameters["Now"].DefaultValue = "#" + DateTime.Now.ToShortDateString() + "#";
            //XpoDS.Session.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //XafApplication.ConnectionString 
            XpoDS.CriteriaParameters["Now"].DefaultValue = DateTime.Now.ToShortDateString();
            XpoDS.Session = ((XPObjectSpace) WebApplication.Instance.CreateObjectSpace()).Session;
            

        }

        public byte[] ConvertToByte(Bitmap bmp)
        {
            using (var stream = new MemoryStream())
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}