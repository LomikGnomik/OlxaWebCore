using OlxaWebCore.Data;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Repository
{
    public class EFBlogRepository:IBlogRepository
    {
            private ApplicationDbContext context;

            public EFBlogRepository(ApplicationDbContext ctx)
            {
                context = ctx;
            }
            public IEnumerable<Post> Posts => context.Posts;

        // Save post
        public void SavePost(Post post)
        {
            if (post.PostID == 0)
            {
                post.PostedOn = DateTime.Now;
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts
                    .FirstOrDefault(p=>p.PostID==post.PostID);
                if (dbEntry != null)
                {
                    dbEntry.Title = post.Title;
                    dbEntry.ShortDescription = post.ShortDescription;
                    dbEntry.Description = post.Description;
                    dbEntry.Meta = post.Meta;
                    //  dbEntry.UrlSlug = post.UrlSlug;
                    dbEntry.Picture = post.Picture;
                    dbEntry.Published = post.Published;
                    dbEntry.PostedOn = post.PostedOn;
                  //  dbEntry.Modified = post.Modified;
                    dbEntry.Category = post.Category;
                  //  dbEntry.Tags = post.Tags;
                }    
            }
        context.SaveChanges();
        }
        // Delete post
        public Post DeletePost(int postID)
         {
            Post dbEntry = context.Posts
                    .FirstOrDefault(p => p.PostID == postID);
            if (dbEntry != null)
            {
                context.Posts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
         }
        // Счётчик просмотров
        public void CountView(int postID)
        {  
            context.Posts.FirstOrDefault(p => p.PostID == postID).Counter++;
            context.SaveChanges();
        }
    }
}
