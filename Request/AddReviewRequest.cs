using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieRESTAPI.Request
{
    public class AddReviewRequest
    {
       // public int ReviewId { get; set; }

        public string ReviewComment { get; set; }

        public int ReviewedMovieId { get; set; }
    }
}
