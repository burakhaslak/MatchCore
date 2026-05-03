using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.Controllers
{
    public class FixtureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
