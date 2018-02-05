<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="IndustryEditor.aspx.cs" Inherits="Recruitment.Web.IndustryEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="industry_id" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True">
        <Settings ShowFilterRow="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="industry_name" VisibleIndex="2" Caption="Name" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [rec_Industry] WHERE [industry_id] = ?" InsertCommand="INSERT INTO [rec_Industry] ([industry_name]) VALUES (?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [industry_id], [industry_name] FROM [rec_Industry]" UpdateCommand="UPDATE [rec_Industry] SET [industry_name] = ? WHERE [industry_id] = ?">
        <DeleteParameters>
            <asp:Parameter Name="industry_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="industry_name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="industry_name" Type="String" />
            <asp:Parameter Name="industry_id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </asp:Content>
