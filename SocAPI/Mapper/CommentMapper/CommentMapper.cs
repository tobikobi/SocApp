using SocAPI.DTO.CommentDto;
using SocCL.Models;

namespace SocAPI.Mapper.CommentMapper
{
    public static class CommentMapper
    {
        public static Comment FromCreateCommentDto(this CreateCommentDto commentDto)
        {
            return new Comment() { Body = commentDto.Body };
        }
        public static Comment FromUpdateCommentDto(this UpdateCommentDto commentDto)
        {
            return new Comment() { Body = commentDto.Body };
        }
    }
}
