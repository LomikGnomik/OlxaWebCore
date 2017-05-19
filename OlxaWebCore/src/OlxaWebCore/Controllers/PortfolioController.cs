using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.ViewModels;

namespace OlxaWebCore.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository repository;
        public int PageSize = 4;

        public PortfolioController(IPortfolioRepository repo)
        {
            repository = repo;
        }

        public ViewResult All(int page = 1)
        => View(new PortfolioListViewModel {
            Portfolios = repository.Portfolios
            .OrderBy(p => p.PortfolioID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Portfolios.Count()
            }
        });
}             
    }
