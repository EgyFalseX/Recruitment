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
using DevExpress.Web;
using DevExpress.Xpo;

namespace Recruitment.Web
{
    public partial class Jobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XpoDS.CriteriaParameters["Now"].DefaultValue = DateTime.Now.ToShortDateString();
            //if (Session["IndustyParam"] != null)
            //{
            //    XpoDS.CriteriaParameters["IndustyParam"].DefaultValue = Session["IndustyParam"].ToString();
            //    dataView.DataBind();
            //}

            XpoDS.Session = new Session
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"]
                .ConnectionString
            };
            XpoDSIndustry.Session = new Session
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"]
                .ConnectionString
            };
            //XpoDS.Session = ((XPObjectSpace)WebApplication.Instance.CreateObjectSpace()).Session;
            //XpoDSIndustry.Session = ((XPObjectSpace)WebApplication.Instance.CreateObjectSpace()).Session;
            if (!IsPostBack)
            {
                Session["IndustyParam"] = null;
                dataView.PagerSettings.EndlessPagingMode = (DataViewEndlessPagingMode)Enum.Parse(typeof(DataViewEndlessPagingMode), "OnClick");
            }
            if (IsCallback)
            {
                // Intentionally pauses server-side processing, 
                // to demonstrate the Loading Panel functionality.
                System.Threading.Thread.Sleep(500);
            }

        }

        public byte[] ConvertToByte(Bitmap bmp)
        {
            using (var stream = new MemoryStream())
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        protected void dataView_CustomCallback(object sender, CallbackEventArgsBase e)
        {
            Session["IndustyParam"] = e.Parameter;
            XpoDS.CriteriaParameters["IndustyParam"].DefaultValue = e.Parameter;
            XpoDS.Criteria =
                "[jp_date_start] <= ?Now And [jp_date_end] >= ?Now And [jp_visible] = True And [jp_industry_id] = " + e.Parameter;
            dataView.PagerSettings.EndlessPagingMode = (DataViewEndlessPagingMode)Enum.Parse(typeof(DataViewEndlessPagingMode), "Disabled");
            dataView.AllowPaging = false;
            dataView.DataBind();
        }
    }
}