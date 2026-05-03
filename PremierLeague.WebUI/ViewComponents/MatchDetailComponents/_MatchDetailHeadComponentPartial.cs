using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.MatchDetailComponents
{
    public class _MatchDetailHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
