using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.StandingComponents
{
    public class _StandingNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
