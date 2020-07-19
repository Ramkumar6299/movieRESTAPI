using movieRESTAPI.DTO;
using movieRESTAPI.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieRESTAPI.Repository
{
    public interface IMovieRepository
    {
        public List<LanguageDTO> allLanguages();
        public List<MovieDTO> allMovies();
        public List<MovieByLanguageDTO> moviesByLanguage(int languageID);
        public List<MovieByLanguageDTO> moviesByLanguageName(string languageName);
        public List<ReviewDTO> allReviews();
        public string AddReview(AddReviewRequest request);
    }
}
