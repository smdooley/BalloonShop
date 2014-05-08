<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesList.ascx.cs" Inherits="BalloonShop.UserControls.CategoriesList" %>

<asp:DataList ID="list" runat="server" CssClass="CategoriesList" Width="200px">
    <HeaderTemplate>
        Choose a Category
    </HeaderTemplate>
    <HeaderStyle CssClass="CategoriesListHead" />
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl='<%# BalloonShop.BusinessTier.Link.ToCategory(Request.QueryString["DepartmentID"], Eval("CategoryID").ToString()) %>'
            Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
            ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
            CssClass='<%# Eval("CategoryID").ToString() == Request.QueryString["CategoryID"] ? "CategorySelected" : "CategoryUnSelected" %>'>HyperLink</asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
