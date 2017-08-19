<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainPage_Download_UC.ascx.cs" Inherits="Recruitment.Web.UC.MainPage_Download_UC" %>
<!-- Download Section -->
<section id="download" class="padding100">
    <div class="container">
        <div class="row">
            <div class="section-title col-sm-8 col-sm-offset-2 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2">
                <%--<h2 class="animated wow fadeInLeft" data-wow-delay="0.4s">Waiting for what <span class="common">' DOWNLOAD NOW'</span></h2>--%>
                <h2 class="animated wow fadeInLeft" data-wow-delay="0.4s">
                    <span class="common"> شركاؤنــا و عملائنـا  </span>
                    فـي جميـع انحـاء العـالم
                </h2>
            </div>
        </div>
        <!-- ./end row -->
        <div class="row">
            <div class="col-sm-8 col-sm-offset-2 text-center">
                <div class="download-wrap animated wow fadeInLeft" data-wow-delay="0.4s">
                    <%--<a href="#" class="btn btn-download wow fadeInUp">
                        <i class="fa fa-android"></i><strong>Download App</strong> <span>From Play Store</span> 
                    </a>
                    <a href="#" class="btn btn-download app wow fadeInUp" data-wow-delay="0.2s">
                        <i class="fa fa-apple"></i><strong>Download App</strong> <span>From App Store</span>
                    </a>
                    <a href="#" class="btn btn-download window wow fadeInUp" data-wow-delay="0.2s">
                        <i class="fa fa-windows"></i><strong>Download App</strong>
                            <span>From windows store</span>
                    </a>
                    <a href="#" class="btn btn-download app wow fadeInUp" data-wow-delay="0.2s">
                        <i><img src="../img/company/logo01.jpg" alt="company logo" height="44" width="40"></i><strong>شركة مايكروسوفت</strong> <span>امريكا</span>
                    </a>--%>
                    <%= LoadCompanyContains() %>
                </div>
            </div>
        </div>
        <!-- ./end row -->
    </div>
</section>
<!--End Download Section end-->
