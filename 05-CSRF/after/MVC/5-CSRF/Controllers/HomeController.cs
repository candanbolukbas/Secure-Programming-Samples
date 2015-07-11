using System;
using System.Linq;
using System.Web.Mvc;
using WebMatrix.WebData;
using _5_CSRF.Filters;
using _5_CSRF.Models;

namespace _5_CSRF.Controllers
{
  [InitializeSimpleMembership]
  public class HomeController : Controller
  {
    readonly StatusEntities _db = new StatusEntities();

    public ActionResult Index()
    {
      var userId = WebSecurity.GetUserId(User.Identity.Name);
      ViewBag.StatusUpdates = _db.StatusUpdates
        .Where(s => s.UserId == userId)
        .OrderByDescending(s => s.StatusDate)
        .Select(s => new StatusUpdateViewModel { StatusDate = s.StatusDate, Status = s.Status });
      return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public ActionResult Index(StatusUpdateViewModel model)
    {
      if (ModelState.IsValid)
      {
        var userId = WebSecurity.GetUserId(User.Identity.Name);
        _db.StatusUpdates.Add(new StatusUpdate { Status = model.Status, UserId = userId, StatusDate = DateTime.Now });
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(model);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}
