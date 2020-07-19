using Microsoft.EntityFrameworkCore;
using movieRESTAPI.DTO;
using movieRESTAPI.Models;
using movieRESTAPI.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieRESTAPI.Repository
{
    public class MovieRepository:IMovieRepository
    {
        private readonly MovieDbContext _db;


        public MovieRepository(MovieDbContext db)
        {
            this._db = db;
        }

        //API to Add new review for particular movie....
        public string AddReview(AddReviewRequest request)
        {
            if(request != null)
            {
                Review addingReview = new Review();
                //addingReview.Id = request.ReviewId;(identity element)
                var movies = _db.Movie.ToList();
                int count = 0;
                foreach(var item in movies)
                {
                    count++; 
                    if(request.ReviewedMovieId==item.Id)
                    {
                        addingReview.MovieId = request.ReviewedMovieId;
                        break;
                    }
                    else if(count == movies.Count)
                    {
                        return "MovieId Given Is Invalid.Please,Enter Valid movieId(Kindly,check with movies API for information";
                    }
                }
                
                addingReview.Comment = request.ReviewComment;
                _db.Review.Add(addingReview);
                _db.SaveChanges();
                return "Successfully Review Added";
            }
            return "Unsuccessfully,Due to Null value.Please,enter valid contents";
        }

        //To Display List of All Availabe Languages.....
        public List<LanguageDTO> allLanguages()
        {
            List<LanguageDTO> languageList = new List<LanguageDTO>();
            var languages = _db.Language.ToList();
            foreach (var item in languages)
            {
                languageList.Add(new LanguageDTO()
                {
                    LanguageName = item.LanguageName
                });

            }
            return languageList;
        }

        //To display the list of all available Movies....
        public List<MovieDTO> allMovies()
        {
            List<MovieDTO> moviesList = new List<MovieDTO>();
            var movies = _db.Movie.ToList();
            foreach (var item in movies)
            {
                moviesList.Add(new MovieDTO()
                {
                    MovieName = item.MovieName,
                    GenereOfTheMovie = item.Genere,
                    MovieId = item.Id
                });
            }
            return moviesList;
        }

        //To display the list of all available reviews....
        public List<ReviewDTO> allReviews()
        {
            List<ReviewDTO> reviewsList = new List<ReviewDTO>();
            var reviews = _db.Review.ToList();
            var movies = _db.Movie.ToList();
            string movieName = "";
           
            foreach(var item in reviews)
            {
                
                foreach (var item1 in movies)
                {
                    if (item.MovieId==item1.Id)
                    {
                        movieName = item1.MovieName;
                        break;
                    }
                }
                reviewsList.Add(new ReviewDTO()
                {
                    
                    ReviewId = item.Id,
                    ReviewComment = item.Comment,
                    MovieReviewed =  movieName
                });
            }
            return reviewsList;
            
        }

        //To display movies list based on languageId....
        public List<MovieByLanguageDTO> moviesByLanguage(int languageID)
        {
            List<MovieByLanguageDTO> moviesListByLanguage = new List<MovieByLanguageDTO>();

            var movies = _db.Movie.Include("Language").Where(a => a.LanguageId == languageID).ToList();
            foreach (var item in movies)
            {
                moviesListByLanguage.Add(new MovieByLanguageDTO()
                {
                    MovieName = item.MovieName,
                    GenereOfTheMovie = item.Genere,
                    Language = item.Language.LanguageName,
                    MovieId = item.Id
                });
            }
            return moviesListByLanguage;
        }

        //To display movies list based on given language name
        public List<MovieByLanguageDTO> moviesByLanguageName(string languageName)
        {
            List<MovieByLanguageDTO> moviesListByLanguageName = new List<MovieByLanguageDTO>();
            var language = _db.Language.Where(a => a.LanguageName == languageName).FirstOrDefault();
            int language_id = language.Id;
            moviesListByLanguageName = moviesByLanguage(language_id);
            return moviesListByLanguageName;

        }
    }
}
