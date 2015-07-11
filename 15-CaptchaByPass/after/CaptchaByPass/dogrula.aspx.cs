using CaptchaByPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dogrula : System.Web.UI.Page
{
    public Boolean control = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["captcha"] != null && Session["captcha"].ToString() == Request["captcha"].ToString())
        {
            control = true;

            Session["captcha"] = Guid.NewGuid().ToString();

            Comment c = new Comment();
            c.Comment1 = Request.Form["comment"];
            c.eMail = Request.Form["email"];
            c.Name = Request.Form["name"];
            c.Phone = Request.Form["phone"];
            c.Surname = Request.Form["surname"];

            GarbageEntities ge = new GarbageEntities();
            ge.Comments.Add(c);
            ge.SaveChanges();
        }
        else
        {
            control = false;
        }

        if (Session["captcha"] != null)
            Session.Remove("captcha");

        DataBind();
    }
}