<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Recruitment.Web.ContactUs" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
    <meta charset="utf-8">
    <meta name="robots" content="noindex, nofollow">

    <title>Contact form with Social network links - Bootsnipp.com</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <style type="text/css">
        body {
            width: 100%;
            height: 100%;
            font-family: 'Roboto Condensed', sans-serif;
        }


        h1, h2, h3 {
            margin: 0 0 35px 0;
            font-family: 'Patua One', cursive;
            text-transform: uppercase;
            letter-spacing: 1px;
        }

        p {
            margin: 0 0 25px;
            font-size: 18px;
            line-height: 1.6em;
        }

        a {
            color: #26a5d3;
        }

            a:hover, a:focus {
                text-decoration: none;
                color: #26a5d3;
            }

        #contact {
            background: #333333;
            color: #f4f4f4;
            padding-bottom: 80px;
        }

        textarea.form-control {
            height: 100px;
        }
    </style>
    <style type="text/css">
        /*
For a more professional header, footer, navigation, mega menu, and sidebar, 
I recommend you to checkout this awesome jQuery plugin and CSS framework:
https://myflashlabs.github.io/24component-bars/
It lets you create almost any kind of bar fast and easy. Cheers!
*/
        .pr {
            margin: 0;
            font-family: Arial, sans-serif;
        }

            .pr body {
                margin: 0;
            }

        *,
        *:after,
        *:before {
            box-sizing: border-box;
        }

        .m-a-0 {
            margin: 0 !important;
        }

        .m-t-0 {
            margin-top: 0 !important;
        }

        .m-r-0 {
            margin-right: 0 !important;
        }

        .m-b-0 {
            margin-bottom: 0 !important;
        }

        .m-l-0 {
            margin-left: 0 !important;
        }

        .m-x-0 {
            margin-right: 0 !important;
            margin-left: 0 !important;
        }

        .m-y-0 {
            margin-top: 0 !important;
            margin-bottom: 0 !important;
        }

        .m-a {
            margin: 12px !important;
        }

        .m-t {
            margin-top: 12px !important;
        }

        .m-r {
            margin-right: 12px !important;
        }

        .m-b {
            margin-bottom: 12px !important;
        }

        .m-l {
            margin-left: 12px !important;
        }

        .m-x {
            margin-right: 12px !important;
            margin-left: 12px !important;
        }

        .m-y {
            margin-top: 12px !important;
            margin-bottom: 12px !important;
        }

        .m-x-auto {
            margin-right: auto !important;
            margin-left: auto !important;
        }

        .p-a-0 {
            padding: 0 !important;
        }

        .p-t-0 {
            padding-top: 0 !important;
        }

        .p-r-0 {
            padding-right: 0 !important;
        }

        .p-b-0 {
            padding-bottom: 0 !important;
        }

        .p-l-0 {
            padding-left: 0 !important;
        }

        .p-x-0 {
            padding-right: 0 !important;
            padding-left: 0 !important;
        }

        .p-y-0 {
            padding-top: 0 !important;
            padding-bottom: 0 !important;
        }

        .p-a {
            padding: 12px !important;
        }

        .p-t {
            padding-top: 12px !important;
        }

        .p-r {
            padding-right: 12px !important;
        }

        .p-b {
            padding-bottom: 12px !important;
        }

        .p-l {
            padding-left: 12px !important;
        }

        .p-x {
            padding-right: 12px !important;
            padding-left: 12px !important;
        }

        .p-y {
            padding-top: 12px !important;
            padding-bottom: 12px !important;
        }

        .text-xs-left {
            text-align: left !important;
        }

        .text-xs-right {
            text-align: right !important;
        }

        .text-xs-center {
            text-align: center !important;
        }

        @media (min-width: 768px) {
            .text-sm-left {
                text-align: left !important;
            }

            .text-sm-right {
                text-align: right !important;
            }

            .text-sm-center {
                text-align: center !important;
            }
        }

        @media (min-width: 992px) {
            .text-md-left {
                text-align: left !important;
            }

            .text-md-right {
                text-align: right !important;
            }

            .text-md-center {
                text-align: center !important;
            }
        }

        @media (min-width: 1200px) {
            .text-lg-left {
                text-align: left !important;
            }

            .text-lg-right {
                text-align: right !important;
            }

            .text-lg-center {
                text-align: center !important;
            }
        }

        .w-full {
            width: 100% !important;
        }

        .bg-color-white {
            background-color: #eee !important;
        }

        .bg-color-black {
            background-color: #1a1a1a !important;
        }

        .bg-color-white-secondary {
            background-color: #e1e1e1 !important;
        }

        .bg-color-black-secondary {
            background-color: #272727 !important;
        }

        .text-color-white {
            color: #eee !important;
        }

        .text-color-black {
            color: #1a1a1a !important;
        }

        .curved {
            border-radius: 4px !important;
        }

        .rounded {
            border-radius: 100px !important;
        }

        .s24-bar {
            position: relative;
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-flow: row wrap;
            flex-flow: row wrap;
            -webkit-box-align: center;
            -ms-flex-align: center;
            align-items: center;
            -ms-flex-line-pack: center;
            align-content: center;
            -webkit-box-pack: justify;
            -ms-flex-pack: justify;
            justify-content: space-between;
            width: 100%;
            min-height: 24px;
            margin-bottom: 24px;
            -webkit-transition: all 0.3s;
            transition: all 0.3s;
            -webkit-transition-timing-function: cubic-bezier(0.09, 0.68, 0, 0.99);
            transition-timing-function: cubic-bezier(0.09, 0.68, 0, 0.99);
            z-index: 2000;
        }

            .s24-bar:before, .s24-bar:after {
                content: '';
                display: table;
            }

            .s24-bar:after {
                clear: both;
            }

        .s24-bar--pos-fixed-top,
        .s24-bar--pos-fixed-bottom {
            position: fixed;
            margin-bottom: 0;
            z-index: 2010;
        }

        .s24-bar--pos-fixed-top {
            top: 0;
            left: 0;
        }

        .s24-bar--pos-fixed-bottom {
            bottom: 0;
            left: 0;
        }

        @media (min-width: 768px) {
            .s24-bar--visual-brand-focus .s24-bar__brand {
                -webkit-box-flex: 1;
                -ms-flex: 1 auto;
                flex: 1 auto;
            }
        }

        @media (min-width: 768px) {
            .s24-bar--visual-brand-focus .s24-bar__collapse {
                -webkit-box-ordinal-group: 0;
                -ms-flex-order: -1;
                order: -1;
                -webkit-box-flex: 0;
                -ms-flex: 0 1 auto;
                flex: 0 1 auto;
            }
        }

        .s24-bar__brand,
        .s24-bar__collapse,
        .s24-bar__utilities,
        .s24-bar__toggle {
            margin: 4px;
            -webkit-transition: all 0.3s;
            transition: all 0.3s;
        }

        .s24-bar__utilities--visual-wide {
            -webkit-box-flex: 1;
            -ms-flex: 1 auto;
            flex: 1 auto;
        }

        .s24-bar__brand {
            -webkit-box-flex: 1;
            -ms-flex: 1 100%;
            flex: 1 100%;
            font-size: 24px;
            line-height: 1.3333333;
            overflow: hidden;
        }

            .s24-bar__brand a {
                display: inline-block;
            }

                .s24-bar__brand a:link, .s24-bar__brand a:visited, .s24-bar__brand a:hover, .s24-bar__brand a:active, .s24-bar__brand a:focus {
                    color: inherit;
                    text-decoration: none;
                }

            .s24-bar__brand img {
                max-width: 100%;
                height: auto;
                vertical-align: initial;
            }

        @media (min-width: 480px) {
            .s24-bar__brand {
                -webkit-box-flex: 1;
                -ms-flex: 1 auto;
                flex: 1 auto;
            }
        }

        @media (min-width: 768px) {
            .s24-bar__brand {
                -webkit-box-flex: 0;
                -ms-flex: 0 1 auto;
                flex: 0 1 auto;
            }
        }

        @media (min-width: 768px) {
            .s24-bar__toggle {
                display: none;
            }
        }

        .s24-bar__collapse {
            display: none;
            margin: 0;
            -webkit-box-flex: 1;
            -ms-flex: 1 100%;
            flex: 1 100%;
            -webkit-box-ordinal-group: 100;
            -ms-flex-order: 99;
            order: 99;
            -webkit-transition: padding 0.3s;
            transition: padding 0.3s;
            border-top: 1px solid rgba(204, 204, 204, 0.4);
        }

        @media (min-width: 768px) {
            .s24-bar__collapse {
                display: block !important;
                height: auto !important;
                margin: 4px;
                -webkit-box-flex: 2;
                -ms-flex: 2 0;
                flex: 2 0;
                -webkit-box-ordinal-group: 1;
                -ms-flex-order: 0;
                order: 0;
                border-top: 0;
            }
        }

        .no-js .s24-bar__collapse, .s24-bar__collapse.s24-bar__collapse--state-open {
            display: block;
        }

        .s24-bar--pos-fixed-top .s24-bar__collapse, .s24-bar--pos-fixed-bottom .s24-bar__collapse {
            max-height: 340px;
            overflow-y: auto;
        }

        @media (max-device-width: 480px) and (orientation: landscape) {
            .s24-bar--pos-fixed-top .s24-bar__collapse, .s24-bar--pos-fixed-bottom .s24-bar__collapse {
                max-height: 200px;
            }
        }

        @media (min-width: 768px) {
            .s24-bar--pos-fixed-top .s24-bar__collapse, .s24-bar--pos-fixed-bottom .s24-bar__collapse {
                overflow-y: visible;
            }
        }

        .s24-list {
            margin: 0;
            padding: 0;
            list-style-type: none;
        }

        @media (max-width: 767px) {
            .s24-list--visual-collapsible > .s24-list__item {
                display: list-item;
                padding: 0;
            }

                .s24-list--visual-collapsible > .s24-list__item:hover {
                    background-color: rgba(204, 204, 204, 0.2);
                }

            .s24-list--visual-collapsible .s24-link {
                display: block;
                width: 100%;
                padding: 8px;
            }

                .s24-list--visual-collapsible .s24-link:hover, .s24-list--visual-collapsible .s24-link:active, .s24-list--visual-collapsible .s24-link:focus {
                    opacity: 1;
                }
        }

        .s24-list__item {
            display: inline-block;
            padding: 4px;
            -webkit-transition: all 0.3s;
            transition: all 0.3s;
        }

            .s24-list__item:first-child {
                margin: 0;
            }

        .s24-link:link, .s24-link:visited, .s24-link:hover, .s24-link:active, .s24-link:focus {
            color: inherit;
            -webkit-transition: all 0.3s;
            transition: all 0.3s;
            text-decoration: none;
        }

        .s24-link[disabled] {
            opacity: 0.4;
            pointer-events: none;
        }

        .s24-link--effect-alpha:hover, .s24-link--effect-alpha:active, .s24-link--effect-alpha:focus {
            opacity: .6;
        }
    </style>
    <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        window.alert = function () { };
        var defaultCSS = document.getElementById('bootstrap-css');
        function changeCSS(css) {
            if (css) $('head > link').filter(':first').replaceWith('<link rel="stylesheet" href="' + css + '" type="text/css" />');
            else $('head > link').filter(':first').replaceWith(defaultCSS);
        }
        $(document).ready(function () {
            var iframe_height = parseInt($('html').height());
            window.parent.postMessage(iframe_height, 'https://bootsnipp.com');
        });
    </script>
    <script type="text/javascript">
        window.alert = function () { };
        var defaultCSS = document.getElementById('bootstrap-css');
        function changeCSS(css) {
            if (css) $('head > link').filter(':first').replaceWith('<link rel="stylesheet" href="' + css + '" type="text/css" />');
            else $('head > link').filter(':first').replaceWith(defaultCSS);
        }
        $(document).ready(function () {
            var iframe_height = parseInt($('html').height());
            window.parent.postMessage(iframe_height, 'https://bootsnipp.com');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Oswald:700|Patua+One|Roboto+Condensed:700" rel="stylesheet">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <section id="contact" class="content-section text-center">
        <div class="contact-section">
            <div class="container">
                <h2>Contact Us</h2>
                <p>Feel free to shout us by feeling the contact form or visiting our social network sites like Fackebook,Youtube,Twitter.</p>
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="exampleInputName2">Name</label>
                                <input id="txtName" runat="server" type="text" class="form-control" placeholder="your name"/>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail2">Email</label>
                                <input id="txtMail" runat="server" type="email" class="form-control" placeholder="you@mail.com"/>
                            </div>
                            <div class="form-group ">
                                <label for="exampleInputText">Your Message</label>
                                <textarea id="txtDescription" runat="server"  class="form-control" placeholder="Description"></textarea> 
                            </div>
                            <%--<button id="btnSend" runat="server" type="submit" class="btn btn-default" OnServerClick="btnSend_Click">Send Message</button>--%>
                            <dx:BootstrapButton ID="btnSend" runat="server" type="submit" Text="Send Message" class="btn btn-default" OnClick="btnSend_Click" ></dx:BootstrapButton>
                        </div>

                        <hr>
                        <h3>Our Social Sites</h3>
                        <ul class="list-inline banner-social-buttons">
                            <li><a href="<%= Twitter %>" class="btn btn-default btn-lg"><i class="fa fa-twitter"> <span class="network-name">Twitter</span></i></a></li>
                            <li><a href="<%= Facebook %>" class="btn btn-default btn-lg"><i class="fa fa-facebook"> <span class="network-name">Facebook</span></i></a></li>
                            <li><a href="<%= Youtube %>" class="btn btn-default btn-lg"><i class="fa fa-youtube-play"> <span class="network-name">Youtube</span></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <br/>
        <div style="color: #fff; background-color: #ffa726; min-height: 300px; padding: 24px;">
            <!-- Sample #7
            ============================================= -->
            <footer class="s24-bar text-color-white">

                <!-- Put any utility content here, such as social icons -->
                <div class="s24-bar__utilities w-full bg-color-black  m-a-0">
                    <div class="container">
                        <div class="row m-y">
                            <div class="col-sm-8">
                                <h4><%= CompanyName %></h4>
                                <p>
                                    <%= AboutUs %>
                                </p>
                            </div>
                            <div class="col-sm-4">
                                <h4>Address</h4>
                                <address>
                                    <strong><%= CompanyName %>, Inc.</strong><br>
                                    <%= CompanyAddress %><br>
                                    <abbr title="Phone">P:</abbr> <%= CompanyPhone1 %> 
                                    <abbr title="Phone">P:</abbr> <%= CompanyPhone2 %><br>
                                    <abbr title="Mobile">M:</abbr> <%= CompanyMobile1 %> 
                                    <abbr title="Mobile">M:</abbr> <%= CompanyMobile2 %><br>
                                </address>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Put any utility content here, such as social icons -->
                <div class="s24-bar__utilities w-full bg-color-black-secondary m-a-0">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-9">
                                <p style="margin-top: 14px;">
                                    Copyrights © All Rights Reserved by <a class="s24-link s24-link--effect-alpha" href="index.aspx"><%= CompanyName %></a>
                                </p>
                            </div>

                            <div class="col-sm-3 text-xs-left text-sm-right">
                                <ul class="s24-list m-y">
                                    <li class="s24-list__item"><a class="s24-link s24-link--effect-alpha" href="<%= Facebook %>" role="button"><i class="fa fa-facebook fa-fw"></i></a></li>
                                    <li class="s24-list__item"><a class="s24-link s24-link--effect-alpha" href="<%= Twitter %>" role="button"><i class="fa fa-twitter fa-fw"></i></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
  
            </footer>
  
            <p class="lead text-xs-center">
                <strong>FEEL FREE CONTACT US ANY TIME, THANK YOU.</strong> 
            </p>
        </div>
    </section>
    <script type="text/javascript">

    </script>
</asp:Content>
