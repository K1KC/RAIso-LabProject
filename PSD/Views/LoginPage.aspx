<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PSD.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoginPage</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>LOGIN</h1>
        <div style="margin-bottom: 10px;>
            <asp:Label ID="Lbl_UserName" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TBox_Username" runat="server"></asp:TextBox>
        </div>
        <div style="margin-bottom: 10px;>
            <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TBox_Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="CBox_RememberMe" runat="server" Text="Remember Me"/>
        </div>
        <div>
            <asp:Label ID="Lbl_Error" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="Btn_Login" runat="server" Text="Login" OnClick="LoginBtn_Click"/>
        </div>
    </form>
</body>
</html>