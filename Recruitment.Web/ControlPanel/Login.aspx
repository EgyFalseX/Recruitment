<%@ Page Title="" Language="C#" MasterPageFile="master.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Recruitment.Web.ControlPanel.Login" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="container">
        <div class="row text-center ">
            <div class="col-md-12">
                <br />
                <br />
                <h2>Recruitment.Web Admin : Login</h2>

                <h5>( Login yourself to get access )</h5>
                <br />
            </div>
        </div>
        <div class="row ">

            <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <strong>Enter Details To Login </strong>
                    </div>
                    <div class="panel-body">
                        <div role="form">
                            <br />
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                <dx:BootstrapTextBox ID="txtUser" class="form-control" runat="server">
                                    <ValidationSettings ValidationGroup="vg">
                                        <RequiredField IsRequired="True" ErrorText="Please enter your user name" />
                                    </ValidationSettings>
                                </dx:bootstrapTextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                <dx:BootstrapTextBox ID="txtPass" class="form-control" runat="server" Password="True">
                                    <ValidationSettings ValidationGroup="vg">
                                        <RequiredField IsRequired="True" ErrorText="Please enter your password" />
                                    </ValidationSettings>
                                </dx:BootstrapTextBox>
                            </div>
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <input type="checkbox" />
                                    Remember me
                                </label>
                            </div>
                            <dx:BootstrapButton class="btn btn-primary" ID="btnLogin" runat="server" Text="Login Now" ValidationGroup="vg" OnClick="btnLogin_Click" EnableTheming="True"></dx:BootstrapButton>
                            <hr />
                            <dx:BootstrapTextBox ID="txtStatus" runat="server" ReadOnly="True" ></dx:BootstrapTextBox>
                            
                        </div>

                    </div>

                </div>
            </div>


        </div>
    </div>
</asp:Content>

