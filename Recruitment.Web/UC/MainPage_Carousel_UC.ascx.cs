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
    public partial class MainPage_Carousel_UC : System.Web.UI.UserControl
    {

        private dsData.CarouselDataTable _itemList;
        private readonly string _imagepath = "/img/carousel/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _itemList = new dsData.CarouselDataTable();
                CarouselTableAdapter adp = new CarouselTableAdapter();
                adp.Fill(_itemList);
            }

        }
        public string LoadCarouselImages()
        {
            string itemTemplate = string.Empty;
            for (var i = 0; i < _itemList.Count; i++)
            {
                string active = i == 0 ? " class='active'" : "";
                itemTemplate += $"<li data-target='#carousel-example-generic' data-slide-to='{i}'{active}>"
                                + $"<img src=\"..{_imagepath + _itemList[i].ImgPath}\" width=\"100px\" height=\"50px\" />"
                                + "</li>" + Environment.NewLine;
            }
            return itemTemplate;
        }
        public string LoadCarouselStyle()
        {
            string itemTemplate = string.Empty;
            for (var i = 0; i < _itemList.Count; i++)
            {
                string active = i != 0 ? "background-attachment: scroll;" : "";
                itemTemplate += ".carousel .i" + i + " {"
                                + "background: url(.." + _imagepath + _itemList[i].ImgPath + ") no-repeat;background-position: right -10px bottom -80px;"
                                + active + " }" + Environment.NewLine;
            }
            return itemTemplate;
        }
        public string LoadCarouselContains()
        {
            /*<div class="">
            <asp:HyperLink ID = "HyperLink1" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Login</asp:HyperLink>
            <asp:HyperLink ID = "HyperLink2" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Registration</asp:HyperLink>
            </div>*/

            string itemTemplate = string.Empty;
            for (var i = 0; i < _itemList.Count; i++)
            {
                string active = i == 0 ? "active" : "";
                itemTemplate += "<div class=\"item " + active + " i" + i +
                                "\"><div class=\"main-text hidden-xs\"><div class=\"col-md-12 text-center\"><h1>"
                                + _itemList[i].Header + "</h1></div></div></div>" + Environment.NewLine;
            }
            return itemTemplate;
        }

    }
}