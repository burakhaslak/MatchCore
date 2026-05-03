using Microsoft.AspNetCore.Mvc;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.WebUI.Models;

namespace PremierLeague.WebUI.ViewComponents.StandingComponents
{
    public class _StandingPageHeaderComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _StandingPageHeaderComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var activeSeason = _context.Seasons.FirstOrDefault(s => s.IsActive == true);
            string currentSeasonName = activeSeason != null ? activeSeason.Name : "2026/2027";

            var upcomingMatch = _context.FootballMatches
                .Where(x => x.Status == "Not Played" || x.Status == "In Progress")
                .OrderBy(x => x.WeekId)
                .ThenBy(x => x.MatchDate)
                .FirstOrDefault();

            int currentWeek = upcomingMatch != null ? upcomingMatch.WeekId : 38;

            var model = new StandingsHeaderViewModel
            {
                SeasonName = currentSeasonName,
                ActiveWeek = currentWeek
            };

            return View(model);
        }
    }
}
