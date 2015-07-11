using System;
using System.Linq;
using System.Web.Mvc;

namespace MassAssignment.Controllers
{
    public class ProfileController : Controller
    {
        readonly int employeeId = 1;
        readonly public Type modelViewType = typeof(EmployeeEditViewModel);
        
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
            nwe.Configuration.ProxyCreationEnabled = false;
            //Employee e = nwe.Employees.Where(emp => emp.EmployeeID == employeeId).SingleOrDefault();
            //EmployeeEditViewModel evm = new EmployeeEditViewModel();
            //CopyPropertyValues(e, evm);

            //var evm = nwe.Employees.Where(emp => emp.EmployeeID == employeeId).Select(em => new EmployeeEditViewModel
            //{
            //    EmployeeID = em.EmployeeID,
            //    Address = em.Address,
            //    City = em.City,
            //    Country = em.Country,
            //    Extension = em.Extension,
            //    HomePhone = em.HomePhone,
            //    Notes = em.Notes,
            //    PostalCode = em.PostalCode,
            //    Region = em.Region,
            //    Title = em.Title,
            //    TitleOfCourtesy = em.TitleOfCourtesy
            //}).FirstOrDefault();

            var tmp = PartialObject(modelViewType);
            var evm = Activator.CreateInstance(Type.GetType(modelViewType.FullName));
            CopyFieldValues(tmp, evm);

            return View("ProfileEdit", evm);
        }

        //ModelBinder would be nice
        [HttpPost]
        public ActionResult Edit(EmployeeEditViewModel e, string btnSave)
        {
            if (btnSave == "Save")
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index");

                NORTHWNDEntities nwe = new NORTHWNDEntities();
                nwe.Configuration.ProxyCreationEnabled = false;
                Employee original = nwe.Employees.Where(emp => emp.EmployeeID == employeeId).SingleOrDefault();
                CopyPropertyValues(e, original);
                nwe.SaveChanges();

                return View("ProfileView", original);
            }
            else
                return View("Index");
        }

        public static void CopyPropertyValues(object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                var destinationProperty = destProperties.Where(p => p.Name == sourceProperty.Name).SingleOrDefault();
                if (destinationProperty != null)
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source, new object[] { }), new object[] { });
            }
        }

        public static void CopyFieldValues(object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceField in source.GetType().GetFields())
            {
                var destinationProperty = destProperties.Where(p => p.Name == sourceField.Name).SingleOrDefault();
                if (destinationProperty != null)
                    destinationProperty.SetValue(destination, sourceField.GetValue(source));
            }
        }

        public object PartialObject(Type typeOfClass)
        {
            NORTHWNDEntities nwe = new NORTHWNDEntities();
            nwe.Configuration.ProxyCreationEnabled = false;
            var tmp = nwe.Employees.Where(emp => emp.EmployeeID == employeeId)
                       .SelectPartially(typeOfClass.GetProperties().Select(p => p.Name).ToList<string>())
                       .FirstOrDefault();

            return tmp;
        }
    }
}
