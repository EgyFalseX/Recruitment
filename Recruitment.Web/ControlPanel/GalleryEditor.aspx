<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="GalleryEditor.aspx.cs" Inherits="Recruitment.Web.GalleryEditor" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="AutoId" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True" OnStartRowEditing="ASPxGridViewMain_StartRowEditing">
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ImageURL" VisibleIndex="1">
                <EditFormSettings ColumnSpan="2" />
                <DataItemTemplate>
                    <dx:ASPxImage ID="ASPxImageMain" runat="server" Height="64px" ImageUrl='<%# Eval("ImageURL", "~/img/gallary/{0}") %>' ShowLoadingImage="True" Width="64px">
                    </dx:ASPxImage>
                </DataItemTemplate>
                <EditItemTemplate>
                    <dx:ASPxUploadControl ID="ASPxUploadControlMain" runat="server" AutoStartUpload="True" OnFileUploadComplete="ASPxUploadControlMain_FileUploadComplete" ShowProgressPanel="True" ShowUploadButton="True" Theme="Moderno" UploadMode="Advanced" UploadStorage="FileSystem" Width="280px">
                        <FileSystemSettings UploadFolder="~/img/gallary/" />
                    </dx:ASPxUploadControl>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="GallaryName" VisibleIndex="2" Caption="Gallary Name">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageText" VisibleIndex="3" Caption="Image Text">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [Gallary] WHERE [AutoId] = ?" InsertCommand="INSERT INTO [Gallary] ([ImageURL], [ImageText], [GallaryName]) VALUES ( ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [AutoId], [ImageURL], [ImageText], [GallaryName] FROM [Gallary]" UpdateCommand="UPDATE [Gallary] SET [ImageURL] = ?, [ImageText] = ?, [GallaryName] = ? WHERE [AutoId] = ?" OnInserting="SqlDataSourceMain_Inserting" OnUpdating="SqlDataSourceMain_Updating">
        <DeleteParameters>
            <asp:Parameter Name="AutoId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ImageURL" Type="String" />
            <asp:Parameter Name="ImageText" Type="String" />
            <asp:Parameter Name="GallaryName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ImageURL" Type="String" />
            <asp:Parameter Name="ImageText" Type="String" />
            <asp:Parameter Name="GallaryName" Type="String" />
            <asp:Parameter Name="AutoId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
