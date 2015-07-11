using System.Web.Mvc;

namespace _2_XSS.Controllers
{
    public class EncodingTestController : Controller
    {
        [ValidateInput(false)]
        public ActionResult Index()
        {
            ParameterModel p = new ParameterModel();
            //p.value = id;
            p.value = "<i>candan</i>";
            ViewData["p"] = p;
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

        public string Password { get; set; }
    }

    public class ParameterModel
    {
        [AllowHtml]
        public string value { get; set; }
    }
}