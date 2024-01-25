using WebThing.Models;

namespace WebThing2.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Movie> GetMovies();

        void AddMovie(Movie movie);
        void RemoveMovie(int id);
        Movie? GetMovie(int id);
    }
}
