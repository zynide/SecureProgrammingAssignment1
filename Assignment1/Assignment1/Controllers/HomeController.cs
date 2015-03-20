﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Logic;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            ViewBag.ErrorMessage = "";
            if (file != null && file.ContentLength > 0)
                try
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    if (extension != AcceptableTypes.C && extension != AcceptableTypes.CPP) 
                    {
                        ViewBag.ErrorMessage = "Please enter a .c or .cpp file.";
                    }
                    else
                    {
                        string path = Server.MapPath("~/CPP");
                        string filePath = Path.Combine(path, String.Format("{0}{1}",Filetypes.inputFile, extension));
                        file.SaveAs(filePath);
                        ProcessFile process = new ProcessFile(path, extension);
                        ViewBag.Message = "File uploaded successfully";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.ErrorMessage = "You have not specified a file.";
            }
            return View();
        }

    }
}