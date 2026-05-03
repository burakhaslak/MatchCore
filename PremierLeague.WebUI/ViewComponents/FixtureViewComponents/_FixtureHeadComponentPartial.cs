using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.FixtureViewComponents
{
    public class _FixtureHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
