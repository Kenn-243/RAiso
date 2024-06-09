<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavbarMaster.Master" AutoEventWireup="true" CodeBehind="CustomerCart.aspx.cs" Inherits="RAiso.Views.Customer.CustomerCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/CustomerCart.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
         <div class="box">
             <div class="header">
                 <h4>Cart</h4>
             </div>
             <div class="view-cart">
                 <asp:Label CssClass="no-data" ID="lblNoData" runat="server" Text="-- There is no Item --" Visible="false"></asp:Label>
                 <asp:GridView ID="gvCart" runat="server" DataKeyNames="UserID, StationeryID" AutoGenerateColumns="False" OnRowDeleting="gvCart_RowDeleting" OnRowEditing="gvCart_RowEditing" >
                     <Columns>
                         <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" Visible="false" />
                         <asp:BoundField DataField="StationeryID" HeaderText="StationeryID" SortExpression="StationeryID" Visible="false" />
                         <asp:BoundField HeaderStyle-CssClass="column-header-stationery-name" ItemStyle-CssClass="column-value-stationery-name" DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
                         <asp:BoundField HeaderStyle-CssClass="column-header-stationery-price" ItemStyle-CssClass="column-value-stationery-price" DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice" />
                         <asp:BoundField HeaderStyle-CssClass="column-header-quantity" ItemStyle-CssClass="column-value-quantity" DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                         <asp:ButtonField HeaderStyle-CssClass="column-header-update" ItemStyle-CssClass="column-button-update" ButtonType="Button" CommandName="Edit" HeaderText="Update" ShowHeader="True" Text="Update" />
                         <asp:ButtonField HeaderStyle-CssClass="column-header-delete" ItemStyle-CssClass="column-button-delete" ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" />
                     </Columns>
                 </asp:GridView>
             </div>
             <div class="checkout">
                 <asp:Button CssClass="button-checkout" ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click"/>
             </div>
         </div>
     </div>
</asp:Content>
