using System;
using System.Collections.Generic;
using System.Configuration;
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
using DevExpress.Web;
using DevExpress.Xpo;
using Recruitment.Web.BO.Recruitment;
using FileData = DevExpress.Persistent.BaseImpl.FileData;


namespace Recruitment.Web
{
    public partial class Apply : Page
    {
        private string _dataFolder = "~/Jobs/attachments/";
        
        public rec_job_post Job = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                Response.Redirect("Jobs.aspx");
            XpoDSGender.Session = new Session
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"]
                    .ConnectionString
            };
            XpoDSNationality.Session = new Session
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"]
                    .ConnectionString
            };
            //XpoDSGender.Session = ((XPObjectSpace)WebApplication.Instance.CreateObjectSpace()).Session;
            //XpoDSNationality.Session = ((XPObjectSpace)WebApplication.Instance.CreateObjectSpace()).Session;
            GetJobInfo(Convert.ToInt32(Request.QueryString["id"]));
            if (!IsPostBack)
            {
                Session["filename"] = null;
                UpdateCounting(Convert.ToInt32(Request.QueryString["id"]));
            }
        }
        private void UpdateCounting(int id)
        {
            Session session = new Session
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"]
                    .ConnectionString
            };
            //session.BeginTransaction();
            Job = session.FindObject<rec_job_post>(CriteriaOperator.Parse($"job_post_id = {id} And jp_date_start <= #{DateTime.Now.ToShortDateString()}# And jp_date_end >= #{DateTime.Now.ToShortDateString()}# And jp_visible = True"));
            if (Job == null)
                Response.Redirect("Jobs.aspx");
            Job.jp_view_count += 1;
            Job.Save();
            //session.CommitTransaction();

        }
        private void GetJobInfo(int id)
        {
            Session session = new Session
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"]
                    .ConnectionString
            };
            Job = session.FindObject<rec_job_post>(CriteriaOperator.Parse($"job_post_id = {id} And jp_date_start <= #{DateTime.Now.ToShortDateString()}# And jp_date_end >= #{DateTime.Now.ToShortDateString()}# And jp_visible = True"));
            if (Job == null)
                Response.Redirect("Jobs.aspx");

            jp_image.ImageUrl = "~/img/job/" + Job.jp_image;
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

        protected void DocumentsUploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string filename = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
                              DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + "_" + e.UploadedFile.FileName;
            e.UploadedFile.SaveAs(MapPath(_dataFolder + filename));
            if (e.IsValid)
            {
                e.CallbackData = filename;
                Session["filename"] = filename;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Session session = new Session
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"]
                    .ConnectionString
            };
            rec_job_post job = session.GetObjectByKey<rec_job_post>(Job.job_post_id);
            rec_job_post_apply apply =
                new rec_job_post_apply(session)
                {
                    attach_file = Session["filename"]?.ToString() ?? "",
                    job_post_id = job,
                    apply_date = DateTime.Now,
                    apply_gender_id =
                        session.GetObjectByKey<rec_Gender>((int) ASPxComboBoxNationality.SelectedItem.Value),
                    apply_nationality_id =
                        session.GetObjectByKey<rec_Nationality>((int) ASPxComboBoxNationality.SelectedItem.Value),
                    apply_mobile = tbMobile.Value.ToString(),
                    apply_name = tbName.Value.ToString()
                };
            apply.Save();
            //session.CommitTransaction();
            pcMsg.ShowOnPageLoad = true;

        }
    }
}