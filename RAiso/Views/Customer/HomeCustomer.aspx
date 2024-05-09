<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="HomeCustomer.aspx.cs" Inherits="RAiso.Views.Customer.HomeCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/HomeCustomer.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>View</h4>
            </div>
            <div class="view-stationery">
                <asp:Label CssClass="no-data" ID="lblNoData" runat="server" Text="-- There is no Data --" Visible="false"></asp:Label>
                <asp:GridView ID="gvStationery" runat="server" DataKeyNames="StationeryID" AutoGenerateColumns="False" OnSelectedIndexChanged="gvStationery_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="StationeryID" HeaderText="StationeryID" SortExpression="StationeryID" Visible="false" />
                        <asp:BoundField HeaderStyle-CssClass="column-header-stationery-name" ItemStyle-CssClass="column-value-stationery-name" DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
                        <asp:ButtonField HeaderStyle-CssClass="column-header-toggle" ItemStyle-CssClass="column-value-toggle" CommandName="Select" HeaderText="Toggle" ShowHeader="True" Text="Details" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
