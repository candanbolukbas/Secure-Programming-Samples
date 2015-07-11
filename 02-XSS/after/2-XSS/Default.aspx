<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_2_XSS._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <hgroup class="title">
    <h1>Search.</h1>
    <h2>Use the form below to search for products.</h2>
  </hgroup>
  <fieldset>
    <legend>Search</legend>
    <ol>
      <li>
        <asp:Label ID="Label1" runat="server" AssociatedControlID="SearchTerm">Search term</asp:Label>
        <asp:TextBox runat="server" ID="SearchTerm" ValidateRequestMode="Disabled" />
      </li>
    </ol>
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
  </fieldset>
</asp:Content>
