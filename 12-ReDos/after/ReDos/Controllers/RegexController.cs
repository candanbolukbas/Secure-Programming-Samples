using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ReDos.Controllers
{
    public class RegexController : Controller
    {
        // GET: Regex
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tbxEmail)
        {
            DateTime start = DateTime.Now;
            string result = IsEPostaValid(tbxEmail).ToString();
            DateTime end = DateTime.Now;

            ViewData["result"] = result;
            ViewData["duration"] = (end - start).TotalMilliseconds.ToString("F0") + " ms";
            return View();
        }

        public static bool IsEPostaValid(string s)
        {
            //RFC #5322 or #822
            string regexstr = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            regexstr = "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$";
            if (String.IsNullOrEmpty(s.Trim()))
            {
                return false;
            }
            Regex regex = new Regex(regexstr);
            if (!regex.IsMatch(s))
            {
                return false;
            }
            return true;
        }
    }
}