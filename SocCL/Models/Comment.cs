using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocCL.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;

        [ForeignKey("PostId")]
        public Post? Post { get; set; }

    }
}
