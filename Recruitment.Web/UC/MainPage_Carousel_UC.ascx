<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainPage_Carousel_UC.ascx.cs" Inherits="Recruitment.Web.UC.MainPage_Carousel_UC" %>
<!-- Carousel -->
<style type="text/css">
    /*.carousel .i0 {
        background: url(../img/12.jpg) no-repeat;
        background-position: right -10px bottom -50px;
    }

    .carousel .i1 {
        background: url(../img/13.jpg) no-repeat;
        background-position: right -10px bottom -80px;
        background-attachment: scroll;
    }

    .carousel .i2 {
        background: url(../img/14.jpg) no-repeat;
        background-position: right -10px bottom -80px;
        background-attachment: scroll;
    }*/
     <%= LoadCarouselStyle() %>
     
</style>
    <div id="carousel-example-generic" class="carousel slide carousel-fade" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <%--<li data-target='#carousel-example-generic' data-slide-to='0' class='active'><asp:Image ID="Image1" runat="server" ImageUrl="~/img/12.jpg" Width="100px" Height="50px" /></li>
            <li data-target='#carousel-example-generic' data-slide-to='1'><asp:Image ID="Image2" runat="server" ImageUrl="~/img/13.jpg" Width="100px" Height="50px" /></li>
            <li data-target='#carousel-example-generic' data-slide-to='2'><asp:Image ID="Image3" runat="server" ImageUrl="~/img/14.jpg" Width="100px" Height="50px" /></li>--%>
            <%= LoadCarouselImages() %>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <%--<div class="item active i0">
                <!-- <img src="#" alt="" /> -->
                <div class="main-text hidden-xs">
                    <div class="col-md-12 text-center">
                        <h1>
                            Let your <b class="yellow">smile</b> change the <b class="yellow">world</b><br />
                            <span class="span">Not the world change your smile.</span></h1>
                        <div class="">
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Login</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Registration</asp:HyperLink>
                           </div>
                    </div>
                </div>
            </div>--%>
        <%= LoadCarouselContains() %>
        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                href="#carousel-example-generic" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                </span></a>
    </div>
    <!-- Carousel -->
    </div>