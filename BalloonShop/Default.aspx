<%@ Page Title="Home | Balloon Shop" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BalloonShop._Default" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1><span class="CatalogTitle">Welcome to BalloonShop!</span></h1>
    <h2><span class="CatalogDescription">This week we have a special price for these fantastic products:</span></h2>
    <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>
