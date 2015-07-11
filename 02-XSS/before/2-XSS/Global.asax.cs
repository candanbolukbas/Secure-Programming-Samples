using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using _2_XSS.App_Start;
using System.Web.Mvc;

namespace _2_XSS
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new ValidateInputAttribute(false));
        }
    }
}
