<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="RAiso.Views.Customer.UpdateCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/UpdateCart.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">
         <div class="box">
             <div class="header">
                 <h4>Update Cart</h4>
             </div>
             <div class="inputs">
                 <div class="stationery-name">
                     <asp:Label ID="lblStatinoeryNameText" runat="server" Text="Stationery Name:"></asp:Label>
                     <asp:Label ID="lblStationeryName" runat="server"></asp:Label>
                 </div>
                 <div class="stationery-price">
                     <asp:Label ID="lblStationeryPriceText" runat="server" Text="Stationery Price:"></asp:Label>
                     <asp:Label ID="lblStationeryPrice" runat="server"></asp:Label>
                 </div>
                 <div class="quantity">
                    <asp:Label CssClass="lblQuantity" ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
                    <asp:TextBox CssClass="input-quantity" ID="txtQuantity" runat="server" value="0" TextMode="Number"></asp:TextBox>
                </div>
                 <div class="error">
                     <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                 </div>
                 <div class="button-update-cart">
                     <asp:Button ID="btnUpdateCart" runat="server" Text="Update Cart" OnClick="btnUpdateCart_Click"/>
                 </div>
             </div>
         </div>
     </div>
</asp:Content>
