<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavbarMaster.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAiso.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Home.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>View</h4>
                <asp:Button CssClass="insert-button-style" ID="btnInsert" runat="server" Text="Insert Stationery" OnClick="btnInsert_Click" Visible="false"/>
            </div>
            <div class="view-stationery">
                <asp:Label CssClass="no-data" ID="lblNoData" runat="server" Text="-- There is no Data --" Visible="false"></asp:Label>
                <asp:GridView ID="gvStationery" runat="server" DataKeyNames="StationeryID" AutoGenerateColumns="False" OnRowDeleting="gvStationery_RowDeleting" OnRowEditing="gvStationery_RowEditing" OnSelectedIndexChanged="gvStationery_SelectedIndexChanged" >
                    <Columns>
                        <asp:BoundField DataField="StationeryID" HeaderText="StationeryID" SortExpression="StationeryID" Visible="false" />
                        <asp:BoundField HeaderStyle-CssClass="column-header-stationery-name" ItemStyle-CssClass="column-value-stationery-name" DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
                        <asp:ButtonField HeaderStyle-CssClass="column-header-toggle" ItemStyle-CssClass="column-value-toggle" CommandName="Select" HeaderText="Toggle" ShowHeader="True" Text="Details" />
                        <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Update" ShowHeader="True" Text="Update" Visible="false" />
                        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" Visible="false" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
