<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="Recruitment.Web.Jobs" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
    <script>
        function Combo_ValueChanged(s, e) {
            dataView.PerformCallback(s.GetValue());
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br/><br/>
    <div class="container container-fluid">
            <dx:ASPxPanel ID="SelectorPanel" runat="server" ClientInstanceName="SelectorPanel" Paddings-PaddingTop="80" FixedPosition="WindowTop" >
            <PanelCollection>
                <dx:PanelContent>
                    <div class="container ">
                    <dx:ASPxComboBox runat="server" ID="ASPxComboBoxIndustry" ClientInstanceName="ASPxComboBoxIndustry"
                        DataSourceID="XpoDSIndustry" TextField="industry_name" ValueField="industry_id" ValueType="System.Int32"
                        Height="100%" Width="100%" Caption="Industry" Theme="Moderno">
                        <ClientSideEvents ValueChanged="Combo_ValueChanged" />
                    </dx:ASPxComboBox>
                        </div>
                </dx:PanelContent>
            </PanelCollection>
            <Paddings Padding="8px" />
        </dx:ASPxPanel>
    <dx:ASPxDataView ID="dataView" runat="server" DataSourceID="XpoDS" EnableCallbackAnimation="True" EnablePagingCallbackAnimation="True" 
        Width="100%" PagerAlign="Justify" ClientInstanceName="dataView"  OnCustomCallback="dataView_CustomCallback" Theme="Moderno">
        <SettingsTableLayout ColumnCount="1" RowsPerPage="10" />
        <PagerSettings ShowNumericButtons="False" EnableAdaptivity="True">
        </PagerSettings>
        <ItemTemplate>
            <div class="row">
                            <div class="col-sm-4 col-lg-12 col-md-8">
                                <table>
                                    <tr class="thumbnail">
                                <td class="col-sm-1 col-lg-1 col-md-1">
                                    <%--<dx:ASPxBinaryImage ID="ASPxBinaryImage2" Height="300px" runat="server" ContentBytes='<%# /*ConvertToByte((System.Drawing.Bitmap))*/Eval("jp_image") %>' />--%>
                                    <dx:ASPxImage ID="ASPxBinaryImage1"  Height="300px"  runat="server" ImageUrl='<%# Eval("jp_image", "~/img/job/{0}") %>' />
                                        </td>         
                                        <td class="col-sm-2 col-lg-2 col-md-2 caption" rowspan="2">
                                            <h4><a href="Apply.aspx?id=<%# System.Web.HttpUtility.HtmlEncode(Eval("job_post_id")) %>"><%# System.Web.HttpUtility.HtmlEncode(Eval("jp_title")) %></a></h4>
                                            <p>
                                                <span class="fa fa-calendar"></span> <%# System.Web.HttpUtility.HtmlEncode(Eval("jp_date_start", "{0:yyyy-MM-dd}")) %> 
                                                <span class="fa fa-industry"></span> <%# System.Web.HttpUtility.HtmlEncode(Eval("jp_industry_id[0].industry_name")) %>
                                                <span class="fa fa-users"></span> <%# System.Web.HttpUtility.HtmlEncode(Eval("jp_view_count")) + " Views" %>
                                            </p>
                                            <p><%# System.Web.HttpUtility.HtmlEncode(Eval("jp_content")) %></p>
                                            <br/>
                                            <div class="btn-group">
                                              <button class="btn btn-default btn-lg btn-success" type="button" onclick="window.location.href='Apply.aspx?id=<%# System.Web.HttpUtility.HtmlEncode(Eval("job_post_id")) %>';" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                APPLY NOW <span class="glyphicon glyphicon-ok"></span>
                                              </button>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
        </ItemTemplate>
        <ItemStyle Width="300px" />
    </dx:ASPxDataView>
        <dx:XpoDataSource ID="XpoDSIndustry" runat="server" 
        TypeName="Recruitment.Web.BO.Recruitment.rec_Industry">
    </dx:XpoDataSource>
    <dx:XpoDataSource ID="XpoDS" runat="server" Criteria="[jp_date_start] &lt;= ?Now And [jp_date_end] &gt;= ?Now And [jp_visible] = True And (?IndustyParam Is Null Or [jp_industry_id] = ?IndustyParam)" 
        TypeName="Recruitment.Web.BO.Recruitment.rec_job_post"
        DefaultSorting="jp_date_start Descending">
        <CriteriaParameters>
           <%--<asp:SessionParameter Name="IndustyParam" SessionField="IndustyParam" Type="Int32" />--%>
            <asp:Parameter Name="IndustyParam" />
            <asp:Parameter Name="Now" />
        </CriteriaParameters>
        
    </dx:XpoDataSource>
    </div>

</asp:Content>

