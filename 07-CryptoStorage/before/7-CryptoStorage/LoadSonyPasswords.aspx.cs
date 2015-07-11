using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
            //foreach (var password in passwords)
            //{
            //    i++;
            //    MembershipCreateStatus createStatus;
            //    Membership.CreateUser(
            //      "user" + i,        // User name
            //      password,          // Password
            //      "foo@bar.com",     // Email
            //      null,              // Password question
            //      null,              // Password answer
            //      true,              // Is approved
            //      null,              // Provider key
            //      out createStatus); // Status
            //}

            //ResultLabel.Text = string.Format("Successfully loaded {0:n0} passwords", i);

            //CryptoStorageEntities cse = new CryptoStorageEntities();
            //foreach (var password in passwords)
            //{
            //    i++;
            //    UserInfo u = new UserInfo();
            //    u.Username = "user" + i;
            //    u.Password = password;
            //    u.PasswordMD5 = CreateMD5(password);
            //    cse.UserInfoes.Add(u);
            //}
            //cse.SaveChanges();
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}