using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WcfSimpleTokenExample.Business
{
    public class Hash
    {
        public static Encoding DefaultEncoding = Encoding.UTF8;
        public const HashType DefaultHashType = HashType.SHA256;

        public enum HashType
        {
            MD5,
            SHA1,
            SHA256,
            SHA512
        }

        public static string Get(string text, HashType hashType = DefaultHashType, Encoding encoding = null)
        {
            switch (hashType)
            {
                case HashType.MD5:
                    return Get(text, new MD5CryptoServiceProvider(), encoding);
                case HashType.SHA1:
                    return Get(text, new SHA1Managed(), encoding);
                case HashType.SHA256:
                    return Get(text, new SHA256Managed(), encoding);
                case HashType.SHA512:
                    return Get(text, new SHA512Managed(), encoding);
                default:
                    throw new CryptographicException("Invalid hash alrgorithm.");
            }
        }

        public static string Get(string text, string salt, HashType hashType = DefaultHashType, Encoding encoding = null)
        {
            return Get(text + salt, hashType, encoding);
        }

        public static string Get(string text, HashAlgorithm algorithm, Encoding encoding = null)
        {
            byte[] message = (encoding == null) ? DefaultEncoding.GetBytes(text) : encoding.GetBytes(text);
            byte[] hashValue = algorithm.ComputeHash(message);
            return hashValue.Aggregate(string.Empty, (current, x) => current + string.Format("{0:x2}", x));
        }

        public static bool Compare(string original, string hashString, HashType hashType = DefaultHashType, Encoding encoding = null)
        {
            string originalHash = Get(original, hashType, encoding);
            return (originalHash == hashString);
        }

        public static bool Compare(string original, string salt, string hashString, HashType hashType = DefaultHashType, Encoding encoding = null)
        {
            return Compare(original + salt, hashString, hashType, encoding);
        }
    }
}