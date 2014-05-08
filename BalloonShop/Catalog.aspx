<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="BalloonShop.Catalog" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label runat="server" ID="catalogTitleLabel" CssClass="CatalogTitle" /></h1>
    <h2><asp:Label runat="server" ID="catalogDescriptionLabel" CssClass="CatalogDescription" /></h2>
    <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>
