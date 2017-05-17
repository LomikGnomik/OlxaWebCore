using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;

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
            => View(repository.Portfolios
            .OrderBy(p => p.PortfolioID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize));




    }
}