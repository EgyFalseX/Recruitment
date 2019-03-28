<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="JobApplyEditor.aspx.cs" Inherits="Recruitment.Web.JobApplyEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="job_post_apply_id" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True">
        <Settings ShowFilterRow="True" />
        <Columns>
            <dx:GridViewDataTextColumn FieldName="job_post_apply_id" VisibleIndex="0" Caption="ID" ShowInCustomizationForm="True" ReadOnly="True">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Apply Date" FieldName="apply_date" ShowInCustomizationForm="True" VisibleIndex="2">
                <PropertiesDateEdit DisplayFormatString="d/M/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn Caption="Name" FieldName="apply_name" ShowInCustomizationForm="True" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Mobile" FieldName="apply_mobile" ShowInCustomizationForm="True" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Applicant" FieldName="applicant_id" ShowInCustomizationForm="True" Visible="False" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Post" FieldName="job_post_id" ShowInCustomizationForm="True" VisibleIndex="1">
                <PropertiesComboBox DataSourceID="SqlDataSourceJobs" TextField="jp_title" ValueField="job_post_id">
                    <Columns>
                        <dx:ListBoxColumn Caption="Title" FieldName="jp_title">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Gender" FieldName="apply_gender_id" ShowInCustomizationForm="True" VisibleIndex="4">
                <PropertiesComboBox DataSourceID="SqlDataSourceGender" TextField="rec_gender_name" ValueField="rec_gender_id">
                    <Columns>
                        <dx:ListBoxColumn Caption="Gender" FieldName="rec_gender_name">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Nationality" FieldName="apply_nationality_id" ShowInCustomizationForm="True" VisibleIndex="5">
                <PropertiesComboBox DataSourceID="SqlDataSourceNationality" TextField="nationality_name" ValueField="nationality_id">
                    <Columns>
                        <dx:ListBoxColumn Caption="Nationality" FieldName="nationality_name">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataHyperLinkColumn Caption="Attachment" FieldName="attach_file" VisibleIndex="7">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="~/Jobs/attachments/{0}" TextFormatString="Download File">
                </PropertiesHyperLinkEdit>
            </dx:GridViewDataHyperLinkColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [rec_job_post_apply] WHERE [job_post_apply_id] = ?" InsertCommand="INSERT INTO [rec_job_post_apply] ( [job_post_id], [apply_date], [apply_name], [apply_gender_id], [apply_nationality_id], [apply_mobile], [attach_file], [applicant_id]) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [job_post_apply_id], [job_post_id], [apply_date], [apply_name], [apply_gender_id], [apply_nationality_id], [apply_mobile], [attach_file], [applicant_id] FROM [rec_job_post_apply]" UpdateCommand="UPDATE [rec_job_post_apply] SET [job_post_id] = ?, [apply_date] = ?, [apply_name] = ?, [apply_gender_id] = ?, [apply_nationality_id] = ?, [apply_mobile] = ?, [attach_file] = ?, [applicant_id] = ? WHERE [job_post_apply_id] = ?">
        <DeleteParameters>
            <asp:Parameter Name="job_post_apply_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="job_post_id" Type="Int32" />
            <asp:Parameter Name="apply_date" Type="DateTime" />
            <asp:Parameter Name="apply_name" Type="String" />
            <asp:Parameter Name="apply_gender_id" Type="Int32" />
            <asp:Parameter Name="apply_nationality_id" Type="Int32" />
            <asp:Parameter Name="apply_mobile" Type="String" />
            <asp:Parameter Name="attach_file" Type="String" />
            <asp:Parameter Name="applicant_id" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="job_post_id" Type="Int32" />
            <asp:Parameter Name="apply_date" Type="DateTime" />
            <asp:Parameter Name="apply_name" Type="String" />
            <asp:Parameter Name="apply_gender_id" Type="Int32" />
            <asp:Parameter Name="apply_nationality_id" Type="Int32" />
            <asp:Parameter Name="apply_mobile" Type="String" />
            <asp:Parameter Name="attach_file" Type="String" />
            <asp:Parameter Name="applicant_id" Type="Int32" />
            <asp:Parameter Name="job_post_apply_id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceJobs" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT [job_post_id], [jp_title] FROM [rec_job_post]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGender" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT [rec_gender_id], [rec_gender_name] FROM [rec_Gender]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceNationality" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT [nationality_id], [nationality_name] FROM [rec_Nationality]">
    </asp:SqlDataSource>
    </asp:Content>
