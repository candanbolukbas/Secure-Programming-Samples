<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSSL.aspx.cs" Inherits="_9_tls.TestSSL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      Is this request secure? <%= Request.IsSecureConnection %>
    </div>
  </form>
</body>
</html>
