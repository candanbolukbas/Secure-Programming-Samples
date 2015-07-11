using System;
using System.IO;
using System.Web.Security;
using System.Web.UI;

namespace _7_CryptoStorage
{
  public partial class LoadSonyPasswords : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var passwords = File.ReadAllLines(Server.MapPath("Sony passwords.txt"));

      var i = 0;
      foreach (var password in passwords)
      {
        i++;
        MembershipCreateStatus createStatus;
        Membership.CreateUser(
          "user" + i,        // User name
          password,          // Password
          "foo@bar.com",     // Email
          null,              // Password question
          null,              // Password answer
          true,              // Is approved
          null,              // Provider key
          out createStatus); // Status
      }

      ResultLabel.Text = string.Format("Successfully loaded {0:n0} passwords", i);
    }
  }
}