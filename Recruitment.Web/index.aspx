<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Recruitment.Web.index" %>

<%@ Register Src="~/UC/MainPage_Carousel_UC.ascx" TagPrefix="uc1" TagName="MainPage_Carousel_UC" %>
<%@ Register Src="~/UC/MainPage_Service_UC.ascx" TagPrefix="uc1" TagName="MainPage_Service_UC" %>
<%@ Register Src="~/UC/MainPage_Download_UC.ascx" TagPrefix="uc1" TagName="MainPage_Download_UC" %>
<%--<%@ Register Src="~/UC/MainPage_Project_UC.ascx" TagPrefix="uc1" TagName="MainPage_Project_UC" %>--%>
<%@ Register Src="~/UC/Gallary_UC.ascx" TagPrefix="uc1" TagName="Gallary_UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    
    <uc1:MainPage_Carousel_UC runat="server" id="MainPage_Carousel_UC" />
    <uc1:MainPage_Service_UC runat="server" id="MainPage_Service_UC" />
    <!-- Page Content -->
    <%--<div class="padding100" id="blog">
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
            <div class="row text-center">
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
        </div>      
        </div>
    </div>--%>
    <!-- /.container -->
    <%--<uc1:MainPage_Project_UC runat="server" ID="MainPage_Project_UC" />--%>
    <uc1:Gallary_UC runat="server" ID="Gallary_UC" />
    <uc1:MainPage_Download_UC runat="server" id="MainPage_Download_UC" />
    
    <!-- End Production Section -->
</asp:Content>
