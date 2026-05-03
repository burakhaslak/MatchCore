using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.StandingComponents
{
    public class _StandingFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
