<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="DetailsCustomer.aspx.cs" Inherits="RAiso.Views.Customer.DetailsCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/DetailsCustomer.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>Details</h4>
            </div>
            <div class="view-stationery">
                <div class="stationery-name">
                    <asp:Label CssClass="stationery-name-header" ID="lblStationeryName" runat="server" Text="Stationery Name"></asp:Label>
                    <asp:Label CssClass="stationery-name-value" ID="lblStationeryNameValue" runat="server"></asp:Label>
                </div>
                <div class="stationery-price">
                     <asp:Label CssClass="stationery-price-header" ID="lblStationeryPrice" runat="server" Text="Stationery Price"></asp:Label>
                     <asp:Label CssClass="stationery-price-value" ID="lblStationeryPriceValue" runat="server"></asp:Label>
                </div>
                <div class="stationery-quantity">
                    <asp:Label CssClass="stationery-quantity-header" ID="lblStationeryQuantity" runat="server" Text="Quantity"></asp:Label>
                    <div class="quantity">
                         <asp:TextBox CssClass="quantity-input" ID="txtQuantity" runat="server" TextMode="Number" Value="0"></asp:TextBox>
                         <asp:Button CssClass="quantity-button" ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="AddToCart_Click"/>
                    </div>
                     <asp:Label CssClass="quantity-error" ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
