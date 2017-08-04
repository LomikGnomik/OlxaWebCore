using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.DataModels;

namespace OlxaWebCore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult AllProducts()
        {
            return View(repository.Products);
        }

        public IActionResult Product(int productID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID); 
            return View(product);
        }

        public IActionResult AllProductsAdmin()
        {
            return View();
        }

        public IActionResult EditProduct()
        {
            return View();
        }
    }
}