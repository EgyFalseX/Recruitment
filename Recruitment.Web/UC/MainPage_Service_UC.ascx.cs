using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recruitment.Web.dsDataTableAdapters;

namespace Recruitment.Web.UC
{
    public partial class MainPage_Service_UC : System.Web.UI.UserControl
    {
        private dsData.ServiceDataTable _itemList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _itemList = new dsData.ServiceDataTable();
                ServiceTableAdapter adp = new ServiceTableAdapter();
                adp.Fill(_itemList);
            }
        }

        public string LoadContains()
        {
            string itemTemplate = string.Empty;
            for (var i = 0; i < _itemList.Count; i++)
            {
                //Make Row
                if (i == 0 || i % 3 == 0)
                    itemTemplate += "<div class=\"row\">" + Environment.NewLine;

                itemTemplate += "<div class=\"col-md-4\">" + Environment.NewLine;
                itemTemplate += "<i class=\"fa " + _itemList[i].Symbol + " animated wow fadeInDown\"></i><div class=\"sc-inner\">" + Environment.NewLine;
                itemTemplate += "<h4>" + _itemList[i].Header + "</h4>" + Environment.NewLine;
                itemTemplate += "<p>" + _itemList[i].Body + "</p>" + Environment.NewLine;
                itemTemplate += "</div></div>" + Environment.NewLine;
                //Close Row
                if ((i + 1) % 3 == 0)
                    itemTemplate += "</div>" + Environment.NewLine;
            }
            return itemTemplate;
        }
    }
}