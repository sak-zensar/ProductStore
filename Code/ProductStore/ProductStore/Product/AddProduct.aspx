<%@ Page Title="Product Store - Add Product" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ProductStore.Product.AddProduct" %>

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
    <div style="width: 30%; margin: auto;">
        <h2 id="PageHeader">Add Product</h2>
    </div>
    <br />
    <div style="width: 100%;">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="ErrorMessage" Visible="false"></asp:Label>
    </div>
    <br />
    <div>
        <br />
        <table cellpadding="0" cellspacing="0" style="width: 500px; margin: auto; top: 5px;">
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="vsAddProduct" runat="server" DisplayMode="BulletList" ShowSummary="true" ValidationGroup="vgAddProduct" CssClass="ErrorMessage" HeaderText="Errors:" ShowMessageBox="true" ShowValidationErrors="true" />
                </td>
            </tr>
            <tr style="display: none;">
                <td style="text-align: left;">Product Id</td>
                <td>
                    <asp:HiddenField ID="hdProductId" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Product Name</td>
                <td>
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName" ValidationGroup="vgAddProduct" CssClass="ErrorMessage"
                        ErrorMessage="Please enter product name." Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Category</td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" InitialValue="0" ControlToValidate="ddlCategory" ValidationGroup="vgAddProduct" CssClass="ErrorMessage"
                        ErrorMessage="Please choose a category." Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Price</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price", "{0:$0.00}")%>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ValidationGroup="vgAddProduct" CssClass="ErrorMessage"
                        ErrorMessage="Please enter price." Display="Dynamic" />
                    <asp:CompareValidator ID="cfCurrency" runat="server" ControlToValidate="txtPrice" Operator="DataTypeCheck" ValidationGroup="vgAddProduct" CssClass="ErrorMessage"
                        Type="Currency" Display="Dynamic" ErrorMessage="Illegal format for currency" />
                    <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" ValidationGroup="vgAddProduct" CssClass="ErrorMessage"
                        ErrorMessage="Please enter price between (0-999)." MaximumValue="999"
                        MinimumValue="0" Type="Currency" Display="Dynamic">
                    </asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Currency</td>
                <td>
                    <asp:TextBox ID="txtCurrency" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ControlToValidate="txtCurrency"
                        ErrorMessage="Please enter currency." Display="Dynamic" ValidationGroup="vgAddProduct" CssClass="ErrorMessage" />

                </td>
            </tr>
            <tr>
                <td style="text-align: left;">Unit</td>
                <td>
                    <asp:DropDownList ID="ddlUnits" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvUnit" runat="server" ControlToValidate="ddlUnits" InitialValue="0" ValidationGroup="vgAddProduct" CssClass="ErrorMessage"
                        ErrorMessage="Please choose a unit." Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="width: 80%; margin: auto;">
                        <tr>
                            <td style="text-align: left;">
                                <asp:Button ID="btnProsuctSave" runat="server" OnClick="btnProsuctSave_Click" CssClass="SubmitButton" ValidationGroup="vgAddProduct" Text="Save Product" />
                            </td>
                            <td>
                                <a href="Product.aspx" class="LinkButton">Back to list page</a>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
