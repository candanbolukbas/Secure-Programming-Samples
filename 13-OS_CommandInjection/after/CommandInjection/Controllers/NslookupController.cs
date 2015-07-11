using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace CommandInjection.Controllers
{
    public class NslookupController : Controller
    {
        // GET: Nslookup
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tbxDomain)
        {
            string result = "";

            //RFC #1034
            string ValidIpAddressRegex = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            string ValidHostnameRegex = @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$";

            if (Regex.IsMatch(tbxDomain, ValidHostnameRegex))
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "nslookup.exe",
                        Arguments = tbxDomain,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    result += line + "<br />";
                }

                ViewData["result"] = result;
            }
            else
                ViewData["result"] = "Invalid domain name";
            return View();
        }
    }
}