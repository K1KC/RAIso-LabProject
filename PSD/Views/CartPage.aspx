<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="PSD.Views.CartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Your Shopping Cart</h1>
            <asp:GridView ID="GV_Cart" runat="server" AutoGenerateColumns="False" OnRowCommand="GV_Cart_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Btn_Update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Eval("StationeryID") %>' />
                            <asp:Button ID="Btn_Remove" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("StationeryID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="Btn_Checkout" runat="server" Text="Checkout" OnClick="Btn_Checkout_Click" />
        </div>
    </form>
</body>
</html>
