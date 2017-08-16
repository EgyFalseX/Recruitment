using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recruitment.Web.App_Code.dsDataTableAdapters;

namespace Recruitment.Web.ControlPanel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            txtStatus.Text = string.Empty;
            txtUser.Validate();
            txtPass.Validate();
            if (!txtUser.IsValid || !txtPass.IsValid)
                return;
            UserTableAdapter adp = new UserTableAdapter();
            int? id = adp.Login(txtUser.Text, txtPass.Text);
            if (id == null || id == 0)
            {
                txtStatus.Text = "Invalid username/password";
                txtStatus.ForeColor = System.Drawing.Color.Red;
                txtStatus.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                Infrastructure.UserManager.Authenticated = true;
                Infrastructure.UserManager.UserId = (int)id;
                Response.Redirect("Default.aspx");
            }
            
        }
    }
}