using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
