using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.WebUI.Models;

namespace PremierLeague.WebUI.ViewComponents.StandingComponents
{
    public class _StandingTopStatisticComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _StandingTopStatisticComponentPartial(Context context)
        {
            _context = context;
        }

        private class TeamStatTracker
        {
            public string Name { get; set; }
            public string ShortName { get; set; }
            public int Points { get; set; }
            public int Scored { get; set; }
            public int Conceded { get; set; }
            public int PlayedMatches { get; set; }
        }

        public IViewComponentResult Invoke()
        {
            var allTeams = _context.Teams.ToList();
            var completedMatches = _context.FootballMatches
                .Include(m => m.MatchStatistic)
                .Where(m => m.Status == "Completed" && m.MatchStatistic != null)
                .ToList();

            var teamStats = allTeams.ToDictionary(t => t.Id, t => new TeamStatTracker
            {
                Name = t.Name,
                ShortName = !string.IsNullOrEmpty(t.ShortName) ? t.ShortName : (t.Name.Length >= 3 ? t.Name.Substring(0, 3).ToUpper() : t.Name.ToUpper()),
                Points = 0,
                Scored = 0,
                Conceded = 0,
                PlayedMatches = 0
            });

            foreach (var match in completedMatches)
            {
                int homeGoals = match.MatchStatistic.HomeGoalsFirstHalf + match.MatchStatistic.HomeGoalsSecondHalf;
                int awayGoals = match.MatchStatistic.AwayGoalsFirstHalf + match.MatchStatistic.AwayGoalsSecondHalf;

                if (teamStats.ContainsKey(match.HomeTeamId))
                {
                    var homeTeam = teamStats[match.HomeTeamId];
                    homeTeam.PlayedMatches++;
                    homeTeam.Scored += homeGoals;
                    homeTeam.Conceded += awayGoals;

                    if (homeGoals > awayGoals) homeTeam.Points += 3;
                    else if (homeGoals == awayGoals) homeTeam.Points += 1;
                }

                if (teamStats.ContainsKey(match.AwayTeamId))
                {
                    var awayTeam = teamStats[match.AwayTeamId];
                    awayTeam.PlayedMatches++;
                    awayTeam.Scored += awayGoals;
                    awayTeam.Conceded += homeGoals;

                    if (awayGoals > homeGoals) awayTeam.Points += 3;
                    else if (awayGoals == homeGoals) awayTeam.Points += 1;
                }
            }

            var statsList = teamStats.Values.ToList();

            var leader = statsList
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => (x.Scored - x.Conceded)) // Puan eşitse averaja bak
                .FirstOrDefault();

            var mostGoalsTeam = statsList.OrderByDescending(x => x.Scored).FirstOrDefault();

            var fewestConcededTeam = statsList.Where(x => x.PlayedMatches > 0).OrderBy(x => x.Conceded).FirstOrDefault();

            var motw = _context.FootballMatches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.MatchStatistic)
                .Where(m => m.Status == "Completed" && m.MatchStatistic != null)
                .OrderByDescending(m => m.MatchDate)
                .FirstOrDefault();

            var model = new TopStatsViewModel
            {
                LeaderShortName = leader?.ShortName ?? "N/A",
                LeaderName = leader?.Name ?? "Unknown",
                LeaderPoints = leader?.Points ?? 0,

                MostGoalsTeam = mostGoalsTeam?.Name ?? "Unknown",
                MostGoalsValue = mostGoalsTeam?.Scored ?? 0,

                FewestConcededTeam = fewestConcededTeam?.Name ?? "Unknown",
                FewestConcededValue = fewestConcededTeam?.Conceded ?? 0,

                MotwText = motw != null
                    ? $"{(motw.HomeTeam.ShortName ?? motw.HomeTeam.Name.Substring(0, 3).ToUpper())} {motw.MatchStatistic.HomeGoalsFirstHalf + motw.MatchStatistic.HomeGoalsSecondHalf} - {motw.MatchStatistic.AwayGoalsFirstHalf + motw.MatchStatistic.AwayGoalsSecondHalf} {(motw.AwayTeam.ShortName ?? motw.AwayTeam.Name.Substring(0, 3).ToUpper())}"
                    : "No Match Yet",
                MotwStadium = motw != null && motw.HomeTeam != null ? motw.HomeTeam.Stadium : "Unknown Stadium"
            };

            return View(model);
        }
    }
}
