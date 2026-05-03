using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FootballMatchDtos;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLiveComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _DefaultLiveComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var liveMatches = _context.FootballMatches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Include(x => x.MatchStatistic)
                .Where(x => x.Status == "In Progress")
                .OrderBy(x => x.MatchDate) 
                .ToList();

            var dtoList = liveMatches.Select(m => new ResultFootballMatchDto
            {
                Id = m.Id,
                HomeTeamName = m.HomeTeam.Name,
                HomeTeamLogo = m.HomeTeam.LogoUrl,
                AwayTeamName = m.AwayTeam.Name,
                AwayTeamLogo = m.AwayTeam.LogoUrl,
                MatchDate = m.MatchDate,

                HomeScore = m.MatchStatistic != null ?
                            (m.MatchStatistic.HomeGoalsFirstHalf + m.MatchStatistic.HomeGoalsSecondHalf) : 0,

                AwayScore = m.MatchStatistic != null ?
                            (m.MatchStatistic.AwayGoalsFirstHalf + m.MatchStatistic.AwayGoalsSecondHalf) : 0
            }).ToList();

            return View(dtoList);
        }
    }
}
