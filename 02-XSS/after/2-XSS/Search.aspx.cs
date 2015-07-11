using System;
using System.Linq;
using System.Web.Security.AntiXss;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace _2_XSS
{
  public partial class Search : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var searchTerm = Request.Unvalidated.QueryString["q"];
      if (!Regex.IsMatch(searchTerm, @"^[\p{L} \.\-]+$"))
      {
        throw new ApplicationException("Search term is not allowed");
      }

      SearchTerm.Text = AntiXssEncoder.HtmlEncode(searchTerm, true);
      var products = new Product().GetSampleProductList();

      SearchGrid.DataSource = products.Where(p => p.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
      SearchGrid.DataBind();
    }

    protected void SearchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
      {
        return;
      }

      var hyperLink = (HyperLink) e.Row.Cells[0].Controls[0];
      hyperLink.Text = AntiXssEncoder.HtmlEncode(hyperLink.Text, true);
    }
  }
}