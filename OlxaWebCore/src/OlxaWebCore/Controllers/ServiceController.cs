using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;

namespace OlxaWebCore.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepository repository;

        public ServiceController(IServiceRepository repo)
        {
            repository = repo;
        }

        public IActionResult AllService()
        {
            return View(repository.Services.Where(s=>s.Published==true));
        }

    }
}