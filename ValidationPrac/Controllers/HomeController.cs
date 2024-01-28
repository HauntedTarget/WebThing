using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidationPrac.Models;

namespace ValidationPrac.Controllers
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

        public IActionResult Output()
        {
            //Validation code help at documentation here: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-8.0
            string name, street, city, state;
            int age;
            int zipcode;
            bool valid;

            if (ViewData["Name"] == null || ViewData["Age"] == null || ViewData["Street"] == null ||
                ViewData["City"] == null || ViewData["State"] == null || ViewData["Zipcode"] == null)
                valid = false;

            else valid = true;

            name = (string)(ViewData["Name"] ?? "");
            age = (int)(ViewData["Age"] ?? 0);
            street = (string)(ViewData["Street"] ?? "");
            city = (string)(ViewData["City"] ?? "");
            state = (string)(ViewData["State"] ?? "");
            zipcode = (int)(ViewData["ZipCode"] ?? 0);
            

            return View(new Validation(name,age,street,city,state,zipcode, valid));
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
    }
}
