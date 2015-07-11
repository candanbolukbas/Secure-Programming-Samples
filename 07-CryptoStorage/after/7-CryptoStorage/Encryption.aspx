<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encryption.aspx.cs" Inherits="_7_CryptoStorage.Encryption" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>Plain text <asp:Label runat="server" id="PlainTextLabel"></asp:Label></p>
    <p>Encrypted text <asp:Label runat="server" id="EncryptedTextLabel"></asp:Label></p>
    <p>Decrypted text <asp:Label runat="server" id="DecryptedTextLabel"></asp:Label></p>
    </div>
    </form>
</body>
</html>
