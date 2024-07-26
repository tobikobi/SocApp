using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocAPI.DTO.CommentDto;
using SocAPI.Mapper.CommentMapper;
using SocCL.Repository.IRepos;

namespace SocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentRepo commentRepo;
        public CommentController(ICommentRepo commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        [HttpGet("{PostId}")]
        public async Task<IActionResult> GetAllCommentAsync([FromRoute]int PostId)
        {
            var comments = await commentRepo.GetAllCommentsAsync(PostId);
            return Ok(comments);
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute]int id)
        {
            var comment = await commentRepo.GetCommentAsync(id);
            return Ok(comment);
        }*/

        [HttpPost("{PostId}")]
        public async Task<IActionResult> CreateCommentAsync([FromRoute]int PostId, [FromBody]CreateCommentDto commentDto)
        {
            var comment = commentDto.FromCreateCommentDto();
            var res = await commentRepo.CreateCommentAsync(PostId, comment);
            return Ok("Comment created Successfully");
        }

        [HttpPut("{PostId}")]
        public async Task<IActionResult> UpdateCommentAsync([FromRoute] int PostId, [FromBody]UpdateCommentDto commentDto)
        {
            var comment = commentDto.FromUpdateCommentDto();
            var res = await commentRepo.UpdateCommentAsync(PostId, comment);
            return Ok("Successfully updated comment");
        }
    }
}
