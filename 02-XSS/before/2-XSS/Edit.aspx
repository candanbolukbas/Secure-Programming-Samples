<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="_2_XSS.Edit" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblProductID" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
    <br />
    <asp:TextBox ID="tbxDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
</asp:Content>

