<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1_Injection._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="CategoryGridView" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
      <asp:HyperLinkField HeaderText="Product Name" DataNavigateUrlFormatString="Product.aspx?ProductSubCategoryId={0}" DataTextField="Name" DataNavigateUrlFields="ProductSubCategoryID" />
    </Columns>
  </asp:GridView>
</asp:Content>
