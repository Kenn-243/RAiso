<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="RAiso.Views.Customer.TransactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/TransactionDetails.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>Transaction Details</h4>
            </div>
            <div class="view-transaction-details">
                <asp:Label CssClass="no-data" ID="lblNoData" runat="server" Text="-- There is no Data --" Visible="false"></asp:Label>
                <asp:GridView ID="gvTransactionDetails" runat="server" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField HeaderStyle-CssClass="column-header-stationery-name" ItemStyle-CssClass="column-value-name" DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
                        <asp:BoundField HeaderStyle-CssClass="column-header-stationery-price" ItemStyle-CssClass="column-value-name" DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice" />
                        <asp:BoundField HeaderStyle-CssClass="column-header-quantity" ItemStyle-CssClass="column-value-quantity" DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
