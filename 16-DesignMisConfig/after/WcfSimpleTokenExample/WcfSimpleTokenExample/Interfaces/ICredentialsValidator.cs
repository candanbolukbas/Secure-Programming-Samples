using WcfSimpleTokenExample.Model;

namespace WcfSimpleTokenExample.Interfaces
{
    public interface ICredentialsValidator
    {
        bool IsValid(Credentials creds);
    }
}