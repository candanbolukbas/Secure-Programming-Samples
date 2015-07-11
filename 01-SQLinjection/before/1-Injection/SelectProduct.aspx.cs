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
    public partial class SelectProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlString = "SELECT ProductSubcategoryID, Name FROM ProductSubcategory";
            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(sqlString, conn))
                {
                    command.Connection.Open();
                    ddlCategory.DataSource = command.ExecuteReader();
                    ddlCategory.DataTextField = "Name";
                    ddlCategory.DataValueField = "ProductSubcategoryID";
                    ddlCategory.DataBind();
                }
            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int productSubCategoryId = int.Parse(ddlCategory.SelectedValue);
            var productSubCategoryId = ddlCategory.SelectedValue;
            if (productSubCategoryId != null)
            {
                var connstring = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                var sqlstring = "select * from product where productsubcategoryid = " + productSubCategoryId;
                using (var conn = new SqlConnection(connstring))
                {
                    using (var command = new SqlCommand(sqlstring, conn))
                    {
                        command.Connection.Open();
                        ProductGridView.DataSource = command.ExecuteReader();
                        ProductGridView.DataBind();
                    }
                }
            }
        }

        protected void btGo_Click(object sender, EventArgs e)
        {
            var productSubCategoryId = ddlCategory.SelectedValue;

            if (productSubCategoryId != null)
            {
                var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                var sqlString = "SELECT * FROM Product WHERE ProductSubCategoryID = " + productSubCategoryId;
                using (var conn = new SqlConnection(connString))
                {
                    using (var command = new SqlCommand(sqlString, conn))
                    {
                        command.Connection.Open();
                        ProductGridView.DataSource = command.ExecuteReader();
                        ProductGridView.DataBind();
                    }
                }
            }
        }
    }
}