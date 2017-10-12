<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="JobsEditor.aspx.cs" Inherits="Recruitment.Web.JobsEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="job_post_id" Theme="Moderno" Width="100%" EnablePagingCallbackAnimation="True" OnStartRowEditing="ASPxGridViewMain_StartRowEditing">
        <Settings ShowFilterRow="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="job_post_id" VisibleIndex="1" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="jp_title" VisibleIndex="2" Caption="Title">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="jp_content" VisibleIndex="8" Caption="content">
                <EditFormSettings ColumnSpan="2" />
                <EditItemTemplate>
                    <dx:ASPxHtmlEditor ID="ASPxHtmlEditorHeader" runat="server" Html='<%# Bind("jp_content") %>' Theme="Moderno" Width="100%" >
                        <SettingsDialogs>
                            <InsertImageDialog>
                                <SettingsImageUpload AdvancedUploadModeTemporaryFolder="~\App_Data\UploadTemp\" FileSystemSettings-UploadFolder="~/img/other/">
                                </SettingsImageUpload>
                            </InsertImageDialog>
                        </SettingsDialogs>
                    </dx:ASPxHtmlEditor>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="jp_date_start" VisibleIndex="4" Caption="Air Date">
                <PropertiesDateEdit DisplayFormatString="d/M/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="jp_date_end" VisibleIndex="5" Caption="End Date">
                <PropertiesDateEdit DisplayFormatString="d/M/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataCheckColumn FieldName="jp_visible" VisibleIndex="7" Caption="Visible">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataTextColumn FieldName="ImgPath" VisibleIndex="3" Caption="Image">
                <EditFormSettings ColumnSpan="2" />
                <DataItemTemplate>
                    <dx:ASPxImage ID="ASPxImageMain" runat="server" Height="64px" ImageUrl='<%# Eval("jp_image", "~/img/job/{0}") %>' ShowLoadingImage="True" Width="64px">
                    </dx:ASPxImage>
                </DataItemTemplate>
                <EditItemTemplate>
                    <dx:ASPxUploadControl ID="ASPxUploadControlMain" runat="server" AutoStartUpload="True" OnFileUploadComplete="ASPxUploadControlMain_FileUploadComplete" ShowProgressPanel="True" ShowUploadButton="True" Theme="Moderno" UploadMode="Advanced" UploadStorage="FileSystem" Width="280px">
                        <FileSystemSettings UploadFolder="~/img/job/" />
                    </dx:ASPxUploadControl>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Industry" FieldName="jp_industry_id" VisibleIndex="6">
                <PropertiesComboBox DataSourceID="SqlDataSourceIndustry" TextField="industry_name" ValueField="industry_id">
                    <Columns>
                        <dx:ListBoxColumn FieldName="industry_name" Name="Industry">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [rec_job_post] WHERE [job_post_id] = ?" InsertCommand="INSERT INTO [rec_job_post] ( [jp_title], [jp_content], [jp_date_start], [jp_date_end], [jp_industry_id], [jp_image], [jp_visible]) VALUES (?, ?, ?, ?, ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [job_post_id], [jp_title], [jp_content], [jp_date_start], [jp_date_end], [jp_industry_id], [jp_image], [jp_visible] FROM [rec_job_post]" UpdateCommand="UPDATE [rec_job_post] SET [jp_title] = ?, [jp_content] = ?, [jp_date_start] = ?, [jp_date_end] = ?, [jp_industry_id] = ?, [jp_image] = ?, [jp_visible] = ? WHERE [job_post_id] = ?" OnInserting="SqlDataSourceMain_Inserting" OnUpdating="SqlDataSourceMain_Updating">
        <DeleteParameters>
            <asp:Parameter Name="job_post_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="jp_title" Type="String" />
            <asp:Parameter Name="jp_content" Type="String" />
            <asp:Parameter Name="jp_date_start" Type="DateTime" />
            <asp:Parameter Name="jp_date_end" Type="DateTime" />
            <asp:Parameter Name="jp_industry_id" Type="Int32" />
            <asp:Parameter Name="jp_image" Type="String" />
            <asp:Parameter Name="jp_visible" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="jp_title" Type="String" />
            <asp:Parameter Name="jp_content" Type="String" />
            <asp:Parameter Name="jp_date_start" Type="DateTime" />
            <asp:Parameter Name="jp_date_end" Type="DateTime" />
            <asp:Parameter Name="jp_industry_id" Type="Int32" />
            <asp:Parameter Name="jp_image" Type="String" />
            <asp:Parameter Name="jp_visible" Type="Boolean" />
            <asp:Parameter Name="job_post_id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceIndustry" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT [industry_id], [industry_name] FROM [rec_Industry]" OnInserting="SqlDataSourceMain_Inserting" OnUpdating="SqlDataSourceMain_Updating">
    </asp:SqlDataSource>
</asp:Content>
