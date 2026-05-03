using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.FixtureViewComponents
{
    public class _FixtureScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
