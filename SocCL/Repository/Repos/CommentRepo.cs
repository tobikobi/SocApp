using Dapper;
using SocCL.Models;
using SocCL.Repository.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocCL.Repository.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationDbContext context;
        public CommentRepo(ApplicationDbContext context) { 
            this.context = context;
        }
        public async Task<Comment> CreateCommentAsync(int postId, Comment commentData)
        {
            using (var conn = context.CreateConnection()) {
                var sql = "INSERT INTO Comments(Body, DateTime, PostId) values(@body, @datetime, @post_id);";
                var exec = await conn.QueryAsync<int>(sql, new {body= commentData.Body, datetime = commentData.DateTime, post_id = postId});
                return commentData;
            }
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(int postId)
        {
            using (var conn = context.CreateConnection())
            {
                var sql = "Select * from Comments where PostId = @postId";
                var exec = await conn.QueryAsync<Comment>(sql, new {postId = postId});
                return exec;
            }
        }

        /*public async Task<Comment> GetCommentAsync(int id)
        {
            using (var conn = context.CreateConnection())
            {
                var sql = "Select * from Comments where CommentId = @Id";
                var exec = await conn.QueryAsync<Comment>(sql, new {Id = id});
                return exec.FirstOrDefault();
            }
        }*/

        public async Task<Comment> UpdateCommentAsync(int id, Comment commentData)
        {
            using (var conn = context.CreateConnection())
            {
                var sql = "Update Comments SET Body = @Body where CommentId = @Id";
                var exec = await conn.QueryAsync<int>(sql, new { Body = commentData.Body, Id = id });
                return commentData;
            }
        }
    }
}
