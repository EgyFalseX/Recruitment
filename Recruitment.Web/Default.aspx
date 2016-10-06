<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Recruitment.Web.Default" %>

<%@ Register Src="~/UC/MainPage_Carousel_UC.ascx" TagPrefix="uc1" TagName="MainPage_Carousel_UC" %>
<%@ Register Src="~/UC/MainPage_Service_UC.ascx" TagPrefix="uc1" TagName="MainPage_Service_UC" %>
<%@ Register Src="~/UC/MainPage_Download_UC.ascx" TagPrefix="uc1" TagName="MainPage_Download_UC" %>
<%@ Register Src="~/UC/MainPage_Project_UC.ascx" TagPrefix="uc1" TagName="MainPage_Project_UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <!-- Navbar fixed top -->
    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#"><i class="fa fa-globe"></i><b class="black">A</b><b class="red">rkan</b><b class="black"> Group</b></a>
            </div>
            <div class="navbar-collapse collapse">
                <!-- Left nav -->
                <ul class="nav navbar-nav navbar-right">
                    <li class="active"><a href="index.aspx" runat="server">Home</a></li>
                    <li><a href="Applicant.aspx" runat="server">Applicant</a></li>
                    <li><a href="Employer.aspx" runat="server">Employer</a></li>
                    <li class="dropdown"><a href="ArkanGroup.aspx" class="dropdown-toggle" data-toggle="dropdown"
                        role="button" aria-haspopup="true" aria-expanded="false" runat="server">Arkan Group<span class="caret"
                            runat="server"></span></a>
                        <ul class="dropdown-menu" data-dropdown-in="fadeInUp" data-dropdown-out="fadeOutDown">
                            <li><a href="Blog.aspx">Blog</a></li>
                            <li><a href="Contact.aspx">Contact</a></li>
                            <li><a href="About.aspx">About</a></li>
                        </ul>
                    </li>
                    <li>
                        <!-- add search form -->
                        <div class="navbar-form" role="search">
                            <div class="input-group">
                                <asp:TextBox ID="txtsearch" runat="server" placeholder="Search this site" class="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:LinkButton runat="server" ID="lbsearch" ToolTip="Search" CssClass="btn btn-default"
                                        Text='<i class="glyphicon glyphicon-search"></i>' />
                                </span>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <uc1:MainPage_Carousel_UC runat="server" id="MainPage_Carousel_UC" />
    <uc1:MainPage_Service_UC runat="server" id="MainPage_Service_UC" />
    <!-- Page Content -->
    <div class="padding100" id="blog">
        <div class="container">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h2 class="background double animated wow fadeInUp" data-wow-delay="0.2s">
                        <span><strong>B</strong>log</span></h2>                    
                </div>
            </div>
            <!-- /.row -->
            <!-- Project One -->
            <div class="row">
                <div class="col-md-7">
                    <a href="#">
                        <img class="img-responsive animated wow fadeInLeft" data-wow-delay="0.2s" src="img/700x300.jpg"
                            alt="">                       
                    </a>
                </div>
                <div class="col-md-5 animated wow fadeInRight" data-wow-delay="0.4s">
                    <h3>
                        <strong>Our Projects</strong></h3>
                    <h4>
                        NewBingo</h4>
                    <p>
                        Akshara is a library to buy Bootstrap themes and templates for your business need.
                        Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                        an update when new items arrive!</p>
                    <a class="btn btn-success" href="#">View Project <span class="glyphicon glyphicon-chevron-right">
                    </span></a>
                </div>
            </div>
            <!-- /.row -->
            <!-- Pagination -->
            <!--<div class="row text-center">
            <div class="col-lg-12">
                <ul class="pagination">
                    <li><a href="#">&laquo;</a> </li>
                    <li class="active"><a href="#">1</a> </li>
                    <li><a href="#">2</a> </li>
                    <li><a href="#">3</a> </li>
                    <li><a href="#">4</a> </li>
                    <li><a href="#">5</a> </li>
                    <li><a href="#">&raquo;</a> </li>
                </ul>
            </div>
        </div>      -->
        </div>
    </div>
    <!-- /.container -->
    <uc1:MainPage_Project_UC runat="server" ID="MainPage_Project_UC" />
    <uc1:MainPage_Download_UC runat="server" id="MainPage_Download_UC" />
    
    <!-- End Production Section -->
</asp:Content>
