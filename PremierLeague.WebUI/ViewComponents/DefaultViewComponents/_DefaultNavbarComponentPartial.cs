using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
