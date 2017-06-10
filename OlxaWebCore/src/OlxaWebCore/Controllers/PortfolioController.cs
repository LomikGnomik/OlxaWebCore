using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.ViewModels;
using OlxaWebCore.Models.DataModels;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace OlxaWebCore.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository repository;
        IHostingEnvironment _appEnvironment;

        public int PageSize = 100;

        public PortfolioController(IPortfolioRepository repo , IHostingEnvironment appEnvironment)
        {
            repository = repo;
            _appEnvironment = appEnvironment;
        }

        public ViewResult All(string category = null, int page = 1)
        {
            IEnumerable<Portfolio> UserPortfolio = repository.Portfolios
                    .Where(p => p.Published == true);

          PortfolioListViewModel PortfolioList=  new PortfolioListViewModel
            {
                Portfolios = UserPortfolio
                  .Where(p => category == null || p.Category == category)
                  .OrderBy(p => p.PortfolioID)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                      repository.Portfolios.Count() :
                      repository.Portfolios.Where(e =>
                      e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(PortfolioList);
        }
               

     

        public ViewResult WebSite(int PortfolioID)
        {
            return View(repository.Portfolios.FirstOrDefault(p=>p.PortfolioID== PortfolioID));
        }

        //ADMIN

        public ViewResult AllAdmin()
        {
            return View(repository.Portfolios);
        }
        // Создание 
        public ViewResult CreatePortfolio() => View("EditPortfolio", new Portfolio());

        // редактирование
        public ViewResult EditPortfolio(int portfolioID) =>
            View(repository.Portfolios
                .FirstOrDefault(p => p.PortfolioID == portfolioID));

        // редактирование POST
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio, IFormFile file)
        {

            //сохранение картинок
            if (file != null)
            {
                // путь к папке Files
                string path = "/Files/Portfolio/" + file.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
            }

            if (ModelState.IsValid)
            {
                repository.SavePortfolio(portfolio);
                //  TempData["message"] = $"{post.Title} has been saved";
                return RedirectToAction("AllAdmin");
            }
            else
            {
                // что-то не так со значениями данных 
                return View(portfolio);
            }
        }

        // удаление
        [HttpPost]
        public IActionResult DeletePortfolio(int portfolioID)
        {
            Portfolio deletedPortfolio = repository.DeletePortfolio(portfolioID);
            if (deletedPortfolio != null)
            {
                //  TempData["message"] = $"{deletedPost.Title} was deleted";
            }
            return RedirectToAction("All");
        }
    }             
    }
