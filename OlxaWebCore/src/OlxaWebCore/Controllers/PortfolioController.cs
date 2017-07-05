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
using System;

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
                    .OrderByDescending(p => p.SortingWeight)
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

        // предыщий или следующий сайт при просмотре конкретного портфолио
        public ViewResult PreviousNextSite(int SiteId, bool next)
        {
            int[] allSites = repository.Portfolios
                .Where(p=>p.Published==true)
                .Select(d=>d.PortfolioID).ToArray();

            int index = Array.IndexOf(allSites, SiteId);



            if (index == 0)
            {
                index = allSites.Count();
            }
              else if(index==allSites.Count())
            {
                index = 0;
            }  


            Portfolio site=new Portfolio(); 

            if (next == true )
            {
int nextId =allSites[index+1];
site= repository.Portfolios.FirstOrDefault(p => p.PortfolioID == nextId);
            }
            else
            {
int previousId = allSites[index - 1];
site= repository.Portfolios.FirstOrDefault(p => p.PortfolioID == previousId);
            }
            

            return View("WebSite",site);
        }

        //ADMIN

        public ViewResult AllAdmin()
        {
            return View(repository.Portfolios);
        }
        // —оздание 
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
                // Ќазвание картинки
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
                // что-то не так со значени€ми данных 
                return View(portfolio);
            }
        }

        public async void SaveFile(IFormFile file , string path)
        {
            string road = _appEnvironment.WebRootPath + path;
            if (file != null)
            {
                try
                {
                    // сохран€ем в каталоге wwwroot/Files/Portfolio
                    using (var fileStream = new FileStream(road, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                catch
                {
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
