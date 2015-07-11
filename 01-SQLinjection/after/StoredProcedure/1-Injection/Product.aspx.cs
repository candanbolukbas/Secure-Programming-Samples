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

      var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
      var sqlString = "GetProducts";
      using (var conn = new SqlConnection(connString))
      {
        using (var command = new SqlCommand(sqlString, conn))
        {
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add("@ProductSubCategoryID", SqlDbType.VarChar).Value = productSubCategoryId;
          command.Connection.Open();
          ProductGridView.DataSource = command.ExecuteReader();
          ProductGridView.DataBind();
        }
      }

      ProductCount.Text = ProductGridView.Rows.Count.ToString("n0");
    }
  }
}