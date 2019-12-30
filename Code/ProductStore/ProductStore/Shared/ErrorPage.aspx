<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="ProductStore.Shared.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="width: 90%; margin: auto;">
        <label id="lblErrorMessage" runat="server"></label>
        <br />
        <label id="lblInnerMessage" runat="server" visible="false"></label>
        <br />
        <label id="lblStackTrace" runat="server" visible="false"></label>
        <br />
        <a id="BackToProductPage" href="../Product/Product.aspx">Back To Product</a>
    </div>
</asp:Content>
