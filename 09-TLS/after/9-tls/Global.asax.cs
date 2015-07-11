using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _9_tls
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        //protected void Application_BeginRequest(Object sender, EventArgs e)
        //{
        //    switch (Request.Url.Scheme)
        //    {
        //        case "https":
        //            Response.AddHeader("Strict-Transport-Security", "max-age=31536000");
        //            break;
        //        case "http":
        //            var path = "https://" + Request.Url.Host + Request.Url.PathAndQuery;
        //            Response.Status = "301 Moved Permanently";
        //            Response.AddHeader("Location", path);
        //            break;
        //    }
        //}
    }
}