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
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var productSubCategoryId = Request.QueryString["ProductSubCategoryId"];
            string userAgent = Request.Headers.GetValues("User-Agent")[0];

            var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlUserAgentString = "SELECT * FROM UserAgents WHERE UserAgent = N'" + userAgent + "'";

            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(sqlUserAgentString, conn))
                {
                    command.Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr == null)
                    {
                        var insertString = "INSERT INTO [dbo].[UserAgents] ([UserAgent])  VALUES (N'" + userAgent + "')";
                        SqlCommand sc = new SqlCommand(insertString, new SqlConnection(connString));
                        sc.ExecuteNonQuery();
                    }
                }
            }

            if (productSubCategoryId != null)
            {
                //productSubCategoryId = productSubCategoryId.ToUpper().Replace("SELECT", "");
                //productSubCategoryId = productSubCategoryId.ToUpper().Replace("UPDATE", "");
                //productSubCategoryId = productSubCategoryId.ToUpper().Replace("INSERT", "");
                //productSubCategoryId = productSubCategoryId.ToUpper().Replace("DELETE", "");
                //productSubCategoryId = productSubCategoryId.ToUpper().Replace("WHERE", "");
                //productSubCategoryId = productSubCategoryId.ToUpper().Replace("FROM", "");

                injectionEntities ie = new injectionEntities();
                int? pID = int.Parse(productSubCategoryId);
                ProductGridView.DataSource = ie.Products.Where(p => p.ProductSubcategoryID == pID).ToList();
                ProductGridView.DataBind();


                var sqlString = "SELECT Name, ProductNumber, ListPrice FROM Product WHERE ProductSubCategoryID = " + productSubCategoryId;
                using (var conn = new SqlConnection(connString))
                {
                    using (var command = new SqlCommand(sqlString, conn))
                    {
                        command.Connection.Open();
                        ProductGridView.DataSource = command.ExecuteReader();
                        ProductGridView.DataBind();
                    }
                }

                ProductCount.Text = ProductGridView.Rows.Count.ToString("n0");
            }
        }
    }
}