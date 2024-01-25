using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebThing.Models;

namespace WebThing.Controllers
{
    public class HomeController : Controller
    {
        private static int intCount = 0;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Past()
        {
            return View();
        }

        public IActionResult Future()
        {
            return View();
        }
        public IActionResult Counter()
        {
            ViewBag.Counter = intCount++;
            ViewData["Count"] = intCount;
            return View();
        }
        public IActionResult Input()
        {
            ViewData["Title"] = "Input Form";
            return View();
        }
        public IActionResult Output(string FirstName, string LastName)
        {
            ViewBag.FN = FirstName;
            ViewBag.LN = LastName;
            return View();
        }

        public IActionResult Google()
        {
            return Redirect("https://google.com");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
