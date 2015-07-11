using DevOne.Security.Cryptography.BCrypt;
using System;
using System.Security.Cryptography;
using System.Text;

namespace _7_CryptoStorage
{
    public partial class Hashing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string secret = "P@$$w0rd";
            byte[] bytes = Encoding.Unicode.GetBytes(secret);
            string salt = BCryptHelper.GenerateSalt();
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] inArray = null;

            HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA1");
            byte[] buffer6 = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, buffer6, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, buffer6, src.Length, bytes.Length);
            inArray = hashAlgorithm.ComputeHash(buffer6);

            var saltedHashedPassword = BCryptHelper.HashPassword(secret, salt);

            PlainTextLabel.Text = secret;
            SaltTextLabel.Text = salt;
            MD5TextLabel.Text = HexStringFromBytes(MD5.Create("MD5").ComputeHash(bytes));
            SHA1TestLabel.Text = HexStringFromBytes(SHA1.Create("SHA1").ComputeHash(bytes));
            SaltedSHA1TextLabel.Text = saltedHashedPassword;
            RFC2898TextLabel.Text = SaltAndHashPassword(secret, src, 32);
        }

        public string SaltAndHashPassword(string password, byte[] salt, int hashSize)
        {
            int ITERATIONS = 10000;
            int SALT_SIZE = salt.Length;
            int HASH_SIZE = hashSize;

            Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(password, SALT_SIZE, ITERATIONS);

            salt = rdb.Salt;

            return HexStringFromBytes(rdb.GetBytes(HASH_SIZE));
        }

        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}