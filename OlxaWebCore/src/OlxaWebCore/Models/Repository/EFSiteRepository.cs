using OlxaWebCore.Data;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Repository
{
    public class EFSiteRepository : ISiteRepository
    {
        private ApplicationDbContext context;

        public EFSiteRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Site> Sites => context.Sites;

        // Save site
        public void SaveSite(Site site)
        {
            if (site.SiteID == 0)
            {
                context.Sites.Add(site);
            }
            else
            {
                Site dbEntry = context.Sites
                    .FirstOrDefault(p => p.SiteID == site.SiteID);
                if (dbEntry != null)
                {

                    dbEntry.Name = site.Name;
                    //  dbEntry.ShortDescription = post.ShortDescription;
                    dbEntry.Description = site.Description;
                    dbEntry.Price = site.Price;
                    dbEntry.TypeSite = site.TypeSite;
                    //  dbEntry.Meta = post.Meta;
                    //  dbEntry.UrlSlug = post.UrlSlug;
                    //  dbEntry.Published = post.Published;
                    //  dbEntry.PostedOn = post.PostedOn;
                    //  dbEntry.Modified = post.Modified;
                   // dbEntry.Category = site.Category;
                    //  dbEntry.Tags = post.Tags;
                }
            }
            context.SaveChanges();
        }
        // Delete site
        public Site DeleteSite(int siteID)
        {
            Site dbEntry = context.Sites
                    .FirstOrDefault(p => p.SiteID == siteID);
            if (dbEntry != null)
            {
                context.Sites.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }

}
