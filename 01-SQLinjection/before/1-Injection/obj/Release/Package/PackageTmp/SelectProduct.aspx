<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectProduct.aspx.cs" Inherits="_1_Injection.SelectProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
    <asp:Button ID="btGo" runat="server" Text="Get" OnClick="btGo_Click" Visible="false" />
  <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Name" />
      <asp:BoundField DataField="ProductNumber" HeaderText="ProductNumber" />
      <asp:BoundField DataField="ListPrice" HeaderText="Price" DataFormatString="{0:c}" />
    </Columns>
  </asp:GridView>
</asp:Content>
