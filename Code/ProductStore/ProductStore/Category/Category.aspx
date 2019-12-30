<%@ Page Title="Product Store - Category" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="ProductStore.Category.Category" %>

<%@ MasterType VirtualPath="~/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        td input, td select {
            height: 25px;
            font-size: 13px;
            color: black;
        }

        .HeaderClass {
            text-align: center;
            font-weight: 300;
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div>
        <a id="btnAddCategory" runat="server" href="AddCategory.aspx" class="LinkButton">Add Category</a>
    </div>
    <br />
    <div style="width: 100%; margin: auto; top: 5px;">
        <asp:GridView ID="CategoryGrid" runat="server" PageSize="20" AllowPaging="True" DataKeyField="CategoryId" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" OnRowEditing="CategoryGrid_RowEditing" OnRowDeleting="CategoryGrid_RowDeleting"
            OnRowCancelingEdit="CategoryGrid_RowCancelingEdit" OnRowUpdating="CategoryGrid_RowUpdating" OnRowDataBound="CategoryGrid_RowDataBound"
            OnPageIndexChanging="CategoryGrid_PageIndexChanging" OnPreRender="CategoryGrid_PreRender"
            ShowHeaderWhenEmpty="true" EmptyDataText="No records Found.">
            <Columns>
                <asp:TemplateField HeaderText="Category Id" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblCategoryId" runat="server" Text='<%#Eval("CategoryId") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbDispCategoryNum" runat="server" Value='<%#Eval("CategoryId") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ValidationGroup="vgAddCategory"
                            ErrorMessage="Please enter category name." Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Desccription" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%#Eval("Description") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                            ErrorMessage="Please enter description." Display="Dynamic" ValidationGroup="vgAddCategory" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-CssClass="HeaderClass">
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" ValidationGroup="vgAddCategory" />
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
