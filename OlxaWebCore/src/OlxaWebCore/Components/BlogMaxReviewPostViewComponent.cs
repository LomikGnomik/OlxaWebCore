using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Components
{
    public class BlogMaxReviewPostViewComponent :ViewComponent
    {
        private IBlogRepository repository;

        public BlogMaxReviewPostViewComponent(IBlogRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable <Post> bestPost = repository.Posts
                .Where(p => p.Published == true)
                .Take(5)
                .OrderByDescending(p => p.Counter);

            return View(bestPost);
        }
    }
}
