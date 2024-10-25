<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="PSD.Views.TransactionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" Text="Transaction Detail"></asp:Label>
    <asp:Label ID="Lbl_Error" runat="server" Text="No detail available" Visible="false"></asp:Label>
    <asp:GridView ID="GV_TransactionDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName"></asp:BoundField>
            <asp:BoundField DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice"></asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="Btn_Back" runat="server" Text="Back" Onclick="Btn_Back_Click"/>
</asp:Content>
