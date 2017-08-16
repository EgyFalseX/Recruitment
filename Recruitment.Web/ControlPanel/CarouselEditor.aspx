<%@ Page Title="" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="CarouselEditor.aspx.cs" Inherits="Recruitment.Web.CarouselEditor" %>

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
            <dx:GridViewDataTextColumn FieldName="ImgPath" VisibleIndex="2">
                <EditFormSettings ColumnSpan="2" />
                <DataItemTemplate>
                    <dx:ASPxImage ID="ASPxImageMain" runat="server" Height="64px" ImageUrl='<%# Eval("ImgPath", "~/img/carousel/{0}") %>' ShowLoadingImage="True" Width="64px">
                    </dx:ASPxImage>
                </DataItemTemplate>
                <EditItemTemplate>
                    <dx:ASPxUploadControl ID="ASPxUploadControlMain" runat="server" AutoStartUpload="True" OnFileUploadComplete="ASPxUploadControlMain_FileUploadComplete" ShowProgressPanel="True" ShowUploadButton="True" Theme="Moderno" UploadMode="Advanced" UploadStorage="FileSystem" Width="280px">
                        <FileSystemSettings UploadFolder="~/img/carousel/" />
                    </dx:ASPxUploadControl>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Header" VisibleIndex="3">
                <EditFormSettings ColumnSpan="2" />
                <EditItemTemplate>
                    <dx:ASPxHtmlEditor ID="ASPxHtmlEditorHeader" image runat="server" Html='<%# Bind("Header") %>' Theme="Moderno" Width="100%" >
                        <SettingsDialogs>
                            <InsertImageDialog>
                                <SettingsImageUpload AdvancedUploadModeTemporaryFolder="~\App_Data\UploadTemp\" FileSystemSettings-UploadFolder="~/img/other/">
                                </SettingsImageUpload>
                            </InsertImageDialog>
                        </SettingsDialogs>
                    </dx:ASPxHtmlEditor>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SortNumber" VisibleIndex="4" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="Enabled" VisibleIndex="5" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataCheckColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recruitment.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [Carousel] WHERE [AutoId] = ?" InsertCommand="INSERT INTO [Carousel] ( [ImgPath], [Header], [SortNumber], [Enabled]) VALUES ( ?, ?, ?, ?)" ProviderName="System.Data.OleDb" SelectCommand="SELECT [AutoId], [ImgPath], [Header], [SortNumber], [Enabled] FROM [Carousel]" UpdateCommand="UPDATE [Carousel] SET [ImgPath] = ?, [Header] = ?, [SortNumber] = ?, [Enabled] = ? WHERE [AutoId] = ?" OnInserting="SqlDataSourceMain_Inserting" OnUpdating="SqlDataSourceMain_Updating">
        <DeleteParameters>
            <asp:Parameter Name="AutoId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ImgPath" Type="String" />
            <asp:Parameter Name="Header" Type="String" />
            <asp:Parameter Name="SortNumber" Type="Int32" />
            <asp:Parameter Name="Enabled" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ImgPath" Type="String" />
            <asp:Parameter Name="Header" Type="String" />
            <asp:Parameter Name="SortNumber" Type="Int32" />
            <asp:Parameter Name="Enabled" Type="Boolean" />
            <asp:Parameter Name="AutoId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
