<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/master.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Recruitment.Web.ControlPanel.Login" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="container">
        <div class="row text-center ">
            <div class="col-md-12">
                <br /><br />
                <h2> Recruitment.Web Admin : Login</h2>
               
                <h5>( Login yourself to get access )</h5>
                <br />
            </div>
        </div>
        <div class="row ">
               
            <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <strong>   Enter Details To Login </strong>  
                    </div>
                    <div class="panel-body">
                        <form role="form">
                            <br />
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>
                                <input type="text" class="form-control" placeholder="Your Username " />
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                <input type="password" class="form-control"  placeholder="Your Password" />
                            </div>
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <input type="checkbox" /> Remember me
                                </label>
                            </div>
                                 <asp:Button runat="server" class="btn btn-primary " Text="Login Now" ID="btnLogin" OnClick="btnLogin_Click"/>    
                            <hr />
                            <dx:ASPxLabel ID="lblStatus" runat="server" Text="Ready" Theme="Moderno">
                            </dx:ASPxLabel>
                        </form>
                        
                    </div>
                           
                </div>
            </div>
                
                
        </div>
    </div>
</asp:Content>
