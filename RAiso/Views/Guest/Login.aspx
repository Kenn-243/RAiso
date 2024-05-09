<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Guest/Guest.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAiso.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>Login</h4>
            </div>
            <div class="inputs">
                <div class="name">
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox Cssclass="name-input" ID="txtName" runat="server"></asp:TextBox>
                </div>
                <div class="password">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox Cssclass="password-input" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="remember-me">
                    <asp:CheckBox ID="cbRememberMe" runat="server" />
                    <asp:Label Cssclass="remember-me-input" ID="lblRememberMe" runat="server" Text="Remember Me"></asp:Label>
                </div>
                <div class="error">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div class="button-login">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
