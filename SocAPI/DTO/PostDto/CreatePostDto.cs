﻿using SocCL.Models;

namespace SocAPI.DTO.PostDto
{
    public class CreatePostDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
