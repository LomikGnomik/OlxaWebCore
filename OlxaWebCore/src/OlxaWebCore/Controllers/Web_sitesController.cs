using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OlxaWebCore.Controllers
{
    public class Web_sitesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Vizitka()
        {
            return View();
        }
    }
}