using System.Reflection.Metadata.Ecma335;
using WebThing.Models;
using WebThing2.Interfaces;

namespace WebThing2.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        private static List<Movie> MovieList = new()
        {
            new Movie("A Series of Unfortunate Events", 2004, 4.0f),
            new Movie("Everything Everywhere All At Once", 2022, 4.5f, DateTime.Now ,"https://upload.wikimedia.org/wikipedia/en/1/1e/Everything_Everywhere_All_at_Once.jpg")
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
            index = MovieList.FindIndex(x =>x.ID == movie.ID);
            MovieList[index] = movie;
        }
    }
}
