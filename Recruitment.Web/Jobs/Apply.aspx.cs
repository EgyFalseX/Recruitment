using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Xpo;
using Recruitment.Module.BusinessObjects.Recruitment;

namespace Recruitment.Web
{
    public partial class Apply : System.Web.UI.Page
    {
        public rec_job_post Job = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.QueryString["id"] == null)
                Response.Redirect("Jobs.aspx");

            XpoDSGender.Session = ((XPObjectSpace)WebApplication.Instance.CreateObjectSpace()).Session;
            XpoDSNationality.Session = ((XPObjectSpace)WebApplication.Instance.CreateObjectSpace()).Session;
            GetJobInfo(Convert.ToInt32(Request.QueryString["id"]));
        }

        private void GetJobInfo(int id)
        {
            IObjectSpace objectspace = WebApplication.Instance.CreateObjectSpace();
            Job = objectspace.FindObject<rec_job_post>(CriteriaOperator.TryParse($"job_post_id = {id} And jp_date_start <= {DateTime.Now.ToShortDateString()} And jp_date_end >= {DateTime.Now.ToShortDateString()} jp_visible = True"));
            if (Job == null)
                Response.Redirect("Jobs.aspx");

            jp_image.ContentBytes = ConvertToByte((System.Drawing.Bitmap) Job.jp_image);
            jp_date_start.InnerText = Job.jp_date_start.ToShortDateString();
            industry_name.InnerText = Job.jp_industry_id.industry_name;
            jp_view_count.InnerText = Job.jp_view_count.ToString() + " Views";
            jp_content.InnerText = Job.jp_content;

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