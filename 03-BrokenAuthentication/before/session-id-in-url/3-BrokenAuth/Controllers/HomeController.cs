using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using _3_BrokenAuth.Models;

namespace _3_BrokenAuth.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Username = Session["Username"];
      return View();
    }

    [HttpPost]
    public ActionResult Index(SampleLoginModel model)
    {
      // Login logic goes here.

      Session["Username"] = model.Username;
      ViewBag.Username = model.Username;
      return View();
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
