using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameLibrary.Models;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;
using System.Collections.Generic;

namespace VideoGameLibrary.Controllers
{
    public class HomeController : Controller
    {
        IDataAccessLayer dal;
        public HomeController(IDataAccessLayer indal)
        {
            dal = indal;
        }

        public IActionResult GameSearch(string GameName)
        {
            List<Game> FoundGames = new();
            foreach (Game game in dal.GetGames())
            {
                if (game.GameTitle != null && game.GameTitle.ToLower().Contains(GameName.ToLower())) FoundGames.Add(game);
            }

            return View("Collection", FoundGames);
        }

        public IActionResult RemoveGame(int id)
        {
            if (dal.GetGame(id) != null) dal.RemoveGame(id);

            return RedirectToAction("Collection", "Home");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult EditGame(int id)
        {
            return View(dal.GetGame(id));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Collection(List<Game>? query)
        {
            if (query != null && query.Count > 0) return View(query);

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

            dal.UpdateGame(gameThing);

            return RedirectToAction("Collection", "Home");
        }

        public IActionResult OffLoan(int id)
        {
            Game gameThing = dal.GetGame(id);

            gameThing.LoanerName = null;
            gameThing.LoanDate = null;

            dal.UpdateGame(gameThing);

            return RedirectToAction("Collection", "Home");
        }

        public IActionResult GameEditConfirm(Game editedGame)
        {
            if (editedGame != null && ModelState.IsValid)
            {
                dal.UpdateGame(editedGame);
            }
            else
            {
                return RedirectToAction("Edit", "Home");
            }

            return RedirectToAction("Collection", "Home");
        }

        public IActionResult GameAddConfirm(Game newGame)
        {
            if (newGame != null && ModelState.IsValid)
            {
                dal.AddGame(newGame);
            }
            else
            {
                return RedirectToAction("Add", "Home");
            }

            return RedirectToAction("Collection", "Home");
        }
    }
}
