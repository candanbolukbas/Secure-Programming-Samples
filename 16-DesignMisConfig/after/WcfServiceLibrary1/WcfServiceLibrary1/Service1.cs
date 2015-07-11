using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string token = "MyT0p$3cr3t4uth3nt!c4t!0nT0k3n";
        public string Authenticate(string username, string password)
        {
            if (username == "candan" && password == "password")
                return token;
            else
                return string.Empty;
        }

        public string GetData(string value)
        {
            var opContext = OperationContext.Current;
            var requestContext = opContext.RequestContext;
            var headers = requestContext.RequestMessage.Headers;
            int headerIndex = headers.FindHeader("Token", "http://tempuri.org/");
            string userToken = headers.GetHeader<string>(headerIndex);

            if (userToken == token)
                return string.Format("Successfully authenticated and you entered: {0}", value);
            else
                return "Invalid token!";
        }

        public string GetSecretData(string value, string usertoken)
        {
            if (usertoken == token)
                return string.Format("Successfully authenticated and your secret is: {0}", Base64Encode(value));
            else
                return "Invalid token!";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
