using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.GettingStarted
{
    public class MovieRating
    {
        // Requirement #3
        public const int MIN_RATING = 0;
        public const int MAX_RATING = 10;

        public User User { get; private set; }
        public Movie Movie { get; private set; }
        public int Rating { get; private set; }

        // Requirement #8 and #1
        public MovieRating(User user, Movie movie, int rating)
        {
            // Requirement #1
            if (user == null)
                throw new ArgumentNullException("user");

            // Requirement #2
            if (movie == null)
                throw new ArgumentNullException("movie");

            // Requirement #3
            if (!IsValidRating(rating))
                throw new ArgumentOutOfRangeException("rating = " + rating + " Rating must be between " + MIN_RATING + " and " + MAX_RATING);

            User = user;
            Movie = movie;
            Rating = rating;
        }

        // Requirement #3
        public static bool IsValidRating(int rating)
        {
            return rating >= MIN_RATING && rating <= MAX_RATING;
        }

        // Requirement #4
        public void ChangeRating(int newRating)
        {
            // Requirement #3
            if (IsValidRating(newRating))
                throw new ArgumentOutOfRangeException("newRating", "Rating must be between " + MIN_RATING + " and " + MAX_RATING);

            Rating = newRating;
        }
    }
}
