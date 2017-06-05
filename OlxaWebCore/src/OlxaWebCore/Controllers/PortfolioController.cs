using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.ViewModels;
using OlxaWebCore.Models.DataModels;
using System.Collections;
using System.Collections.Generic;

namespace OlxaWebCore.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository repository;
        public int PageSize = 100;

        public PortfolioController(IPortfolioRepository repo)
        {
            repository = repo;
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
        // �������� 
        public ViewResult CreatePortfolio() => View("EditPortfolio", new Portfolio());

        // ��������������

        public ViewResult EditPortfolio(int portfolioID) =>
            View(repository.Portfolios
                .FirstOrDefault(p => p.PortfolioID == portfolioID));

        // �������������� POST
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
           
            if (ModelState.IsValid)
            {
                repository.SavePortfolio(portfolio);
                //  TempData["message"] = $"{post.Title} has been saved";
                return RedirectToAction("AllAdmin");
            }
            else
            {
                // ���-�� �� ��� �� ���������� ������ 
                return View(portfolio);
            }
        }

        // ��������
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
