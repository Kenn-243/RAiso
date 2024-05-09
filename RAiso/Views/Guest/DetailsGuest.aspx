<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Guest/Guest.Master" AutoEventWireup="true" CodeBehind="DetailsGuest.aspx.cs" Inherits="RAiso.Views.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/DetailsGuest.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>View</h4>
            </div>
            <div class="view-details-guest">
                <asp:GridView ID="gvDetailsGuest" runat="server" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField HeaderStyle-CssClass="column-header-stationery-name" ItemStyle-CssClass="column-value-stationery-name" DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
                        <asp:BoundField HeaderStyle-CssClass="column-header-stationery-price" ItemStyle-CssClass="column-value-stationery-name" DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
