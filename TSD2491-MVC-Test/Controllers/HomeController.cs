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

        [HttpPost]
        public IActionResult ButtonClick(string emoji, string uniqueDescription)
        {
            model.ButtonClick(emoji, uniqueDescription);
            
            return View("Index", model);
        }

        //TODO: If someone enters a previous name load it the score it got
        [HttpPost]
        public ActionResult SaveUsername()
        {
            model.Username = Request.Form["Username"];
            model.GamesPlayed = 0;
            model.CountGamesPlayed.Add(model.Username, model.GamesPlayed);
            
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
