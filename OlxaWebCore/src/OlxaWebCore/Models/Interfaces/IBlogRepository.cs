using OlxaWebCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Interfaces
{
   public interface IBlogRepository
    {
            IEnumerable<Post> Posts { get; }

            void SavePost (Post post );
         //   Post DeletePost(int ID);
    }
}
