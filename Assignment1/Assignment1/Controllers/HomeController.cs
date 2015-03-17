using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            try
            {
                System.Diagnostics.Process cmdprocess = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
                ////as of right now this is the absolute path of where the batch file is. 
                ////Should probably be made into a relative path so it will be the same for everyone
                startinfo.FileName = "C:\\Users\\Jesus\\Desktop\\test.bat";
                startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startinfo.CreateNoWindow = true;
                startinfo.RedirectStandardInput = true;
                startinfo.RedirectStandardOutput = true;
                startinfo.UseShellExecute = false;
                ////paths of where the source and output files go
                startinfo.Arguments = String.Format("{0} {1}", "C:\\Users\\Jesus\\Desktop\\quicksort.c", "C:\\Users\\Jesus\\Desktop\\test1.txt"); 
                cmdprocess.StartInfo = startinfo;
                cmdprocess.Start();
            }
            catch {
                throw;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}