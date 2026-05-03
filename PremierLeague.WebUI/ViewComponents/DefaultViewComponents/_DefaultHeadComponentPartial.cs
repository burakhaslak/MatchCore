using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
