<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="ContactUsEditor.aspx.cs" Inherits="Recruitment.Web.ContactUsEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="AutoId" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True">
        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        <SettingsSearchPanel Visible="True" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataDateColumn FieldName="FeedbackDate" VisibleIndex="2">
                <PropertiesDateEdit DisplayFormatString="d/M/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="FeedbackName" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FeedbackMail" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FeedbackMessage" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [Feedback] WHERE [AutoId] = ?" InsertCommand="INSERT INTO [Feedback] ([AutoId], [FeedbackDate], [FeedbackName], [FeedbackMail], [FeedbackMessage]) VALUES (?, ?, ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [AutoId], [FeedbackDate], [FeedbackName], [FeedbackMail], [FeedbackMessage] FROM [Feedback] ORDER BY [AutoId] DESC" UpdateCommand="UPDATE [Feedback] SET [FeedbackDate] = ?, [FeedbackName] = ?, [FeedbackMail] = ?, [FeedbackMessage] = ? WHERE [AutoId] = ?">
        <DeleteParameters>
            <asp:Parameter Name="AutoId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="AutoId" Type="Int32" />
            <asp:Parameter Name="FeedbackDate" Type="DateTime" />
            <asp:Parameter Name="FeedbackName" Type="String" />
            <asp:Parameter Name="FeedbackMail" Type="String" />
            <asp:Parameter Name="FeedbackMessage" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FeedbackDate" Type="DateTime" />
            <asp:Parameter Name="FeedbackName" Type="String" />
            <asp:Parameter Name="FeedbackMail" Type="String" />
            <asp:Parameter Name="FeedbackMessage" Type="String" />
            <asp:Parameter Name="AutoId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </asp:Content>
