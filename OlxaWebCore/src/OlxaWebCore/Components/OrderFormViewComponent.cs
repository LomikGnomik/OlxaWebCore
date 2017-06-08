using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Components
{
    public class OrderFormViewComponent : ViewComponent
    {
        private IOrderRepository repository;

        public OrderFormViewComponent(IOrderRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(new Order());
        }
    }
}
