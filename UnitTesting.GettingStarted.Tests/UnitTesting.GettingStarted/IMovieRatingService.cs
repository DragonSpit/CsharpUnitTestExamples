using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.GettingStarted
{
    public interface IMovieRatingService
    {
        int GetMovieRating(Movie movie);
    }
}
