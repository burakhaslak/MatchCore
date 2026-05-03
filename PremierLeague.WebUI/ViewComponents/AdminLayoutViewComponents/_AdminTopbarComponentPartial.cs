using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminTopbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
