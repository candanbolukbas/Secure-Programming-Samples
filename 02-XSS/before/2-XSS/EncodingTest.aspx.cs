using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _2_XSS
{
  public partial class EncodingTest : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      const string dummyData = "<i>Lager</i>";
      var dummyCollection = new List<DummyData> { new DummyData { Name = dummyData } };

      XssGridViewBound.DataSource = dummyCollection;
      XssGridViewBound.DataBind();

      XssGridViewHyperlink.DataSource = dummyCollection;
      XssGridViewHyperlink.DataBind();

      Label.Text = dummyData;
      Label.ToolTip = dummyData;

      Button.Text = dummyData;
    }
  }

  public class DummyData
  {
    public string Name { get; set; }
  }
}