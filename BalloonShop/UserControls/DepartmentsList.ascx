<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentsList.ascx.cs" Inherits="BalloonShop.UserControls.DepartmentsList" %>

<asp:DataList ID="DepartmentList" runat="server" CssClass="departmentsList">
    <HeaderTemplate>
        Choose a department
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl='<%# Link.ToDepartment(Eval("DepartmentID").ToString()) %>'
            Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
            ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
            CssClass='<%# Eval("DepartmentID").ToString == Request.QueryString["DepartmentID"] ? "selected" : "" %>'>
            [HyperLink1]
        </asp:HyperLink>
    </ItemTemplate>
</asp:DataList>