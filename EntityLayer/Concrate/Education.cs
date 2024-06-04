using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ContentText {  get; set; }
        public string? Requirement {  get; set; }
        public string? VideoUrls { get; set; } = "";
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
