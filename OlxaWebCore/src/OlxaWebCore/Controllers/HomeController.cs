﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Services;
using System.IO;

namespace OlxaWebCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IndexNavigation = true;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description страница.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }
        public IActionResult Step()
        {
            return View();
        }
        public IActionResult PriceList()
        {
            return View();
        }
        public VirtualFileResult DownloadBrief()
        {
            var filepath = Path.Combine("~/Files/Document", "Brief_Olxa.docx");
            return File(filepath, "text/plain", "Brief_Olxa.docx");
        }
    }
}
