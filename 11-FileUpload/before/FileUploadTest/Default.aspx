<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUploadTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <table>
        <tr>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Upload File" OnClick="Button1_Click" /></td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblStatus" runat="server" Text="..."></asp:Label>
</asp:Content>
