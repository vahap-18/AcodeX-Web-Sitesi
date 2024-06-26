﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public bool Status { get; set; } = true;
        public List<Blog>? Blogs { get; set; }

    }
}
