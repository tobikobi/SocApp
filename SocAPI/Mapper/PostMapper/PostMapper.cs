using SocAPI.DTO.PostDto;
using SocCL.Models;

namespace SocAPI.Mapper.PostMapper
{
    public static class PostMapper
    {
        public static Post FromCreatePostDto(this CreatePostDto postDto)
        {
            return new Post { Title=postDto.Title, Content = postDto.Content};
        }
        public static Post FromUpdatePostDto(this UpdatePostDto postDto)
        {
            return new Post { Title = postDto.Title, Content = postDto.Content };
        }
    }
}
