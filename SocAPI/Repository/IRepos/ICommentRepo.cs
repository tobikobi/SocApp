using SocCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocCL.Repository.IRepos
{
    public interface ICommentRepo
    {
        public Task<IEnumerable<Comment>> GetAllCommentsAsync(int postId);
        /*public Task<Comment> GetCommentAsync(int id);*/
        public Task<Comment> CreateCommentAsync(int postId, Comment commentData);
        public Task<Comment> UpdateCommentAsync(int postId, Comment commentData);
    }
}
