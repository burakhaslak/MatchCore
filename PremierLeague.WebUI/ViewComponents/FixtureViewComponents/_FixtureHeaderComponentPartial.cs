using Microsoft.AspNetCore.Mvc;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FixtureDtos;

namespace PremierLeague.WebUI.ViewComponents.FixtureViewComponents
{
    public class _FixtureHeaderComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _FixtureHeaderComponentPartial(Context context)
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

            var weekInfo = _context.Weeks.FirstOrDefault(w => w.Id == currentWeek);

            var nextGlobalMatch = _context.FootballMatches
                .Where(x => x.Status == "Not Played" && x.MatchDate > DateTime.Now)
                .OrderBy(x => x.MatchDate)
                .FirstOrDefault();

            var model = new FixturePageDto
            {
                ActiveWeek = currentWeek,

                WeekStartDate = weekInfo != null ? weekInfo.StartDate : DateTime.Now,
                WeekEndDate = weekInfo != null ? weekInfo.EndDate : DateTime.Now,

                TotalMatchesInWeek = thisWeekMatches.Count,
                TotalWeeksInSeason = _context.FootballMatches.Any() ? _context.FootballMatches.Max(x => x.WeekId) : 1,

                NextMatchDateIso = nextGlobalMatch != null
                        ? nextGlobalMatch.MatchDate.ToString("yyyy-MM-ddTHH:mm:ss")
                        : null
            };

            return View(model);
        }
    }
}
