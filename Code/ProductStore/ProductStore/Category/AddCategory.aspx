<%@ Page Title="Product Store - Add Category" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="ProductStore.Category.AddCategory" %>

<%@ MasterType VirtualPath="~/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        table tr {
            padding: 0px 5px;
        }

        .LinkBackButton {
            padding: 5px 10%;
        }

        td input, td select {
            width: 90%;
            height: 25px;
            font-size: 13px;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <br />
    <div style="width: 100%;">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="ErrorMessage" Visible="false"></asp:Label>
    </div>
    <br />
    <div>
        <br />
        <table style="width: 500px; margin: auto; top: 5px;" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="vsAddCategory" runat="server" DisplayMode="BulletList" ShowSummary="true" ValidationGroup="vgAddCategory"
                        HeaderText="Errors:" ShowMessageBox="true" ShowValidationErrors="true" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Category Name</td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName" ValidationGroup="vgAddCategory"
                        ErrorMessage="Please enter category name." Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Category Description</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="vgAddCategory"
                        ErrorMessage="Please enter category description." Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="width: 80%; margin: auto;">
                        <tr>
                            <td>
                                <asp:Button ID="btnCategorySave" runat="server" OnClick="btnCategorySave_Click" ValidationGroup="vgAddCategory" CssClass="SubmitButton" Text="Save Categorys" />
                            </td>
                            <td>
                                <a href="Category.aspx" class="LinkBackButton">Back to list page</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <%--<a href="Category.aspx" class="LinkButton">Back to list page</a>--%>
    </div>
</asp:Content>
