using Microsoft.AspNetCore.Mvc;

namespace TSD2491_MVC_Test.Controllers
{
    public class MemoryController : Controller
    {
        public IActionResult Memory()
        {
            return View();
        }
    }
}
