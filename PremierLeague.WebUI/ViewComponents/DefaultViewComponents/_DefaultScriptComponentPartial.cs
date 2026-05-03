using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
              return View();
        }
    }
}
