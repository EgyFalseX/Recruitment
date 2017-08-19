<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="CompanyEditor.aspx.cs" Inherits="Recruitment.Web.CompanyEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="AutoId" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True" OnStartRowEditing="ASPxGridViewMain_StartRowEditing">
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyLogo" VisibleIndex="1" Caption="Company Logo">
                <EditFormSettings ColumnSpan="2" />
                <DataItemTemplate>
                    <dx:ASPxImage ID="ASPxImageMain" runat="server" Height="64px" ImageUrl='<%# Eval("CompanyLogo", "~/img/company/{0}") %>' ShowLoadingImage="True" Width="64px">
                    </dx:ASPxImage>
                </DataItemTemplate>
                <EditItemTemplate>
                    <dx:ASPxUploadControl ID="ASPxUploadControlMain" runat="server" AutoStartUpload="True" OnFileUploadComplete="ASPxUploadControlMain_FileUploadComplete" ShowProgressPanel="True" ShowUploadButton="True" Theme="Moderno" UploadMode="Advanced" UploadStorage="FileSystem" Width="280px">
                        <FileSystemSettings UploadFolder="~/img/company/" />
                    </dx:ASPxUploadControl>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="2" Caption="Company Name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyCountry" VisibleIndex="3" Caption="Company Country">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Company URL" FieldName="CompanyURL" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [Company] WHERE [AutoId] = ?" InsertCommand="INSERT INTO [Company] ( [CompanyName], [CompanyCountry], [CompanyLogo], [CompanyURL]) VALUES ( ?, ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [AutoId], [CompanyName], [CompanyCountry], [CompanyLogo], [CompanyURL] FROM [Company]" UpdateCommand="UPDATE [Company] SET [CompanyName] = ?, [CompanyCountry] = ?, [CompanyLogo] = ?, [CompanyURL] = ? WHERE [AutoId] = ?" OnInserting="SqlDataSourceMain_Inserting" OnUpdating="SqlDataSourceMain_Updating">
        <DeleteParameters>
            <asp:Parameter Name="AutoId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="CompanyCountry" Type="String" />
            <asp:Parameter Name="CompanyLogo" Type="String" />
            <asp:Parameter Name="CompanyURL" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="CompanyCountry" Type="String" />
            <asp:Parameter Name="CompanyLogo" Type="String" />
            <asp:Parameter Name="CompanyURL" Type="String" />
            <asp:Parameter Name="AutoId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
