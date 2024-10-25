<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerHomePage.aspx.cs" Inherits="PSD.Views.CustomerHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1>Welcome</h1>
    <h2>Stationery</h2>
</div>
<div>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <div>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <a style="text-decoration:none; color: black;" href="StationeryDetail.aspx?id=<%# Eval("StationeryId") %>" class="btn btn-primary">

            <a 
                style="text-decoration:none; color: black;" 
                href='StationeryDetail.aspx?id=<%# Eval("StationeryId") %>' 
            >

                <div style="border:2px solid black; height: 100%; width: 200px;">
                    <div>
                        <h2><%# Eval("StationeryName") %></h2>
                        <p><strong>Price: </strong><%# Eval("StationeryPrice", "{0:C}") %></p>
                    </div>
                </div>
            </a>
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>
