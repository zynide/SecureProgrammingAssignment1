using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Logic;

namespace Assignment1.Controllers
{
    public class DownloadController : Controller
    {
        public ActionResult OutputFileDownload()
        {
            ActionResult result;
            try
            {
                string outputFilePath = Path.Combine(Server.MapPath("~/CPP"), Filetypes.outputFile);
                byte[] bytes = System.IO.File.ReadAllBytes(outputFilePath);
                result = File(bytes, Path.GetExtension(outputFilePath).ToLower(), Path.GetFileName(outputFilePath));
            }
            catch (Exception ex)
            {
                result = RedirectToAction("Home");
            }
            return result;
        }
    }
}
