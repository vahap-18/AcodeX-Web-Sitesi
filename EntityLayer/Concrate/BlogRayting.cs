using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class BlogRayting
    {
        public int BlogRaytingId { get; set; }
        public int BlogId { get; set; }
        public int BlogTotalScore { get; set; } = 0;
        public int BlogRaytingCount { get; set; } = 0;
    }
}
