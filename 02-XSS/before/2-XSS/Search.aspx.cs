using System;
using System.Linq;
using System.Web.Security;
using Microsoft.Security.Application;

namespace _2_XSS
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["q"] != null)
            {
                var searchTerm = Request.QueryString["q"];

                //searchTerm = searchTerm.ToLower().Replace("script", "");

                //SearchTerm.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(searchTerm, false);


                SearchTerm.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(searchTerm, false);
                

                //SearchTerm.Text = searchTerm;

                NORTHWNDEntities nwe = new NORTHWNDEntities();
                var products = nwe.Products.ToList();

                SearchGrid.DataSource = products.Where(p => p.ProductName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
                SearchGrid.DataBind();
            }
            Response.AppendHeader("X-XSS-Protection", "0");
        }
    }
}