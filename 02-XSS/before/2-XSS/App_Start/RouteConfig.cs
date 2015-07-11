using System.Web.Mvc;
using System.Web.Routing;

namespace _2_XSS.App_Start
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "Default",
          url: "EncodingTest/{action}/{id}",
          defaults: new { controller = "EncodingTest", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}