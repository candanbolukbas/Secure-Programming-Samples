using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using _4_DirectObjRef.Models;

namespace _4_DirectObjRef.Controllers
{
  public class UserProfileController : Controller
  {
    public ActionResult Index(string id)
    {
      if (!User.Identity.IsAuthenticated)
      {
        throw new ApplicationException("User not authenticated");
      }

      var userName = id.GetDirectRef();
      if (User.Identity.Name != userName)
      {
        throw new ApplicationException("User not authorised");
      }

      UserProfile profile;
      using (var context = new UsersContext())
      {
        profile = context.UserProfiles.SingleOrDefault(x => x.UserName == userName);
      }

      if (profile == null)
      {
        throw new ApplicationException("Profile does not exist");
      }

      return Json(new
        {
          Address = profile.Address,
          BirthDate = profile.BirthDate.ToString("d MMM yyyy"), 
          TaxFileNumber = profile.TaxFileNumber
        },
        JsonRequestBehavior.AllowGet);
    }
  }
}
