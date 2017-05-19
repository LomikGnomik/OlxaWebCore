using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}