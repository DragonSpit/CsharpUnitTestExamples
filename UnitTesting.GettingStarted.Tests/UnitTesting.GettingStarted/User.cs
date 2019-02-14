using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnitTesting.GettingStarted
{
    public class User
    {
        private readonly IMovieRatingService _movieRatingService;    // a user can subscribe to a movie rating service (e.g. Amazon, Netflix, Hulu, ...)

        public User(string username, IMovieRatingService movieRatingService)
        {
            // Requirement #6
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");

            Username = username;

            // Requirement #7
            movieRatings = new Collection<MovieRating>();

            _movieRatingService = movieRatingService;
        }

        // Requirement #6
        public string Username { get; private set; }

        // Requirement #7
        private ICollection<MovieRating> movieRatings;

        // Requirement #6
        public IEnumerable<MovieRating> MovieRatings
        {
            get { return movieRatings; }
        }

        // Requirement #4
        public MovieRating GetRating(Movie movie)
        {
            return MovieRatings.FirstOrDefault(rating => rating.Movie.Id == movie.Id);
        }

        public int GetRatingFromRatingService(Movie movie)
        {
            return _movieRatingService.GetMovieRating(movie);
        }

        // Requirement #8 and #1
        public MovieRating RateMovie(Movie movie, int rating)
        {
            // Requirement #2
            if (movie == null)
                throw new ArgumentNullException("movie");

            var movieRating = GetRating(movie);

            if (movieRating == null)
            {
                // Requirement #5
                movieRating = new MovieRating(this, movie, rating);
                movieRatings.Add(movieRating);
            }
            else
            {
                // Requirement #4
                movieRating.ChangeRating(rating);
            }

            return movieRating;
        }
    }
}
