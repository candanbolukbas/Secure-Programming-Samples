using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_Injection
{
  public partial class Product : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var productSubCategoryId = Request.QueryString["ProductSubCategoryId"];

      int id;
      if (!int.TryParse(productSubCategoryId, out id))
      {
        throw new ApplicationException("ID wasn't an integer");
      }

      var dc = new InjectionEntities();

      ProductGridView.DataSource = dc.Products.Where(p => p.ProductSubcategoryID == id).ToList();
      ProductGridView.DataBind();

      ProductCount.Text = ProductGridView.Rows.Count.ToString("n0");
    }
  }
}