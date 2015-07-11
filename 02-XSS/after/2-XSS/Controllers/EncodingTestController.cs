using System.Web.Mvc;

namespace _2_XSS.Controllers
{
  public class EncodingTestController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult CreateAccount()
    {
      return View();
    }  
    
    [HttpPost]
    public void CreateAccount(UserAcount model)
    {
      Response.Redirect("/");
    }
  }

  public class UserAcount
  {
    public string UserName { get; set; }

    [AllowHtml]
    public string Password { get; set; }
  }
}