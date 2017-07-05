using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Components
{
    // Примеры сайтов из портфолио соответствующие категории
    public class ExamplesSitesViewComponent: ViewComponent
    {
        private IPortfolioRepository repository;

        public ExamplesSitesViewComponent(IPortfolioRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke(string category)
        {
            IEnumerable<Portfolio> site;

            if (category == "Главная")
            {
                
                site = repository.Portfolios
                    .Where(p => p.Published == true)
                    .OrderByDescending(p => p.SortingWeight)
                    .Take(5);
                    ViewBag.PortfolioIndex = true;
            }
            else
            {
                site = repository.Portfolios
                                 .Where(p => p.Published == true & p.Category == category)
                                 .OrderByDescending(p => p.SortingWeight)
                                 .Take(3);
            }
            

            return View(site);
        }
    }
}
