using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.ViewModels;

namespace OlxaWebCore.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repository;
        public int PageSize = 4;

        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }

        public ViewResult AllPosts(int page = 1)
        => View(new BlogListViewModel
        {
            Posts = repository.Posts
            .OrderBy(p => p.PostID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Posts.Count()
            }
        });

        //ADMIN

            // редактирование
        public ViewResult Edit(int postID) =>
            View(repository.Posts
                .FirstOrDefault(p => p.PostID == postID));

    }
}
