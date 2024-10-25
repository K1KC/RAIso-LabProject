<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="PSD.Views.AdminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Stationery</h2>
        <div>
            <asp:GridView ID="StationeryList" runat="server" AutoGenerateColumns="False" DataKeyNames="StationeryId" OnRowUpdating="StationeryList_RowUpdating" OnRowDeleting="StationeryList_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="StationeryID" HeaderText="ID" SortExpression="StationeryID" />
                    <asp:BoundField DataField="StationeryName" HeaderText="Stationery" SortExpression="StationeryName" />
                    <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice" />
                    <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Update Stationery" ShowHeader="True" Text="Update" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete Stationery" ShowHeader="True" Text="Delete" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="InsertStationery" runat="server" Text="Insert New Stationery" OnClick="InsertStationery_Click"/>
    </div>
</asp:Content>
