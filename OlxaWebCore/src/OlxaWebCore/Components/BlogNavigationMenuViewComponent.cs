using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Components
{
    public class BlogNavigationMenuViewComponent :ViewComponent
    {
        private IBlogRepository repository;

        public BlogNavigationMenuViewComponent(IBlogRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory =RouteData.Values["category"]; // без маршрута не работает
            IEnumerable < string > Category= repository.Posts
                .Where(p => p.Published == true)
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            Dictionary<string, int> pcsInCategory = new Dictionary<string, int>();
            foreach (var cate in Category)
            {
                int pcs = repository.Posts.Count(x => x.Category == cate & x.Published == true);
                pcsInCategory.Add(cate, pcs);
            }
            ViewBag.pcsInCategory = pcsInCategory;

            return View(Category);
        }
    }
}
