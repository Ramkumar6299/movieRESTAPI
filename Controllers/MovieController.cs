using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieRESTAPI.Repository;
using movieRESTAPI.Request;

namespace movieRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository repository;
        public MovieController(IMovieRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("Languages")]
        public IActionResult Languages()
        {
            return Ok(repository.allLanguages());
        }
        [HttpGet("Movies")]
        public IActionResult Movies()
        {
            return Ok(repository.allMovies());
        }
        [HttpGet("MoviesByLanguagesId/{languageID}")]
        public IActionResult MoviesByLanguagesId(int languageID)
        {
            return Ok(repository.moviesByLanguage(languageID));
        }
        [HttpGet("MoviesByLanguageName/{{LanguageName}}")]
        public IActionResult MoviesByLanguageName(string languageName)
        {
            return Ok(repository.moviesByLanguageName(languageName));
        }
        [HttpGet("Reviews")]
        public IActionResult Reviews()
        {
            return Ok(repository.allReviews());
        }
        [HttpPost("AddReview")]
        public IActionResult AddReview(AddReviewRequest data)
        {
            return Ok(repository.AddReview(data));
        }
    }
}
