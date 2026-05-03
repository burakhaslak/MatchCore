using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.FixtureViewComponents
{
    public class _FixtureNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
