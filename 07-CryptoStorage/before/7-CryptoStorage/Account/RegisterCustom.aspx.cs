using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace _7_CryptoStorage.Account
{
  public partial class RegisterCustom : System.Web.UI.Page
  {

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {
      var userName = UserName.Text;
      var sourcePassword = Password.Text;
      var passwordHash = GetMd5Hash(sourcePassword);
      CreateUser(userName, passwordHash);
      Response.Redirect("~/Default.aspx");
    }

    private void CreateUser(string userName, string passwordHash)
    {
      var connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
      var conn = new SqlConnection(connectionString);
      using (var command = new SqlCommand("CreateUser", conn))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
        command.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = passwordHash;
        command.Connection.Open();
        command.ExecuteReader();
      }
    }

    private static string GetMd5Hash(string input)
    {
      var hasher = MD5.Create();
      var data = hasher.ComputeHash(Encoding.Default.GetBytes(input));
      var builder = new StringBuilder();

      for (var i = 0; i < data.Length; i++)
      {
        builder.Append(data[i].ToString("x2"));
      }

      return builder.ToString();
    }
  }
}
