using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
