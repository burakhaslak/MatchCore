using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.EntityLayer.Entities;
using PremierLeague.WebUI.Models;

namespace PremierLeague.WebUI.ViewComponents.MatchDetailComponents
{
    public class _MatchDetailContentComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _MatchDetailContentComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            if (ViewContext.RouteData.Values["id"] == null)
                return View(new MatchContentViewModel());

            int matchId = Convert.ToInt32(ViewContext.RouteData.Values["id"]);

            var match = _context.FootballMatches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.MatchStatistic)
                .FirstOrDefault(m => m.Id == matchId);

            if (match == null) return View(new MatchContentViewModel());

            var matchEvents = _context.MatchEvents
                .Where(e => e.FootballMatchId == matchId)
                .OrderBy(e => e.Minute)
                .ToList();

            var activeSeason = _context.Seasons.FirstOrDefault(s => s.IsActive)?.Name ?? "2026 / 2027";

            var model = new MatchContentViewModel
            {
                MatchId = match.Id,
                SeasonName = activeSeason,
                WeekId = match.WeekId,
                Stadium = match.Stadium ?? match.HomeTeam.Stadium,
                City = match.HomeTeam.City ?? "Unknown Location",
                Attendance = match.Attendance,
                Referee = match.Referee ?? "TBD",
                MatchDate = match.MatchDate,
                HomeTeamName = match.HomeTeam.Name,
                AwayTeamName = match.AwayTeam.Name,
                Statistics = match.MatchStatistic ?? new MatchStatistic(),
                Events = matchEvents
            };

            return View(model);
        }
    }
}
