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
            // str 310
        }
    //public Post DeletePost(Post postId)
       // {
            //str 322
         //   return 
       // } 
    }
}
