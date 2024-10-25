<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationeryDetail.aspx.cs" Inherits="PSD.Views.StationeryDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Lbl_Error" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Panel ID="Pnl_AddToCart" runat="server" Visible="false">
                <asp:Label ID="Lbl_StationeryName" runat="server" Text="Stationery Name"></asp:Label>
                <asp:Label ID="Lbl_StationeryPrice" runat="server" Text="Stationery Price"></asp:Label>

                <br />
                <asp:DropDownList ID="DDL_Stationery" runat="server"></asp:DropDownList>
                <br />

                <asp:TextBox ID="TBox_Quantity" runat="server"></asp:TextBox>
                <asp:Button ID="Btn_AddToCart" runat="server" Text="Add to Cart" OnClick="Btn_AddToCart_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
