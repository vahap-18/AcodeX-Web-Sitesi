using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EntityLayer.Concrate
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreateDate { get; set; }
        public string? Image { get; set; } = "";
        public bool Status { get; set; } = true;
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
        public int WriterId { get; set; }
        public Writer? Writer { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
