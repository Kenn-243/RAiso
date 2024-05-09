<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateStationery.aspx.cs" Inherits="RAiso.Views.Admin.UpdateStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/UpdateStationery.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>Update Stationery</h4>
            </div>
            <div class="inputs">
                <div class="stationery-name">
                    <asp:Label ID="lblStationeryName" runat="server" Text="Stationery Name"></asp:Label>
                    <asp:TextBox CssClass="stationery-name-input" ID="txtStationeryName" runat="server"></asp:TextBox>
                </div>
                <div class="stationery-price">
                    <asp:Label ID="lblStationeryPrice" runat="server" Text="Stationery Price"></asp:Label>
                    <asp:TextBox CssClass="stationery-price-input" ID="txtStationeryPrice" runat="server" value="0" TextMode="Number"></asp:TextBox>
                </div>
                <div class="error">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div class="button-update-stationery">
                    <asp:Button ID="btnUpdateStationery" runat="server" Text="Update Stationery" OnClick="btnUpdateStationery_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
