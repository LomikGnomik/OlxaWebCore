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
     

        public IActionResult Promosite()
        {
            return View();
        }
        public IActionResult Landing()
        {
            return View();
        }
        public IActionResult Corporate()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Information()
        {
            return View();
        }
        public IActionResult Develop()
        {
            return View();
        }
    }
}