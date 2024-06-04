 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public required string UserName { get; set; } 
        public required string UserEmail { get; set; }
        public required string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int BlogScore { get; set; } = 0;
        public bool Status { get; set; } = true;
        public int BlogId { get; set; }
        public Blog? Blogs { get; set; } 
    }
}
