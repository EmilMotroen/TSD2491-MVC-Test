using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_MVC_Test.Models;

namespace TSD2491_MVC_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        static MatchingGameModel model = new MatchingGameModel();

        public IActionResult Index()
        {
            var model = new MatchingGameModel()
            {
                ShuffledAnimals = GetShuffledAnimals(),
                MatchesFound = GetMatchesFound(),
                TimeDisplay = GetTimeDisplay()
            };

            return View(model);
        }

        public List<string> GetShuffledAnimals()
        {
            return model.GetShuffledAnimals();
        }

        public IActionResult ShuffleAnimals()
        {
            return View(model.SetupGame());
        }

        public int GetMatchesFound()
        {
            return model.MatchesFound;
        }

        public int GetTimeDisplay()
        {
            return model.TimeDisplay;
        }

        [HttpPost]
        public IActionResult ButtonClick(string animal, string uniqueDescription)
        {
            model.MatchesFound++;
            //model.ButtonClick(animal, uniqueDescription);
            
            return RedirectToAction("Index", model);


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
