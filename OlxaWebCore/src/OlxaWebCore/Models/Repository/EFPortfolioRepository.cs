using OlxaWebCore.Data;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Repository
{
    public class EFPortfolioRepository : IPortfolioRepository
    {
        private ApplicationDbContext context;

        public EFPortfolioRepository(ApplicationDbContext ctx)
        {
           context = ctx;
        }
        public IEnumerable<Portfolio> Portfolios => context.Portfolios;

        // Save portfolio
        public void SavePortfolio(Portfolio portfolio)
        {
            if (portfolio.PortfolioID == 0)
            {
                context.Portfolios.Add(portfolio);
            }
            else
            {
                Portfolio dbEntry = context.Portfolios
                    .FirstOrDefault(p => p.PortfolioID == portfolio.PortfolioID);
                if (dbEntry != null)
                {

                    dbEntry.Title = portfolio.Title;
                    //  dbEntry.ShortDescription = post.ShortDescription;
                      dbEntry.Description = portfolio.Description;
                    //  dbEntry.Meta = post.Meta;
                    //  dbEntry.UrlSlug = post.UrlSlug;
                    //  dbEntry.Published = post.Published;
                    //  dbEntry.PostedOn = post.PostedOn;
                    //  dbEntry.Modified = post.Modified;
                    dbEntry.Category = portfolio.Category;
                    //  dbEntry.Tags = post.Tags;
                }
            }
            context.SaveChanges();
        }
        // Delete portfolio
        public Portfolio DeletePortfolio(int portfolioID)
        {
            Portfolio dbEntry = context.Portfolios
                    .FirstOrDefault(p => p.PortfolioID == portfolioID);
            if (dbEntry != null)
            {
                context.Portfolios.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
