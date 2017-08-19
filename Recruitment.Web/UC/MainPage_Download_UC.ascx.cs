using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recruitment.Web.App_Code;
using Recruitment.Web.App_Code.dsDataTableAdapters;

namespace Recruitment.Web.UC
{
    public partial class MainPage_Download_UC : System.Web.UI.UserControl
    {
        private dsData.CompanyDataTable _itemList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _itemList = new dsData.CompanyDataTable();
                CompanyTableAdapter adp = new CompanyTableAdapter();
                adp.Fill(_itemList);
            }
        }
        public string LoadCompanyContains()
        {
            string itemTemplate = string.Empty;
            for (var i = 0; i < _itemList.Count; i++)
            {
                string active = i == 0 ? "active" : "";
                itemTemplate += "<a href=\"" + _itemList[i].CompanyURL + "\" class=\"btn btn-download app wow fadeInUp\" data-wow-delay=\"0.2s\">" +
                                "<i><img src=\"../img/company/" + _itemList[i].CompanyLogo + "\" alt=\"company logo\" height=\"44\" width=\"40\">" + 
                                "</i><strong>" + _itemList[i].CompanyName + "</strong>" + 
                                "<span>" + _itemList[i].CompanyCountry + "</span>" + 
                                "</a>" + Environment.NewLine;
            }
            return itemTemplate;
        }
    }
}