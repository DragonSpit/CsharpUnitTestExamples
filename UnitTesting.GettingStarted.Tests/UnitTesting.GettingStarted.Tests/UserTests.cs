using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace UnitTesting.GettingStarted.Tests
{
    [TestFixture]
    class UserTests
    {
        private Mock<IMovieRatingService> mockMovieRatingService;
        //private readonly User _user = new User("Victor", null);
        //private readonly Movie _movie = new Movie(1, "Star Trek");
        //private readonly MovieRating _movieRating = new MovieRating(_user, _movie, 9);

        [Test]
        public void UserRatesFirstMovie_Always_ReturnsRatings()
        {
            var systemUnderTest = new User("Victor", null);
            var movie = new Movie(1, "Star Trek");

            systemUnderTest.RateMovie(movie, 9);

            systemUnderTest.GetRating(movie).Should().BeEquivalentTo(new MovieRating(systemUnderTest, movie, 9));
        }
        [Test]
        public void UserRatesMultipleMovies_Always_ReturnsExpectedNumberOfRatings()
        {
            var systemUnderTest = new User("Victor", null);
            var movie1 = new Movie(1, "Star Trek");
            var movie2 = new Movie(2, "Star Wars");

            systemUnderTest.RateMovie(movie1, 9);
            systemUnderTest.RateMovie(movie2, 8);

            systemUnderTest.GetRating(movie1).Should().BeEquivalentTo(new MovieRating(systemUnderTest, movie1, 9));
            systemUnderTest.GetRating(movie2).Should().BeEquivalentTo(new MovieRating(systemUnderTest, movie2, 8));
            systemUnderTest.MovieRatings.Should().HaveCount(2);
        }
        [Test]
        public void UserRatesANullMovie_Always_ReturnsNullArgumentException()
        {
            var systemUnderTest = new User("Victor", null);

            Action act = () => systemUnderTest.RateMovie(null, 7);  // Can't test methods directly. Turn them into Action to test

            act.Should().Throw<ArgumentNullException>();
        }
        [TestCase(1, "Star Trek Voyager", 8)]
        [TestCase(2, "Star Trek Next Generation", 10)]
        public void UserRequestsMovieRatingFromService_Always_ServiceReturnsRating(int movieId, string movieTitle, int movieRating)
        {
            var movie = new Movie(movieId, movieTitle);
            mockMovieRatingService = new Mock<IMovieRatingService>(MockBehavior.Strict);
            mockMovieRatingService.Setup(p => p.GetMovieRating(movie)).Returns(movieRating);

            var systemUnderTest = new User("Victor", mockMovieRatingService.Object);

           // Action act = () => systemUnderTest.GetRatingFromRatingService(movie);  // Can't test methods directly. Turn them into Action to test

            Assert.That(systemUnderTest.GetRatingFromRatingService(movie), Is.EqualTo(movieRating));
        }
    }
}
