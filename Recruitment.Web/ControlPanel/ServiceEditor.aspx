<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="ServiceEditor.aspx.cs" Inherits="Recruitment.Web.ServiceEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="AutoId" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True">
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="Header" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Body" VisibleIndex="2">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SortNumber" VisibleIndex="5" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="Enabled" VisibleIndex="6" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataComboBoxColumn FieldName="Symbol" VisibleIndex="4">
                <PropertiesComboBox DataSourceID="SqlDataSourceSymbol" TextField="Symbol" TextFormatString="{0}" ValueField="Symbol">
                    <Columns>
                        <dx:ListBoxColumn Caption="Symbol" FieldName="Symbol">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [Service] WHERE [AutoId] = ?" InsertCommand="INSERT INTO [Service] ( [Header], [Body], [Symbol], [SortNumber], [Enabled]) VALUES ( ?, ?, ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [AutoId], [Header], [Body], [Symbol], [SortNumber], [Enabled] FROM [Service]" UpdateCommand="UPDATE [Service] SET [Header] = ?, [Body] = ?, [Symbol] = ?, [SortNumber] = ?, [Enabled] = ? WHERE [AutoId] = ?">
        <DeleteParameters>
            <asp:Parameter Name="AutoId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Header" Type="String" />
            <asp:Parameter Name="Body" Type="String" />
            <asp:Parameter Name="Symbol" Type="String" />
            <asp:Parameter Name="SortNumber" Type="Int32" />
            <asp:Parameter Name="Enabled" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Header" Type="String" />
            <asp:Parameter Name="Body" Type="String" />
            <asp:Parameter Name="Symbol" Type="String" />
            <asp:Parameter Name="SortNumber" Type="Int32" />
            <asp:Parameter Name="Enabled" Type="Boolean" />
            <asp:Parameter Name="AutoId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSymbol" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT [Symbol] FROM [Symbol]">
    </asp:SqlDataSource>
</asp:Content>
