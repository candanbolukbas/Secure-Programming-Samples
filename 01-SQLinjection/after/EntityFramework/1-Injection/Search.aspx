<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_1_Injection.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <hgroup class="title">
    <h1>Search.</h1>
    <h2>Use the form below to search for products.</h2>
  </hgroup>
  <fieldset>
    <legend>Search</legend>
    <ol>
      <li>
        <asp:Label ID="Label1" runat="server" AssociatedControlID="SearchTerm">Search term</asp:Label>
        <asp:TextBox runat="server" ID="SearchTerm" />
      </li>
    </ol>
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
  </fieldset>

  <asp:Panel runat="server" ID="SearchPanel" Visible="False">
    <p>
      There were
    <b>
      <asp:Label runat="server" ID="ProductCount"></asp:Label></b>
      products found
    </p>
    <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" Width="100%">
      <Columns>
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="ProductNumber" HeaderText="ProductNumber" />
        <asp:BoundField DataField="ListPrice" HeaderText="Price" DataFormatString="{0:c}" />
      </Columns>
    </asp:GridView>
  </asp:Panel>
</asp:Content>
