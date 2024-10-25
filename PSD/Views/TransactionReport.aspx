<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="PSD.Views.TransactionReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Lbl_TransactionReport" runat="server" Text="Transaction Report"></asp:Label>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID=""/>
</asp:Content>
