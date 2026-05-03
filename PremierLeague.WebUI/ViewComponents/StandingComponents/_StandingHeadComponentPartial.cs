using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.StandingComponents
{
    public class _StandingHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
