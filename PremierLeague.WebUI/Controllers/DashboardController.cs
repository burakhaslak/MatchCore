using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.StandingDto;
using PremierLeague.WebUI.Models;

namespace PremierLeague.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly Context _context;

        public DashboardController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel();

            model.TotalMatches = _context.FootballMatches.Count(m => m.Status == "Completed");
            model.ActiveTeams = _context.Teams.Count();
            model.TotalGoals = _context.MatchStatistics.Sum(s =>
     s.HomeGoalsFirstHalf + s.HomeGoalsSecondHalf +
     s.AwayGoalsFirstHalf + s.AwayGoalsSecondHalf);
            model.TotalRedCards = _context.MatchEvents.Count(e => e.ActionType == "Red Card");

            model.YellowCardsCount = _context.MatchEvents.Count(e => e.ActionType == "Yellow Card");
            model.RedCardsCount = model.TotalRedCards;

            var weeklyStats = _context.FootballMatches
                .Include(m => m.MatchStatistic)
                .Where(m => m.MatchStatistic != null)
                .AsEnumerable() 
                .GroupBy(m => m.WeekId)
                .OrderBy(g => g.Key)
                .Take(7) // Son 7 haftayı al
                .ToList();

            foreach (var week in weeklyStats)
            {
                model.WeeklyLabels.Add($"Week {week.Key}");
                int goalsThisWeek = week.Sum(m => m.MatchStatistic.HomeGoalsFirstHalf + m.MatchStatistic.HomeGoalsSecondHalf + m.MatchStatistic.AwayGoalsFirstHalf + m.MatchStatistic.AwayGoalsSecondHalf);
                model.WeeklyGoals.Add(goalsThisWeek);
            }

            model.RecentMatches = _context.FootballMatches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.MatchStatistic)
                .OrderByDescending(m => m.MatchDate)
                .Take(4)
                .ToList();

            var completedMatches = _context.FootballMatches.Include(m => m.MatchStatistic).Where(m => m.Status == "Completed" && m.MatchStatistic != null).ToList();
            var teamStats = _context.Teams.ToDictionary(t => t.Id, t => new TeamStandingDto { TeamId = t.Id, TeamName = t.Name });

            foreach (var match in completedMatches)
            {
                int hGoals = match.MatchStatistic.HomeGoalsFirstHalf + match.MatchStatistic.HomeGoalsSecondHalf;
                int aGoals = match.MatchStatistic.AwayGoalsFirstHalf + match.MatchStatistic.AwayGoalsSecondHalf;
                if (hGoals > aGoals) teamStats[match.HomeTeamId].Points += 3;
                else if (hGoals < aGoals) teamStats[match.AwayTeamId].Points += 3;
                else { teamStats[match.HomeTeamId].Points += 1; teamStats[match.AwayTeamId].Points += 1; }
            }

            model.Top5Teams = teamStats.Values.OrderByDescending(t => t.Points).Take(5).ToList();

            return View(model);
        }
    }
}
