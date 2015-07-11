<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EncodingTest.aspx.cs" Inherits="_2_XSS.EncodingTest" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <h2>GridView with a BoundField</h2>
  <asp:GridView ID="XssGridViewBound" runat="server" AutoGenerateColumns="False" ShowHeader="False">
    <Columns>
      <asp:BoundField DataField="Name" />
    </Columns>
  </asp:GridView>
  <h2>GridView with a HyperLinkField</h2>
  <asp:GridView ID="XssGridViewHyperlink" runat="server" AutoGenerateColumns="False" ShowHeader="False">
    <Columns>
      <asp:HyperLinkField DataTextField="Name" />
    </Columns>
  </asp:GridView>
  <h2>Button Text</h2>
  <asp:Button runat="server" ID="Button"></asp:Button>
  <h2>Label Text</h2>
  <asp:Label runat="server" ID="Label"></asp:Label>
</asp:Content>
