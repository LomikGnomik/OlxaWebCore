using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Components
{
    public class PortfolioNavigationMenuViewComponent : ViewComponent
    {
        private IPortfolioRepository repository;

        public PortfolioNavigationMenuViewComponent(IPortfolioRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            //    ViewBag.SelectedCategory = RouteData.Values["category"]; // без маршрута не работает

            IEnumerable<string> Category = repository.Portfolios
                .Where(p=>p.Published==true)
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(Category);
        }
    }
}
