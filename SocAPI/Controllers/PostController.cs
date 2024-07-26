using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocAPI.DTO.PostDto;
using SocAPI.Mapper.PostMapper;
using SocCL.Models;
using SocCL.Repository.IRepos;
using SocCL.Repository.Repos;

namespace SocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;
        public PostController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostAsync() { 
            var posts = await _postRepo.GetAllPostAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByIdAsync([FromRoute]int id)
        {
            var post = await _postRepo.GetPostAsync(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync([FromBody]CreatePostDto postDto)
        {
            Post postCreate = postDto.FromCreatePostDto();
            var post = await _postRepo.CreatePostAsync(postCreate);
            return Ok("Successfully created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostAsync([FromRoute]int id, [FromBody]UpdatePostDto postDto)
        {
            Post postUpdate = postDto.FromUpdatePostDto();
            var post = await _postRepo.UpdatePostAsync(id, postUpdate);
            return Ok("Successfully updated");
        }

    }
}
