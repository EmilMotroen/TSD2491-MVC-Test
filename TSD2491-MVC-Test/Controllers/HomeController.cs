using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_MVC_Test.Models;

namespace TSD2491_MVC_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly static MatchingGameModel model = new MatchingGameModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(model);
        }

        public IActionResult ShuffleAnimals()
        {
            return View(model.SetupGame());
        }


        [HttpPost]
        public IActionResult ButtonClick(string emoji, string uniqueDescription)
        {
            model.ButtonClick(emoji, uniqueDescription);
            
            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public ActionResult SaveUsername()
        {
            model.Username = Request.Form["Username"];
            return View("Index", model);
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
