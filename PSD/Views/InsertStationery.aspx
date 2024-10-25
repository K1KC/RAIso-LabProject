<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertStationery.aspx.cs" Inherits="PSD.Views.InsertStationery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Insert Stationery</h2>
            <asp:Label ID="Lbl_Name" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="TBox_Name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Name" runat="server" ControlToValidate="TBox_Name" ErrorMessage="Name is required." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RV_Name" runat="server" ControlToValidate="TBox_Name" ErrorMessage="Name must be filled between 3-50 characters." ValidationExpression="^.{3,50}$" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>

        <div>
            <asp:Label ID="Lbl_Price" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="TBox_Price" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Price" runat="server" ControlToValidate="TBox_Price" ErrorMessage="Price is required." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RV_Price" runat="server" ControlToValidate="TBox_Price" MinimumValue="2000" MaximumValue="1000000" Type="Integer" ErrorMessage="Price must be at least 2000." Display="Dynamic"></asp:RangeValidator>
        </div>

        <div>
            <asp:Label ID="Lbl_Error" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:Button ID="Btn_Insert" runat="server" Text="Insert" OnClick="Btn_Insert_Click" />
        </div>
    </form>
</body>
</html>
