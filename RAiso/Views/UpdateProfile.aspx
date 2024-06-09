<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavbarMaster.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="RAiso.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/UpdateProfile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>Update Profile</h4>
            </div>
            <div class="inputs">
                <div class="name">
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox CssClass="name-input" ID="txtName" runat="server"></asp:TextBox>
                </div>
                <div class="date">
                    <asp:Label ID="lblDate" runat="server" Text="DOB"></asp:Label>
                    <asp:TextBox CssClass="date-input" ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="gender">
                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                    <asp:RadioButtonList CssClass="flex-container" RepeatDirection="horizontal" ID="rblGender" runat="server">
                        <asp:listitem Value="Male">Male</asp:listitem>
                        <asp:listitem Value="Female">Female</asp:listitem>
                    </asp:RadioButtonList>
                </div>
                <div class="address">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox CssClass="address-input" ID="txtAddress" runat="server"></asp:TextBox>
                </div>
                <div class="password">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox Cssclass="password-input" ID="txtPassword" runat="server"></asp:TextBox>
                </div>
                <div class="phone">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                    <asp:TextBox Cssclass="phone-input" ID="txtPhone" runat="server"></asp:TextBox>
                </div>
                <div class="error">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div class="button-update">
                    <asp:Button ID="btnUpdateUser" runat="server" Text="Update" OnClick="btnUpdateUser_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
