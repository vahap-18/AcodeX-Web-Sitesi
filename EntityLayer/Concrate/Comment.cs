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
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int BlogId { get; set; }
        public Blog Blogs { get; set; }
    }
}
