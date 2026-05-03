using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.FixtureViewComponents
{
    public class _FixtureFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
