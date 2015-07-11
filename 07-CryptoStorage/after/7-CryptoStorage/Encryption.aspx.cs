using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _7_CryptoStorage
{
  public partial class Encryption : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var secret = "My secret text";
      var secretBytes = Encoding.Unicode.GetBytes(secret);
      var encryptedBytes = ProtectedData.Protect(secretBytes, null, DataProtectionScope.LocalMachine);

      var decryptedBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.LocalMachine);
      var decryptedSecret = Encoding.Unicode.GetString(decryptedBytes);

      PlainTextLabel.Text = secret;
      EncryptedTextLabel.Text = Encoding.Unicode.GetString(encryptedBytes);
      DecryptedTextLabel.Text = decryptedSecret;
    }
  }
}