using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieRESTAPI.DTO
{
    public class MovieByLanguageDTO:MovieDTO
    {
        public string Language { get; set; }
    }
}
