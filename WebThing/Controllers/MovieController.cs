using Microsoft.AspNetCore.Mvc;
using WebThing.Models;

namespace WebThing.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> MovieList = new()
        {
            new Movie("A Series of Unfortunate Events", 2004, 4.0f),
            new Movie("Everything Everywhere All At Once", 2022, 4.5f, DateTime.Now ,"https://upload.wikimedia.org/wikipedia/en/1/1e/Everything_Everywhere_All_at_Once.jpg")
        };

        public IActionResult DisplayMovie()
        {
            Movie m = MovieList[0];
            return View(m);
        }

        public IActionResult MultMovies()
        {
            return View(MovieList);
        }
    }
}
