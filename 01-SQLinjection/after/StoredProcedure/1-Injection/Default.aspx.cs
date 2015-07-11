using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_Injection
{
  public partial class _Default : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
      var sqlString = "SELECT * FROM ProductSubcategory ORDER BY Name";
      using (var conn = new SqlConnection(connString))
      {
        var command = new SqlCommand(sqlString, conn);
        command.Connection.Open();
        CategoryGridView.DataSource = command.ExecuteReader();
        CategoryGridView.DataBind();
      }
    }
  }
}