using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class User : IdentityUser<int>
    {
        public required string NameSurname { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? FieldOfInterest { get; set; }
        public bool Sex { get; set; }
        public string? About { get; set; }
        public string? Country { get; set; }
        public string? Adress { get; set; }
        public string? GitHub { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? LinkedIn { get; set; }
        public string? Tweeter { get; set; }
        public string? Website { get; set; }
        public string? KnowTeknologies { get; set; }
        public string? ProgrammingLanguages { get; set; }
        public bool Status { get; set; } = true;
        public List<Blog>? Blogs { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
