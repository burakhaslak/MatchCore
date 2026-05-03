using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.MatchDetailComponents
{
    public class _MatchDetailScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
