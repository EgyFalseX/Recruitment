<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="Recruitment.Web.Jobs" %>
<%@ Register assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Xpo.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Xpo" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    
    <dx:ASPxDataView ID="ASPxDataView1" runat="server" Theme="iOS" DataSourceID="XpoDS">
        <settingstablelayout columncount="1" rowsperpage="10" />
<PagerSettings ShowNumericButtons="False"></PagerSettings>
        <ItemTemplate>
            &nbsp;<table class="nav-justified">
                <tr>
                    <td>
                        <asp:Label ID="jp_titleLabel" runat="server" Text='<%# System.Web.HttpUtility.HtmlEncode(Eval("jp_title")) %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <dx:ASPxBinaryImage ID="jp_imageImage" runat="server" ContentBytes='<%# ConvertToByte((System.Drawing.Bitmap)Eval("jp_image")) %>'>
                        </dx:ASPxBinaryImage>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="jp_date_startLabel" runat="server" Text='<%# System.Web.HttpUtility.HtmlEncode(Eval("jp_date_start")) %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="jp_contentLabel" runat="server" Text='<%# System.Web.HttpUtility.HtmlEncode(Eval("jp_content")) %>' />
                    </td>
                </tr>
            </table>
            <br/>
        </ItemTemplate>
</dx:ASPxDataView>
    
    <dx:XpoDataSource ID="XpoDS" runat="server" Criteria="[jp_date_start] &lt;= ?Now And [jp_date_end] &gt;= ?Now And [jp_visible] = True" TypeName="Recruitment.Module.BusinessObjects.Recruitment.rec_job_post">
        <CriteriaParameters>
            <asp:Parameter Name="Now" />
        </CriteriaParameters>
    </dx:XpoDataSource>
    
</asp:Content>
