<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="_1_Injection.Product" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <p>There are
    <b><asp:Label runat="server" ID="ProductCount"></asp:Label></b>
    products</p>
  <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Name" />
      <asp:BoundField DataField="ProductNumber" HeaderText="ProductNumber" />
      <asp:BoundField DataField="ListPrice" HeaderText="Price" DataFormatString="{0:c}" />
    </Columns>
  </asp:GridView>
</asp:Content>
