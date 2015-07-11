using System.Diagnostics;
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

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c nslookup " + tbxDomain,
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
            return View();
        }
    }
}