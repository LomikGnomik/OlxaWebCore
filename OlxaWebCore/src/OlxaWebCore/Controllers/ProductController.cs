using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.ViewModels;

namespace OlxaWebCore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 200;


        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult AllProducts(string category = null, int page = 1)
        {
            IEnumerable<Product> publishProduct = repository.Products
               .Where(p => p.Published == true);

           ProductListViewModel productList = new ProductListViewModel
            {
                Products = publishProduct
              .Where(p => category == null || p.Category == category)
              .OrderBy(p => p.ProductID)
              .Skip((page - 1) * PageSize)
              .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                  repository.Products.Count() :
                  repository.Products.Where(e =>
                  e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(productList);
        }

        public IActionResult Product(int productID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID); 
            return View(product);
        }


        public IActionResult AllProductsAdmin()
        {
            return View(repository.Products);
        }

        // Создание 
        public ViewResult CreateProduct() => View("EditProduct", new Product());


        public IActionResult EditProduct(int productID) =>
            View(repository.Products
                .FirstOrDefault(p => p.ProductID == productID));


        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
               
                return RedirectToAction("AllProductsAdmin");
            }
            else
            {
                // что-то не так со значениями данных 
                return View(product);
            }
        }


        // удаление
        [HttpPost]
        public IActionResult DeleteProduct(int productID)
        {
            Product deletedProduct = repository.DeleteProduct(productID);
            if (deletedProduct != null)
            {
                //  TempData["message"] = $"{deletedPost.Title} was deleted";
            }
            return RedirectToAction("AllProductsAdmin");
        }

    }
}