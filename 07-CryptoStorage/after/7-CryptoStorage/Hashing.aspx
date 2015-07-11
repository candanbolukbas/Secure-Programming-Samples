<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hashing.aspx.cs" Inherits="_7_CryptoStorage.Hashing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p><span style="font-weight: bold">Plain text:</span>
                <asp:Label runat="server" ID="PlainTextLabel"></asp:Label></p>
            <p><span style="font-weight: bold">Salt:</span>
                <asp:Label runat="server" ID="SaltTextLabel"></asp:Label></p>
            <p><span style="font-weight: bold">MD5 text:</span>
                <asp:Label runat="server" ID="MD5TextLabel"></asp:Label></p>
            <p><span style="font-weight: bold">SHA1 text:</span>
                <asp:Label runat="server" ID="SHA1TestLabel"></asp:Label></p>
            <p><span style="font-weight: bold">Salted SHA1 text:</span>
                <asp:Label runat="server" ID="SaltedSHA1TextLabel"></asp:Label></p>
            <p><span style="font-weight: bold">RFC2898 PBKDF2:</span>
                <asp:Label runat="server" ID="RFC2898TextLabel"></asp:Label></p>
        </div>
    </form>
</body>
</html>
