using OlxaWebCore.Data;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products;

        // Save product
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                //  dbEntry.Meta = product.Meta;
                    dbEntry.DemoLink = product.DemoLink;
                    dbEntry.Preview = product.Preview;
                    dbEntry.ShortDescription = product.ShortDescription;
                    dbEntry.TimeDevelop = product.ShortDescription;
                //  dbEntry.Image = (product.ProductID).ToString() + ".jpg";
                    dbEntry.Price = product.Price;
                    dbEntry.Published = product.Published;
                    dbEntry.Category = product.Category;
                    dbEntry.SortingWeight = product.SortingWeight;
                }
            }
            context.SaveChanges();
        }
        // Delete product
        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products
                    .FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}


