using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieRESTAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Genere { get; set; }
       
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public List<Review> Review { get; set; }
    }
}
