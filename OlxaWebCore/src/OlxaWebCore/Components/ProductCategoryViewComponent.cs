using Microsoft.AspNetCore.Mvc;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Components
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public ProductCategoryViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke(string category)
        {
            IEnumerable<Product> productList=repository.Products
                .Where(p=>p.Published==true & p.Category==category);


            return View(productList);
        }
    }
}
   

