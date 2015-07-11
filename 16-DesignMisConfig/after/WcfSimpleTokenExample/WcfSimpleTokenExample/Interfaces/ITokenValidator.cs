namespace WcfSimpleTokenExample.Interfaces
{
    public interface ITokenValidator
    {
        bool IsValid(string token);
    }
}