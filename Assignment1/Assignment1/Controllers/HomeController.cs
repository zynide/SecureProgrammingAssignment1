using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ContentResult UploadFile(string test)
        {
            HttpRequestBase request = HttpContext.Request;
            bool formUpload = request.Files.Count > 0;
            string xFileName = request.Headers["X-File-Name"];
            string qqFile = request["qqfile"];
            string formFilename = formUpload ? request.Files[0].FileName : null;
            string filename = xFileName ?? qqFile ?? formFilename;
            Stream inputStream = formUpload ? request.Files[0].InputStream : request.InputStream;
            string filePath = Path.Combine(HttpContext.Server.MapPath("~/App_Data"), filename);
            string fileExtension = Path.GetExtension(filename);
            BinaryReader binReader = new BinaryReader(inputStream);
            byte[] binData = binReader.ReadBytes((int)inputStream.Length);
            
            string result = "{\"success\":true}";
            return new ContentResult { Content = result, ContentType = "text/plain" };
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    ////file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

    }
}