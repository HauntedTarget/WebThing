using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameLibrary.Models;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Controllers
{
    public class HomeController : Controller
    {
        IDataAccessLayer dal;

        public HomeController(IDataAccessLayer inDal)
        {
            dal = inDal;
        }

        public IActionResult RemoveGame(int id)
        {
            if (dal.GetGame(id) != null) dal.RemoveGame(id);

            return RedirectToAction("Collection", "Home");
        }

        public IActionResult EditGame(int id)
        {
            return View();
        }

            public IActionResult Index()
        {
            return View();
        }

        public IActionResult Collection()
        {
            return View(dal.GetGames());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OnLoan(int id, string loanerName)
        {
            Game gameThing = dal.GetGame(id);

            gameThing.LoanerName = loanerName;
            gameThing.LoanDate = DateTime.Now;

            return RedirectToAction("Collection", "Home");
        }

        public IActionResult OffLoan(int id)
        {
            Game movieThing = dal.GetGame(id);

            movieThing.LoanerName = null;
            movieThing.LoanDate = null;

            return RedirectToAction("Collection", "Home");
        }
    }
}
