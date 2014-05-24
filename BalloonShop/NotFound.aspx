<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="BalloonShop.NotFound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Looking for balloons?</h1>
<p>Unfortunately, the page that you asked for doesn't exist in our web site!</p>
<p>Please visit our <asp:HyperLink runat="server" Target="~/" Text="catalog" /> or contact us at friendly_support@example.com!</p>
<p>The <b>Balloon Shop</b> team</p>
</asp:Content>
