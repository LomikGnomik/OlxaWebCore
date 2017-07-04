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

        public PortfolioController(IPortfolioRepository repo, IHostingEnvironment appEnvironment)
        {
            repository = repo;
            _appEnvironment = appEnvironment;
        }

        public ViewResult All(string category = null, int page = 1)
        {
            IEnumerable<Portfolio> UserPortfolio = repository.Portfolios
                    .Where(p => p.Published == true);

            PortfolioListViewModel PortfolioList = new PortfolioListViewModel
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
            return View(repository.Portfolios.FirstOrDefault(p => p.PortfolioID == PortfolioID));
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
        public IActionResult EditPortfolio(Portfolio portfolio, IFormFile desktop, IFormFile tablet, IFormFile mobile, IFormFile preview)
        {
            if (ModelState.IsValid)
            {
                repository.SavePortfolio(portfolio);
                // Название картинки
                portfolio.Image = portfolio.PortfolioID.ToString() + ".jpg";

                SaveFile(desktop, "/Files/Portfolio/Image/Desktop/"+portfolio.Image);
                SaveFile(tablet, "/Files/Portfolio/Image/Tablet/" + portfolio.Image);
                SaveFile(mobile, "/Files/Portfolio/Image/Mobile/" + portfolio.Image);
                SaveFile(preview, "/Files/Portfolio/Image/Preview/" + portfolio.Image);

                //  TempData["message"] = $"{post.Title} has been saved";
                return RedirectToAction("AllAdmin");
            }
            else
            {
                // что-то не так со значениями данных 
                return View(portfolio);
            }
        }

        public async void SaveFile(IFormFile file , string path)
        {
            if (file != null)
            {
                // сохраняем в каталоге wwwroot/Files/Portfolio
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                   await file.CopyToAsync(fileStream);
                }
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
            return RedirectToAction("AllAdmin");
        }
    }
}
