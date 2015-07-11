using System.Security.Authentication;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using WcfSimpleTokenExample.Business;
using WcfSimpleTokenExample.Database;
using WcfSimpleTokenExample.Interfaces;
using WcfSimpleTokenExample.Model;

namespace WcfSimpleTokenExample.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthenticationTokenService
    {
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        public string Authenticate(Credentials creds)
        {
            using (var dbContext = new BasicTokenDbContext())
            {
                ICredentialsValidator validator = new DatabaseCredentialsValidator(dbContext);
                if (validator.IsValid(creds))
                    return new DatabaseTokenBuilder(dbContext).Build(creds);
                throw new InvalidCredentialException("Invalid credentials");
            }
        }
    }
}
