using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; } 
        public  required string Message { get; set; } 
        public DateTime Date { get; set; }
        public bool Status { get; set; } = true;
    }
}
