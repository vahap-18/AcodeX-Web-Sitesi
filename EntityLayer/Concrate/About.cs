﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string Detail { get; set; }
        public string? Image { get; set; }
        public string? MapLocation{ get; set; }
        public bool Status { get; set; }

    }
}
