<%@ Page Title="TransactionHistory" Language="C#" MasterPageFile="~/Views/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="PSD.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Lbl_TransactionHistory" runat="server" Text="Transaction History"></asp:Label>
    <asp:GridView ID="GV_TransactionHistory" runat="server" AutoGenerateColumns="false" OnRowCommand="GV_TransactionHistory_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName"></asp:BoundField>
            <asp:TemplateField HeaderText="Transaction Detail">
                <ItemTemplate>
                    <asp:Button ID="Btn_TransactionDetail" runat="server" Text="Detail" CommandName="ShowTransactionDetail" CommandArgument='<%# Eval("TransactionID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>
