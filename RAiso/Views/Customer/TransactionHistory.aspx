<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="RAiso.Views.Customer.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/TransactionHistory.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="box">
            <div class="header">
                <h4>Transaction History</h4>
            </div>
            <div class="view-transaction-history">
                <asp:Label CssClass="no-data" ID="lblNoData" runat="server" Text="-- There is no Data --" Visible="false"></asp:Label>
                <asp:GridView ID="gvTransactionHistory" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvTransactionHistory_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderStyle-CssClass="column-header-transaction-id" ItemStyle-CssClass="column-value-transaction-id" DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                        <asp:BoundField HeaderStyle-CssClass="column-header-username" ItemStyle-CssClass="column-value-username" DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                        <asp:BoundField HeaderStyle-CssClass="column-header-transaction-date" ItemStyle-CssClass="column-value-transaction-date" DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                        <asp:ButtonField HeaderStyle-CssClass="column-header-toggle" ItemStyle-CssClass="column-value-toggle" ButtonType="Button" CommandName="Select" HeaderText="Toggle" ShowHeader="True" Text="Details" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
