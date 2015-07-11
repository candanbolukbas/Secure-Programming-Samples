using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using CaptchaByPass;

public partial class CImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Session["captcha"] = GenerateRandomCode();
        RandomImage ci = new RandomImage(this.Session["captcha"].ToString(), 350, 100);
        this.Response.Clear();
        this.Response.ContentType = "image/jpeg";
        ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
        ci.Dispose();
    }

    private string GenerateRandomCode()
    {
        Random r = new Random();
        string s = "";
        for (int j = 0; j < 5; j++)
        {
            int i = r.Next(3);
            int ch;
            switch (i)
            {
                case 1:
                    ch = r.Next(0, 9);
                    s = s + ch.ToString();
                    break;
                case 2:
                    ch = r.Next(65, 90);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
                case 3:
                    ch = r.Next(97, 122);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
                default:
                    ch = r.Next(97, 122);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
            }
            r.NextDouble();
            r.Next(100, 1999);
        }
        return s;
    }
}