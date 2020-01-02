<%@ Page Title="Product Store - Product" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ProductStore.Product.Product" %>

<%@ MasterType VirtualPath="~/Shared/Site.Master" %>
<asp:Content ID="cphProductHead" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../Contents/ProductStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="cphProductBody" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="width: 30%; margin: auto;">
        <h2 id="PageHeader">Products</h2>
    </div>
    <br />
    <div style="width: 100%;">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="ErrorMessage" Visible="false"></asp:Label>
    </div>
    <br />
    <div style="width: 100%;">
        <div style="width: 10%; float: left">
            <a id="btnAddProsuct" runat="server" class="LinkButton" href="AddProduct.aspx"><i class="icon-expand"></i>Add Product </a>
        </div>
        <div style="width: 90%; float: right" class="SearchControls">
            <asp:DropDownList ID="ddlSearchCategory" runat="server" Width="200px"></asp:DropDownList>
            <asp:DropDownList ID="ddlSearchUnit" runat="server" Width="200px"></asp:DropDownList>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
    </div>
    <br />
    <br />
    <div style="width: 100%; margin: auto; top: 5px;">
        <asp:GridView ID="ProductGrid" runat="server" PageSize="20" AllowPaging="True" DataKeyField="ProductId" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="Both" OnRowDataBound="ProductGrid_RowDataBound" OnRowEditing="ProductGrid_RowEditing"
            OnRowDeleting="ProductGrid_RowDeleting" OnPreRender="ProductGrid_PreRender" OnRowCancelingEdit="ProductGrid_RowCancelingEdit"
            OnRowUpdating="ProductGrid_RowUpdating" OnPageIndexChanging="ProductGrid_PageIndexChanging"
            ShowHeaderWhenEmpty="true" EmptyDataText="No records Found.">
            <Columns>
                <asp:TemplateField HeaderText="Product Id" ItemStyle-Width="7%" HeaderStyle-Width="7%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblProductId" runat="server" Text='<%#Eval("ProductId") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblDispProductId" runat="server" Text='<%#Eval("ProductId") %>'></asp:Label>
                        <%--<asp:HiddenField ID="hfProductId" runat="server" Value='<%#Eval("ProductId") %>' />--%>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="20%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductName" runat="server" Width="90%" Text='<%#Eval("ProductName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName" ValidationGroup="vgUpdateProduct" CssClass="ErrorMessage"
                            ErrorMessage="Please enter product name." Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category" ItemStyle-Width="20%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="hfCategory" runat="server" Value='<%#Eval("Category") %>' />
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="90%"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" InitialValue="0" ControlToValidate="ddlCategory" ValidationGroup="vgUpdateProduct" CssClass="ErrorMessage"
                            ErrorMessage="Please choose a category." Display="Dynamic" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("Price") %>' Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ValidationGroup="vgUpdateProduct" CssClass="ErrorMessage"
                            ErrorMessage="Please enter price." Display="Dynamic" />
                        <asp:CompareValidator ID="cfCurrency" runat="server" ControlToValidate="txtPrice" Operator="DataTypeCheck" ValidationGroup="vgUpdateProduct" CssClass="ErrorMessage"
                            Type="Double" Display="Dynamic" ErrorMessage="Illegal format for currency" />
                        <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" ValidationGroup="vgUpdateProduct" CssClass="ErrorMessage"
                            ErrorMessage="Please enter price between (0-999)." MaximumValue="999"
                            MinimumValue="0" Type="Double" Display="Dynamic">
                        </asp:RangeValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Currency" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrency" runat="server" Text='<%#Eval("Currency") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCurrency" runat="server" Text='<%#Eval("Currency") %>' Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ControlToValidate="txtCurrency"
                            ErrorMessage="Please enter currency." Display="Dynamic" ValidationGroup="vgUpdateProduct" CssClass="ErrorMessage" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit" ItemStyle-Width="20%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="hfUnit" runat="server" Value='<%#Eval("Unit") %>' />
                        <asp:DropDownList ID="ddlUnit" runat="server" Width="90%"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvUnit" runat="server" ControlToValidate="ddlUnit" InitialValue="0" ValidationGroup="vgUpdateProduct" CssClass="ErrorMessage"
                            ErrorMessage="Please choose a unit." Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" ValidationGroup="vgUpdateProduct" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-CssClass="HeaderClass"></asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" HorizontalAlign="Center" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <PagerSettings Mode="NumericFirstLast" Position="Bottom" Visible="true" FirstPageText="1" />
            <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataRowStyle Width="100%" BackColor="#990000" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <div style="text-align: center">No records found.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
