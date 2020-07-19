using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieRESTAPI.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }


        public List<Movie> Movie { get; set; }

    }
}
