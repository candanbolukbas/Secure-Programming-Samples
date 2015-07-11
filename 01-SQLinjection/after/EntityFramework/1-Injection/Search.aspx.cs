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
  public partial class Search : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
      using (var conn = new SqlConnection(connString))
      {
        using (var command = new SqlCommand("SearchProducts", conn))
        {
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add("@SearchTerm", SqlDbType.VarChar).Value = SearchTerm.Text;
          command.Connection.Open();
          ProductGridView.DataSource = command.ExecuteReader();
          ProductGridView.DataBind();
        }
      }

      ProductCount.Text = ProductGridView.Rows.Count.ToString("n0");
      SearchPanel.Visible = true;
    }
  }
}