using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2_XSS
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["p"] != null && !Page.IsPostBack)
            {
                int productId = int.Parse(Request.QueryString["p"]);

                NORTHWNDEntities nwe = new NORTHWNDEntities();
                Product product = nwe.Products.Where(p => p.ProductID == productId).SingleOrDefault();

                if (product != null)
                {
                    lblProductID.Text = productId.ToString();
                    lblProductName.Text = product.ProductName;
                    tbxDescription.Text = product.Description;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblProductID.Text != null || lblProductID.Text != string.Empty)
            {
                NORTHWNDEntities nwe = new NORTHWNDEntities();
                int productID = int.Parse(lblProductID.Text);
                Product product_edited = nwe.Products.Where(p => p.ProductID == productID).SingleOrDefault();
                product_edited.Description = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(tbxDescription.Text,false);
                nwe.SaveChanges();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}