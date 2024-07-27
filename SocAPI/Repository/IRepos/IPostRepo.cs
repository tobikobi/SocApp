using SocCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SocCL.Repository.IRepos
{
    public interface IPostRepo
    {
        public Task<IEnumerable<Post>> GetAllPostAsync();
        public Task<Post> GetPostAsync(int id);
        public Task<Post> CreatePostAsync(Post postData);
        public Task<Post> UpdatePostAsync(int id, Post postData);

    }
}
