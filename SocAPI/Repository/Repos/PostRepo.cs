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
    public class PostRepo:IPostRepo
    {
        private readonly ApplicationDbContext _context;
        public PostRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "select p.PostId as PostId, p.Title, p.Content, p.DateTime, c.CommentId, c.Body, C.DateTime from Posts p left join Comments c on p.PostId = c.PostId;";
                var posts = await connection.QueryAsync<Post, Comment, Post>(sql, (post, comment) => {
                    if (post.Comments == null)
                    {
                        post.Comments = new List<Comment>();
                    }
                    post.Comments.Add(comment);
                    return post; }, 
                    splitOn: "CommentId");
                return posts.ToList();

            }

        }
        public async Task<Post> GetPostAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "select p.PostId as PostId, p.Title, p.Content, p.DateTime, c.CommentId, c.Body, c.DateTime from Posts p left join Comments c on p.PostId = c.PostId where p.PostId = @Id";
                var post = await connection.QueryAsync<Post, Comment, Post>(sql, (post, comment) => {
                    if (post.Comments == null)
                    {
                        post.Comments = new List<Comment>();
                    }
                    post.Comments.Add(comment);
                    return post; }, 
                    splitOn: "CommentId", param: new { Id = id });
                return post.FirstOrDefault();
            }
        }

        public async Task<Post> CreatePostAsync(Post postData)
        {
            using(var connection = _context.CreateConnection())
            {
                var sql = "insert into Posts(Title, Content, DateTime) values(@Title, @Content, @DateTime)";
                var postId = await connection.QueryAsync<int>(sql, new {Title = postData.Title, Content = postData.Content, DateTime = postData.DateTime});
                postData.PostId = postId.FirstOrDefault();
                return postData;
            }
        }

        public async Task<Post> UpdatePostAsync(int id, Post postData)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "update Posts set Content=@Content, Title=@Title where PostId=@Id";
                var postId = await connection.QueryAsync<int>(sql, new {  Content = postData.Content, Title = postData.Title, Id = id});
                var sql2 = "select * from Posts where PostId=@Id";
                var post = await connection.QueryAsync<Post>(sql2, new { Id = postId.FirstOrDefault() });
                return post.FirstOrDefault();
            }

        }

    }
}
