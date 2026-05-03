using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
