using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<Game> GameLibrary = new()
        {
            new Game("God of War: Ragnarok", Game.Platform.Playstation, "Action", 2022, "M", "https://assets-prd.ignimgs.com/2021/09/09/god-of-war-ragnarok-button-1631231879154.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2"),
            new Game("Halo Infinite", Game.Platform.XBox, "FPS", 2001, "M", "https://oyster.ignimgs.com/wordpress/stg.ign.com/2020/07/halo_infinite_keyart_primary_vertical-748a0db8be6c497d86f83ad76265060f-720x915.png?fit=bounds&width=1280&height=720&dpr=2"),
            new Game("Super Mario Galaxy", Game.Platform.Nintendo, "3rd Person Platformer", 2007, "E", "https://assets-prd.ignimgs.com/2020/09/04/super-mario-galaxy-1-button-1599258841533.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2"),
            new Game("Portal 2", Game.Platform.Steam, "Puzzle", 2011, "E 10+", "https://assets-prd.ignimgs.com/2021/12/08/portal2-1638924084230.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2"),
            new Game("Fortnite", Game.Platform.Epic, "Battle Royale", 2017, "T", "https://assets-prd.ignimgs.com/2023/06/09/fortnitewilds-1686353306240.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2")
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Collection()
        {
            return View(GameLibrary);
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
            Game movieThing = GameLibrary[id];

            movieThing.LoanerName = loanerName;
            movieThing.LoanDate = DateTime.Now;

            return RedirectToAction("Collection", "Home");
        }

        public IActionResult OffLoan(int id)
        {
            Game movieThing = GameLibrary[id];

            movieThing.LoanerName = null;
            movieThing.LoanDate = null;

            return RedirectToAction("Collection", "Home");
        }
    }
}
