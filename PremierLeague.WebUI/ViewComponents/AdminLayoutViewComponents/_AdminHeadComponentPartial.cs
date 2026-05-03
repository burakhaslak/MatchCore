using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
