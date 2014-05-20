<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="BalloonShop.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label runat="server" ID="titleLabel" CssClass="CatalogTitle" Text="Label" />
    </p>
    <p>
        <asp:Image runat="server" ID="productImage" />
    </p>
    <p>
        <asp:Label runat="server" ID="descriptionLabel" Text="Label" />
    </p>
    <p>
        <b>Price:</b>
        <asp:Label runat="server" ID="priceLabel" CssClass="ProductPrice" Text="Label" />
    </p>
    <p>
        <asp:PlaceHolder runat="server" ID="attrPlaceHolder" />
    </p>
</asp:Content>
