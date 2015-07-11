using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace _6_SecurityMisconfig
{
  public partial class Widgets : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var categoryId = Request.QueryString["CategoryId"];
      var categoryIdInt = Int64.Parse(categoryId);

      var typeId = Request.QueryString["TypeId"];
      var typeIdInt = string.IsNullOrEmpty(typeId) ? 1 : Int64.Parse(typeId);

      const string connString = "Data Source=(local);Initial Catalog=6-SecurityMisconfig;User Id=6-SecurityMisconfig-User;Password=qc9yFUrYyWiLx80ZFlgj;";
      const string sqlString = "SELECT * FROM Widget WHERE CategoryId = @CategoryId AND TypeId = @TypeId";
      using (var conn = new SqlConnection(connString))
      {
        using (var command = new SqlCommand(sqlString, conn))
        {
          command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryIdInt;
          command.Parameters.Add("@TypeId", SqlDbType.Int).Value = typeIdInt;
          command.Connection.Open(); 
          WidgetGrid.DataSource = command.ExecuteReader();
          WidgetGrid.DataBind();
        }
      }

      Trace.Warn("All data successfully loaded using conn string " + connString);
    }
  }
}