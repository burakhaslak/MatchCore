using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.StandingDto;

namespace PremierLeague.WebUI.ViewComponents.StandingComponents
{
    public class _StandingTableComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _StandingTableComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var allTeams = _context.Teams.ToList();
            var standings = allTeams.ToDictionary(t => t.Id, t => new TeamStandingDto
            {
                TeamId = t.Id,
                TeamName = t.Name,
                LogoUrl = t.LogoUrl
            });

            var completedMatches = _context.FootballMatches
                .Include(m => m.MatchStatistic)
                .Where(m => m.Status == "Completed" && m.MatchStatistic != null)
                .OrderBy(m => m.MatchDate) 
                .ToList();

            foreach (var match in completedMatches)
            {
                var hGoals = match.MatchStatistic.HomeGoalsFirstHalf + match.MatchStatistic.HomeGoalsSecondHalf;
                var aGoals = match.MatchStatistic.AwayGoalsFirstHalf + match.MatchStatistic.AwayGoalsSecondHalf;

                var homeTeam = standings[match.HomeTeamId];
                var awayTeam = standings[match.AwayTeamId];

                homeTeam.Played++;
                awayTeam.Played++;
                homeTeam.GoalsFor += hGoals;
                homeTeam.GoalsAgainst += aGoals;
                awayTeam.GoalsFor += aGoals;
                awayTeam.GoalsAgainst += hGoals;

                if (hGoals > aGoals)
                {
                    homeTeam.Won++; homeTeam.Points += 3;
                    awayTeam.Lost++;
                }
                else if (hGoals < aGoals)
                {
                    awayTeam.Won++; awayTeam.Points += 3;
                    homeTeam.Lost++;
                }
                else
                {
                    homeTeam.Drawn++; homeTeam.Points += 1;
                    awayTeam.Drawn++; awayTeam.Points += 1;
                }
            }

            foreach (var team in standings.Values)
            {
                var last5Matches = completedMatches
                    .Where(m => m.HomeTeamId == team.TeamId || m.AwayTeamId == team.TeamId)
                    .OrderByDescending(m => m.MatchDate)
                    .Take(5)
                    .ToList();

                last5Matches.Reverse();

                foreach (var m in last5Matches)
                {
                    var hGoals = m.MatchStatistic.HomeGoalsFirstHalf + m.MatchStatistic.HomeGoalsSecondHalf;
                    var aGoals = m.MatchStatistic.AwayGoalsFirstHalf + m.MatchStatistic.AwayGoalsSecondHalf;

                    if (m.HomeTeamId == team.TeamId)
                    {
                        team.Form.Add(hGoals > aGoals ? "W" : hGoals < aGoals ? "L" : "D");
                    }
                    else
                    {
                        team.Form.Add(aGoals > hGoals ? "W" : aGoals < hGoals ? "L" : "D");
                    }
                }
            }

            var sortedStandings = standings.Values
                .OrderByDescending(t => t.Points)         
                .ThenByDescending(t => t.GoalDifference)  
                .ThenByDescending(t => t.GoalsFor)        
                .ToList();

            int rank = 1;
            foreach (var team in sortedStandings)
            {
                team.Rank = rank++;
            }

            return View(sortedStandings);
        }
    }
}
