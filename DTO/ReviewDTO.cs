using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieRESTAPI.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public string ReviewComment { get; set; }
        public string MovieReviewed { get; set; }

    }
}
