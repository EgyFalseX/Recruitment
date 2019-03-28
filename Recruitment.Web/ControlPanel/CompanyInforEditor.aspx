<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="CompanyInforEditor.aspx.cs" Inherits="Recruitment.Web.CompanyInforEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="AutoId" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True">
        <SettingsPager Visible="False">
        </SettingsPager>
        <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
        <Columns>
            <dx:GridViewCommandColumn Caption="Edit" ShowEditButton="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="1">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyEmail" VisibleIndex="4">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyPhone1" VisibleIndex="5">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyPhone2" VisibleIndex="6">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyMobile1" VisibleIndex="7">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyMobile2" VisibleIndex="8">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyAddress" VisibleIndex="9">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Facebook" FieldName="facebook" VisibleIndex="10">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Twitter" FieldName="twitter" VisibleIndex="11">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Youtube" FieldName="youtube" VisibleIndex="12">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Instagram" FieldName="instagram" VisibleIndex="13">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Dribbble" FieldName="dribbble" VisibleIndex="14">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Linkedin" FieldName="linkedin" VisibleIndex="15">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataMemoColumn FieldName="AboutUs" VisibleIndex="3">
                <EditFormSettings ColumnSpan="2" RowSpan="2" />
            </dx:GridViewDataMemoColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [CompanyInfo] WHERE [AutoId] = ?" InsertCommand="INSERT INTO [CompanyInfo] ( [CompanyName], [AboutUs], [CompanyEmail], [CompanyPhone1], [CompanyPhone2], [CompanyMobile1], [CompanyMobile2], [CompanyAddress], [facebook], [twitter], [youtube], [instagram], [dribbble], [linkedin]) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [AutoId], [CompanyName], [AboutUs], [CompanyEmail], [CompanyPhone1], [CompanyPhone2], [CompanyMobile1], [CompanyMobile2], [CompanyAddress], [facebook], [twitter], [youtube], [instagram], [dribbble], [linkedin] FROM [CompanyInfo]" UpdateCommand="UPDATE [CompanyInfo] SET [CompanyName] = ?, [AboutUs] = ?, [CompanyEmail] = ?, [CompanyPhone1] = ?, [CompanyPhone2] = ?, [CompanyMobile1] = ?, [CompanyMobile2] = ?, [CompanyAddress] = ?, [facebook] = ?, [twitter] = ?, [youtube] = ?, [instagram] = ?, [dribbble] = ?, [linkedin] = ? WHERE [AutoId] = ?">
        <DeleteParameters>
            <asp:Parameter Name="AutoId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="AboutUs" Type="String" />
            <asp:Parameter Name="CompanyEmail" Type="String" />
            <asp:Parameter Name="CompanyPhone1" Type="String" />
            <asp:Parameter Name="CompanyPhone2" Type="String" />
            <asp:Parameter Name="CompanyMobile1" Type="String" />
            <asp:Parameter Name="CompanyMobile2" Type="String" />
            <asp:Parameter Name="CompanyAddress" Type="String" />
            <asp:Parameter Name="facebook" Type="String" />
            <asp:Parameter Name="twitter" Type="String" />
            <asp:Parameter Name="youtube" Type="String" />
            <asp:Parameter Name="instagram" Type="String" />
            <asp:Parameter Name="dribbble" Type="String" />
            <asp:Parameter Name="linkedin" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="AboutUs" Type="String" />
            <asp:Parameter Name="CompanyEmail" Type="String" />
            <asp:Parameter Name="CompanyPhone1" Type="String" />
            <asp:Parameter Name="CompanyPhone2" Type="String" />
            <asp:Parameter Name="CompanyMobile1" Type="String" />
            <asp:Parameter Name="CompanyMobile2" Type="String" />
            <asp:Parameter Name="CompanyAddress" Type="String" />
            <asp:Parameter Name="facebook" Type="String" />
            <asp:Parameter Name="twitter" Type="String" />
            <asp:Parameter Name="youtube" Type="String" />
            <asp:Parameter Name="instagram" Type="String" />
            <asp:Parameter Name="dribbble" Type="String" />
            <asp:Parameter Name="linkedin" Type="String" />
            <asp:Parameter Name="AutoId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </asp:Content>
