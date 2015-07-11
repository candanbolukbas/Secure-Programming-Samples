<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_2_XSS.Search" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <h3>You searched for <strong><asp:Label runat="server" ID="SearchTerm" /></strong></h3>
  <script type="text/javascript">
    var q = <%= Microsoft.Security.Application.Encoder.JavaScriptEncode(Request.QueryString["q"]) %>
  </script>
  <asp:GridView runat="server" ID="SearchGrid" AutoGenerateColumns="False" Width="100%" OnRowDataBound="SearchGrid_RowDataBound">
    <EmptyDataTemplate>
      No results were found
    </EmptyDataTemplate>
    <Columns>
      <asp:HyperLinkField DataTextField="Name" HeaderText="Product name" />
    </Columns>
  </asp:GridView>
</asp:Content>
