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
            string regexstr = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                  + "@"
                                  + @"((([\w]+([-\w]*[\w]+)*\.)+[a-zA-Z]{2,4})|"
                                  + @"((([01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]).){3}[01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))\z";

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