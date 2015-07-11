using System.Web;
using System.Web.Mvc;

namespace _3_BrokenAuth
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}