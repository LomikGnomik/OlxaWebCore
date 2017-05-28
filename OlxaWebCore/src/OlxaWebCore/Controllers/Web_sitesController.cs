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
        private ISiteRepository repository;
        

        public Web_sitesController(ISiteRepository repo)
        {
            repository = repo;
        }

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
            Site Shop = repository.Sites.FirstOrDefault(s => s.TypeSite == "�������� �������");
            return View(Shop);
        }
        public IActionResult Information()
        {
            return View();
        }
    }
}