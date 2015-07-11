using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MassAssignment.Controllers
{
    public class ProfileController : Controller
    {
        int employeeId = 1;
        // GET: EditProfile
        public ActionResult Index()
        {
            NORTHWNDEntities nwe = new NORTHWNDEntities();
            Employee e = nwe.Employees.Where(emp => emp.EmployeeID == employeeId).SingleOrDefault();

            return View("ProfileView", e);
        }

        public ActionResult View()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            NORTHWNDEntities nwe = new NORTHWNDEntities();
            Employee e = nwe.Employees.Where(emp => emp.EmployeeID == employeeId).SingleOrDefault();

            return View("ProfileEdit", e);
        }

        [HttpPost]
        public ActionResult Edit(Employee e, string btnSave)
        {
            if (btnSave == "Save")
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index");

                NORTHWNDEntities nwe = new NORTHWNDEntities();
                nwe.Configuration.ProxyCreationEnabled = false;
                Employee original = nwe.Employees.Where(emp => emp.EmployeeID == employeeId).SingleOrDefault();

                foreach (PropertyInfo propertyInfo in ((Employee)original).GetType().GetProperties())
                {
                    if (propertyInfo.GetValue(e) == null)
                        propertyInfo.SetValue(e, propertyInfo.GetValue(original));
                }
                nwe.Entry(original).CurrentValues.SetValues(e);
                nwe.SaveChanges();

                return View("ProfileView", e);
            }
            else
                return View("Index");
        }

        public ActionResult Save(Employee e, string btnSave)
        {
            if (btnSave == "Save")
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index");

                NORTHWNDEntities nwe = new NORTHWNDEntities();
                nwe.Employees.Add(e);
                nwe.SaveChanges();
                return View("ProfileView", e);
            }
            else
                return View("Index");
        }
    }
}