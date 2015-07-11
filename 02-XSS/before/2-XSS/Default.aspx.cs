using System;
using System.Web;
using System.Web.UI;

namespace _2_XSS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var secretCookie = new HttpCookie("SecretCookie")
            {
                Value = "Shhh.... it's a secret!",
                Expires = DateTime.Now.AddYears(1)
            };
            Response.Cookies.Add(secretCookie);
            Response.AppendHeader("X-XSS-Protection", "0");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?q=" + SearchTerm.Text);
        }
    }
}