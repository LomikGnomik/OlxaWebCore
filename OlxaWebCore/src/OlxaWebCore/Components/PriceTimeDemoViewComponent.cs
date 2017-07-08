using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Components
{
    public class PriceTimeDemoViewComponent : ViewComponent
    {
        private IServiceRepository repository;

        public PriceTimeDemoViewComponent(IServiceRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke(string title)
        {

            Service price = repository.Services.FirstOrDefault(p=>p.Title==title & p.Published==true);

            if (price == null)
            {
                price = new Service();
            }

            return View(price);
        }
    }
}
