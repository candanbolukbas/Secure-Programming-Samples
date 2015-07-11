using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using WcfSimpleTokenExample.Business;
using WcfSimpleTokenExample.Database;
using WcfSimpleTokenExample.Interfaces;

namespace WcfSimpleTokenExample.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Test1Service
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string Test()
        {
            var token = HttpContext.Current.Request.Headers["Token"];
            using (var dbContext = new BasicTokenDbContext())
            {
                ITokenValidator validator = new DatabaseTokenValidator(dbContext);
                return validator.IsValid(token) ? "Your token worked!" : "Your token failed!";
            }
        }
    }
}
