<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_2_XSS.Search" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var q = <%= Microsoft.Security.Application.AntiXss.JavaScriptEncode(Request.QueryString["q"]) %>;
    </script>

    <h3>You searched for <strong>
        <asp:Label runat="server" ID="SearchTerm" /></strong></h3>

    <asp:GridView runat="server" ID="SearchGrid" AutoGenerateColumns="False" Width="100%">
        <EmptyDataTemplate>
            No results were found
        </EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="ProductID" Visible="false" />
            <asp:HyperLinkField DataTextField="ProductName" HeaderText="Product name" DataNavigateUrlFormatString="edit.aspx?p={0}" DataNavigateUrlFields="ProductID" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:HyperLinkField DataTextField="Description" HeaderText="Description" />
        </Columns>
    </asp:GridView>
</asp:Content>
