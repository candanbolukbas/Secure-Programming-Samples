using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace _10_Redirects
{
  public static class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.EnableFriendlyUrls();
    }
  }
}
