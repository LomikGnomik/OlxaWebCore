using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.ViewModels;
using OlxaWebCore.Models.DataModels;

namespace OlxaWebCore.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repository;
        public int PageSize = 2;

        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }

        public ViewResult AllPosts(string category = null, int page = 1)
        {
            BlogListViewModel blogList = new BlogListViewModel
            {
                Posts = repository.Posts
              .Where(p => category == null || p.Category == category)
              .OrderBy(p => p.PostID)
              .Skip((page - 1) * PageSize)
              .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                  repository.Posts.Count() :
                  repository.Posts.Where(e =>
                  e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(blogList);
        }

    

        public ViewResult Post(int Id)
        {
            Post post = repository.Posts.FirstOrDefault(p => p.PostID == Id);
            return View(post);
        }

        //ADMIN

        public ViewResult AllPostsAdmin()
        {
             return View("~/Views/Admin/BlogList.cshtml",repository.Posts);
        }

        // Создание 
        public ViewResult CreatePost() => View("EditPost", new Post());

        // редактирование
        
        public ViewResult EditPost(int postID) =>
            View(repository.Posts
                .FirstOrDefault(p => p.PostID == postID));

        // редактирование POST
        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                repository.SavePost(post);
              //  TempData["message"] = $"{post.Title} has been saved";
                return RedirectToAction("AllPostsAdmin");
            }else
            {
                // что-то не так со значениями данных 
                return View(post);
            }
        }

        // удаление
     //   [HttpPost]
        public IActionResult DeletePost(int postID)
        {
            Post deletedPost = repository.DeletePost(postID);
            if (deletedPost != null)
            {
              //  TempData["message"] = $"{deletedPost.Title} was deleted";
            }
            return RedirectToAction("AllPostsAdmin");
        }
    }
}
