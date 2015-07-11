using System;
using System.Linq;
using System.Web.UI;

namespace _10_Redirects
{
  public partial class Redirect : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var url = Request.QueryString["url"];

      var referrer = Request.UrlReferrer;
      if (referrer == null || referrer.Host != Request.Url.Host)
      {
        throw new ApplicationException("Referrer is not the same site");
      }

      var db = new TrustedUrlContext();
      if (!db.TrustedUrls.Any(t => t.Url == url))
      {
        throw new ApplicationException("URL not trusted");
      }
      
      // ToDo: Log exit here.

      Response.Redirect(url);
    }
  }
}