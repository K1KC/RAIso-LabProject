<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStationery.aspx.cs" Inherits="PSD.Views.UpdateStationery1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <h2>Update Stationery</h2>
          <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
          <div>
            <asp:Label ID="lblStationeryID" runat="server" Text="Stationery ID: " />
            <asp:TextBox ID="txtStationeryID" runat="server" ReadOnly="True" />
          </div>
          <div>
            <asp:Label ID="lblStationeryName" runat="server" Text="Stationery Name: " />
            <asp:TextBox ID="txtStationeryName" runat="server" />
            <asp:RequiredFieldValidator ID="rfvStationeryName" runat="server" ControlToValidate="txtStationeryName" ErrorMessage="Stationery name is required." ForeColor="Red" />
            <asp:RegularExpressionValidator ID="revStationeryName" runat="server" ControlToValidate="txtStationeryName" ErrorMessage="Stationery name must be between 3 and 50 characters." ValidationExpression="^.{3,50}$" ForeColor="Red" />
          </div>
          <div>
            <asp:Label ID="lblStationeryPrice" runat="server" Text="Stationery Price: " />
            <asp:TextBox ID="txtStationeryPrice" runat="server" />
            <asp:RequiredFieldValidator ID="rfvStationeryPrice" runat="server" ControlToValidate="txtStationeryPrice" ErrorMessage="Price is required." ForeColor="Red" />
            <asp:RangeValidator ID="rvStationeryPrice" runat="server" ControlToValidate="txtStationeryPrice" ErrorMessage="Price must be numeric and greater than or equal to 2000." MinimumValue="2000" MaximumValue="1000000" Type="Integer" ForeColor="Red" />
          </div>
          <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
          </div>
        </div>
    </form>
</body>
</html>
