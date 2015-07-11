using WcfSimpleTokenExample.Model;

namespace WcfSimpleTokenExample.Interfaces
{
    interface ITokenBuilder
    {
        string Build(Credentials creds);
    }
}
