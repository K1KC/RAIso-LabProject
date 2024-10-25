<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="PSD.Views.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Profile</h1>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"></asp:ValidationSummary>
            <asp:Label ID="Lbl_Message" runat="server" Forecolor="Green" visible="false"></asp:Label>
            <div>
                <asp:Label ID="Lbl_Name" runat="server" Text="Name: "></asp:Label>
                <asp:TextBox ID="TBox_Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Name" runat="server" ControlToValidate="TBox_Name" ErrorMessage="Name must be filled in"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_Name" runat="server" ControlToValidate="TBox_Name" ErrorMessage="Name must be between 5 and 50 characters" ValidationExpression="^.{5,50}$"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CV_Unique" runat="server" ControlToValidate="TBox_Name" OnServerValidate="CV_Unique_ServerValidate" ErrorMessage="Name must be unique"></asp:CustomValidator>
            </div>
            <div>
                <asp:Label ID="Lbl_DoB" runat="server" Text="Date of Birth: "></asp:Label>
                <asp:TextBox ID="TBox_DoB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_DoB" runat="server" ControlToValidate="TBox_DoB" ErrorMessage="Date of Birth must be filled in"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CV_DoB" runat="server" ControlToValidate="TBox_DoB" OnServerValidate="CV_DoB_ServerValidate" ErrorMessage="You must be at least 1 year age"></asp:CustomValidator>
            </div>
            <div>
                <asp:Label ID="Lbl_Gender" runat="server" Text="Gender: "></asp:Label>
                <asp:DropDownList ID="DDL_Gender" runat="server">
                    <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem> 
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFV_Gender" runat="server" ControlToValidate="DDL_Gender" InitialValue="" ErrorMessage="Gender must be filled in"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="Lbl_Address" runat="server" Text="Address: "></asp:Label>
                <asp:TextBox ID="TBox_Address" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Address" runat="server" ControlToValidate="TBox_Address" ErrorMessage="Address must be filled in"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="Lbl_Password" runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="TBox_Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Password" runat="server" ControlToValidate="TBox_Password" ErrorMessage="Password must be filled in"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_Password" runat="server" ControlToValidate="TBox_Password" ErrorMessage="Password must be alphanumeric" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Lbl_Phone" runat="server" Text="Phone: "></asp:Label>
                <asp:TextBox ID="TBox_Phone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Phone" runat="server" ControlToValidate="TBox_Phone" ErrorMessage="Phone must be filled in"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Button ID="Btn_Update" runat="server" Text="Update" OnClick="Btn_Update_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
