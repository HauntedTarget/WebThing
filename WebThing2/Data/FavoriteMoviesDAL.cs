using System.Reflection.Metadata.Ecma335;
using WebThing2.Interfaces;
using WebThing.Models;

namespace WebThing2.Data
{
    public class FavoriteMoviesDAL : IDataAccessLayer
    {
        private static List<Movie> MovieList = new()
        {
            new Movie("Bee Movie", 2007, 2.0f),
            new Movie("Mars Needs Moms", 2011, 1.0f),
            new Movie("Sharknado", 2013, 2.5f),
            new Movie("The Last Airbender", 2010, 0.0f),
            new Movie("Emoji Movie", 2017, float.MinValue)
        };

        public void AddMovie(Movie movie)
        {
            MovieList.Add(movie);
        }

        public Movie? GetMovie(int id)
        {
            return MovieList.FirstOrDefault(m => m.ID == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return MovieList;
        }

        public void RemoveMovie(int id)
        {
            Movie? found = GetMovie(id);
            if (found != null) MovieList.Remove(found);
        }

        void UpdateMovie(Movie movie)
        {
            int index;
            index = MovieList.FindIndex(x => x.ID == movie.ID);
            MovieList[index] = movie;
        }

        void IDataAccessLayer.UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
