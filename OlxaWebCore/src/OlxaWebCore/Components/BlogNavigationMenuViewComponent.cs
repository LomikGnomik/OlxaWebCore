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
            return View(repository.Posts
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
