using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;

namespace OlxaWebCore.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout(int typeSiteId) => View(new Order());


        public ViewResult Checkout(Order order)
        {
            return View();
        }
    }
}