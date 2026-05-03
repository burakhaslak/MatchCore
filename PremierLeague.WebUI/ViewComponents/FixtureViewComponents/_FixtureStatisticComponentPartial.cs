using Microsoft.AspNetCore.Mvc;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FixtureDtos;

namespace PremierLeague.WebUI.ViewComponents.FixtureViewComponents
{
    public class _FixtureStatisticComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _FixtureStatisticComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            int currentWeek = 1;

            if (int.TryParse(HttpContext.Request.Query["weekId"], out int qsWeek))
            {
                currentWeek = qsWeek;
            }
            else
            {
                var upcomingMatch = _context.FootballMatches
                 .Where(x => x.Status == "Not Played")
                 .OrderBy(x => x.WeekId)
                 .ThenBy(x => x.MatchDate)
                 .FirstOrDefault();

                currentWeek = upcomingMatch != null ? upcomingMatch.WeekId : 1;
            }

            var thisWeekMatches = _context.FootballMatches
                .Where(x => x.WeekId == currentWeek)
                .ToList();

            var startDate = thisWeekMatches.Any()
                            ? thisWeekMatches.Min(x => x.MatchDate)
                            : DateTime.Now;

            var model = new FixtureStatisticDto
            {
                TotalMatches = thisWeekMatches.Count,
                StartDay = startDate.ToString("dd"),         
                MonthYear = startDate.ToString("MMMM yyyy") 
            };

            return View(model);
        }
    }
}
