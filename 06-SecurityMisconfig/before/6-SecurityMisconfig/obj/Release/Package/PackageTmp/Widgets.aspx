<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Widgets.aspx.cs" Inherits="_6_SecurityMisconfig.Widgets" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <asp:GridView runat="server" ID="WidgetGrid" AutoGenerateColumns="False">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Name" />
    </Columns>
  </asp:GridView>
</asp:Content>
