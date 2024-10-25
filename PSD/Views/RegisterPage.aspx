<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PSD.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RegisterPage</title>
</head>

<body>
      <form id="form1" runat="server">
      <h1>Register</h1>
      <div style="margin-bottom: 10px;">
          <asp:Label ID="Lbl_Username" runat="server" Text="Name"></asp:Label>
          <asp:TextBox ID="TBox_Username" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RFV_UserName" runat="server" ControlToValidate="TBox_Username" ErrorMessage="Name must be filled in"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="REV_UserName" runat="server" ControlToValidate="TBox_Username" ErrorMessage="Name must be between 5 and 50 characters" ValidationExpression="^.{5,50}$"></asp:RegularExpressionValidator>
      </div>
      <div style="margin-bottom: 10px;">
          <asp:Label ID="Lbl_DOB" runat="server" Text="DOB"></asp:Label>
          <asp:TextBox ID="TBox_DOB" runat="server" TextMode="Date"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RFV_DOB" runat="server" ControlToValidate="TBox_DOB" ErrorMessage="Date of Birth must be filled in"></asp:RequiredFieldValidator>
          <asp:CustomValidator ID="CV_DOB" runat="server" ControlToValidate="TBox_DOB" OnServerValidate="CV_DOB_ServerValidate" ErrorMessage="You must be at least 1 year age"></asp:CustomValidator>
      </div>
      <div style="margin-bottom: 10px;">
          <asp:Label ID="Lbl_Gender" runat="server" Text="Gender"></asp:Label>
          <asp:DropDownList ID="DDL_Gender" runat="server">
              <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
              <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator ID="RFV_Gender" runat="server" ControlToValidate="DDL_Gender" InitialValue="" ErrorMessage="Gender must be filled in"></asp:RequiredFieldValidator>
      </div>
      <div style="margin-bottom: 10px;">
          <asp:Label ID="Lbl_Address" runat="server" Text="Address"></asp:Label>
          <asp:TextBox ID="TBox_Address" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RFV_Address" runat="server" ControlToValidate="TBox_Address" ErrorMessage="Address must be filled in"></asp:RequiredFieldValidator>
      </div>
      <div style="margin-bottom: 10px;">
          <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
          <asp:TextBox ID="TBox_Password" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RFV_Password" runat="server" ControlToValidate="TBox_Password" ErrorMessage="Password must be filled in"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="REV_Password" runat="server" ControlToValidate="TBox_Password" ErrorMessage="Password must be alphanumeric" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
      </div>
      <div style="margin-bottom: 10px;">
          <asp:Label ID="Lbl_Phone" runat="server" Text="Phone"></asp:Label>
          <asp:TextBox ID="TBox_Phone" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RFV_Phone" runat="server" ControlToValidate="TBox_Phone" ErrorMessage="Phone must be filled in"></asp:RequiredFieldValidator>
      </div>
      <div style="margin-bottom: 10px;">
          <asp:Label ID="Lbl_Error" runat="server" Text=""></asp:Label>
          <asp:Button ID="Btn_Register" runat="server" Text="Register" OnClick="Btn_Register_Click" />
      </div>
  </form>
</body>
</html>