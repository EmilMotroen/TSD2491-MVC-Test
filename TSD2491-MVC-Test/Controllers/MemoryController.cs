using Microsoft.AspNetCore.Mvc;
using TSD2491_MVC_Test.Models;

namespace TSD2491_MVC_Test.Controllers
{
    public class MemoryController : Controller
    {
        private readonly static MemoryGameModel model = new MemoryGameModel();
        public IActionResult Memory()
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult ButtonClick(string emoji, string uniqueDescription)
        {
            model.ButtonClick(emoji, uniqueDescription);

            return View("Memory", model);
        }
    }
}
