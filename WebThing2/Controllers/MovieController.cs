using Microsoft.AspNetCore.Mvc;
using WebThing.Models;
using WebThing2.Data;
using WebThing2.Interfaces;

namespace WebThing.Controllers
{
    public class MovieController : Controller
    {
        IDataAccessLayer dal = new MovieListDAL();

        public IActionResult DisplayMovie()
        {
            Movie m = dal.GetMovie(0);
            return View(m ?? null);
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        { 
            if (id == null)
            {
                ViewData["Error"] = "Movie ID not found";
                return View();
            }
            else
            {
                Movie? m = dal.GetMovie((int)id);
                if (m == null)
                {
                    ViewData["Error"] = "Movie under ID not found";
                }
                return View(m);
            }
        }

        public IActionResult MultMovies()
        {
            return View(dal.GetMovies());
        }

        public IActionResult OnLoan(int id, string loanerName)
        {
            Movie movieThing = dal.GetMovie(id);

            if (movieThing != null)
            {
                movieThing.LoanerName = loanerName;
                movieThing.ReleaseDate = DateTime.Now;
            }

            return RedirectToAction("MultMovies", "Movie");
        }

        public IActionResult OffLoan(int id)
        {
            Movie movieThing = dal.GetMovie(id);

            if (movieThing != null)
            {
                movieThing.LoanerName = null;
                movieThing.ReleaseDate = null;
            }

            return RedirectToAction("MultMovies", "Movie");
        }
    }
}
