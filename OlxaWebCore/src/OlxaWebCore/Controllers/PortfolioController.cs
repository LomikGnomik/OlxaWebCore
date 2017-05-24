using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.ViewModels;

namespace OlxaWebCore.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository repository;
       

        public PortfolioController(IPortfolioRepository repo)
        {
            repository = repo;
        }

        public ViewResult All()
        {

            return View();
        }
        public ViewResult WebSite()
        {

            return View();
        }
    }             
    }
