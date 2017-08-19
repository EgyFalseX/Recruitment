using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recruitment.Web.App_Code.dsDataTableAdapters;

namespace Recruitment.Web
{
    public partial class ContactUs : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string CompanyName => Infrastructure.Core.CompanyName;
        public string AboutUs => Infrastructure.Core.AboutUs;
        public string CompanyEmail => Infrastructure.Core.CompanyEmail;
        public string CompanyPhone1 => Infrastructure.Core.CompanyPhone1;
        public string CompanyPhone2 => Infrastructure.Core.CompanyPhone2;
        public string CompanyMobile1 =>Infrastructure.Core.CompanyMobile1;
        public string CompanyMobile2 => Infrastructure.Core.CompanyMobile2;
        public string CompanyAddress => Infrastructure.Core.CompanyAddress;
        public string Facebook => Infrastructure.Core.Facebook;
        public string Twitter => Infrastructure.Core.Twitter;
        public string Youtube => Infrastructure.Core.Youtube;
        public string Instagram => Infrastructure.Core.Instagram;
        public string Dribbble => Infrastructure.Core.Dribbble;
        public string Linkedin => Infrastructure.Core.Linkedin;

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtName.Value == string.Empty || txtMail.Value == string.Empty || txtDescription.Value == string.Empty)
                return;
            string name = txtName.Value;
            string mail = txtMail.Value;
            string description = txtDescription.Value;
            int result =
                new FeedbackTableAdapter().Insert(DateTime.Now, name, mail, description);
            txtName.Value = txtMail.Value = txtDescription.Value = string.Empty;
            if (result > 0)
                Response.Redirect("index.aspx");
        }
    }
}