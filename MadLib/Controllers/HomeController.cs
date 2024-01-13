using MadLib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MadLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MadLib(string noun, string adjective, string verb, string adjective2, string verb2, string adjective3, string verb3)
        {
            ViewBag.noun = noun;
            ViewBag.adjective = adjective;
            ViewBag.adjective2 = adjective2;
            ViewBag.adjective3 = adjective3;
            ViewBag.verb = verb;
            ViewBag.verb2 = verb2;
            ViewBag.verb3 = verb3;
               
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
