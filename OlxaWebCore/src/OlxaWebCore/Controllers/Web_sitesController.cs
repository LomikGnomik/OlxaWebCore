using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.DataModels;

namespace OlxaWebCore.Controllers
{
    public class Web_sitesController : Controller
    {
     

        public IActionResult Promosite(string selectedTab="create")
        {
            ViewBag.selectedTab = selectedTab;
            return View();
        }
        public IActionResult Landing(string selectedTab)
        {
            ViewBag.selectedTab = selectedTab;
            return View();
        }
        public IActionResult Corporate(string selectedTab)
        {
            ViewBag.selectedTab = selectedTab;
            return View();
        }
        public IActionResult Shop(string selectedTab)
        {
            ViewBag.selectedTab = selectedTab;
            return View();
        }
        public IActionResult Information(string selectedTab)
        {
            ViewBag.selectedTab = selectedTab;
            return View();
        }
        public IActionResult Develop()
        {
            return View();
        }
        public IActionResult Creation()
        {
            return View();
        }
    }
}