<%@ Page Title="Product Store - Add Category" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="ProductStore.Category.AddCategory" %>

<%@ MasterType VirtualPath="~/Shared/Site.Master" %>

<asp:Content ID="cphAddCategoryHead" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../Contents/AddCategoryStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="cphAddCategoryBody" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="width: 30%; margin: auto;">
        <h2 id="PageHeader">Add Category</h2>
    </div>
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
                    <asp:ValidationSummary ID="vsAddCategory" runat="server" DisplayMode="BulletList" ShowSummary="true" ValidationGroup="vgAddCategory" CssClass="ErrorMessage"
                        HeaderText="Errors:" ShowMessageBox="true" ShowValidationErrors="true" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Category Name</td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName" ValidationGroup="vgAddCategory" CssClass="ErrorMessage"
                        ErrorMessage="Please enter category name." Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Category Description</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="vgAddCategory" CssClass="ErrorMessage"
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
