using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.ViewModels;
using OlxaWebCore.Models.DataModels;

namespace OlxaWebCore.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository repository;
        public int PageSize = 2;

        public PortfolioController(IPortfolioRepository repo)
        {
            repository = repo;
        }

        public ViewResult All(string category = null, int page = 1)
          => View(
              new PortfolioListViewModel
              {
                  Portfolios = repository.Portfolios
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
              }
          );
        public ViewResult WebSite()
        {

            return View();
        }

        //ADMIN

        // Создание 
        public ViewResult CreatePortfolio() => View("EditPortfolio", new Portfolio());

        // редактирование

        public ViewResult EditPortfolio(int portfolioID) =>
            View(repository.Portfolios
                .FirstOrDefault(p => p.PortfolioID == portfolioID));

        // редактирование POST
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                repository.SavePortfolio(portfolio);
                //  TempData["message"] = $"{post.Title} has been saved";
                return RedirectToAction("All");
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
