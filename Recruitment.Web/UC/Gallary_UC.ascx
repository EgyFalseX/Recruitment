<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallary_UC.ascx.cs" Inherits="Recruitment.Web.UC.Gallary_UC" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
    <!-- Products Section -->
    <section id="products" class="products-list padding100">
        <div class="container">
            <div class="row">
                <dx:ASPxImageGallery ID="ASPxImageGalleryMain" runat="server" EnableCallbackAnimation="True" EnablePagingCallbackAnimation="True" EnableTheming="True" Theme="Moderno" Width="100%" DataSourceID="SqlDataSourceMain" FullscreenViewerTextField="ImageText" ImageUrlField="ImageURL" ImageUrlFormatString="~/img/gallary/{0}" NameField="GallaryName" TextField="ImageText">
                    <SettingsFolder ImageCacheFolder="~/Thumb/" />
                    <SettingsTableLayout RowsPerPage="1" />
                    <SettingsLoadingPanel Text="انتظر من فضلك&amp;hellip;" />
                </dx:ASPxImageGallery>
                <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT [AutoId], [ImageURL], [ImageText], [GallaryName] FROM [Gallary] ORDER BY AutoId DESC">
                </asp:SqlDataSource>
            </div>
        </div>
    </section>