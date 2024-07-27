using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocCL.Models
{
    public class Post
    {
        [Key]
        public int? PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
