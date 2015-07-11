using System;
using System.Web.UI;
using System.Linq;

namespace _10_Redirects
{
    public partial class Redirect : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = Request.QueryString["url"];
            Response.Redirect(url);
        }
    }
}