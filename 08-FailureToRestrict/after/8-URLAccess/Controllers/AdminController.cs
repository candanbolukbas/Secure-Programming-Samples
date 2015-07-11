using System.Web.Mvc;

namespace _8_URLAccess.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AdminController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}
