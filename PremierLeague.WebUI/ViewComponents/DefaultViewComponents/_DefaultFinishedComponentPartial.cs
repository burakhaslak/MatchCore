using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FootballMatchDtos;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFinishedComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _DefaultFinishedComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var finishedMatches = _context.FootballMatches
         .Include(x => x.HomeTeam)
         .Include(x => x.AwayTeam)
         .Include(x => x.MatchStatistic) // Skorları çekmek için
         .Where(x => x.Status == "Completed")
         .OrderByDescending(x => x.MatchDate) // Tarihi en yeni olan en üstte
         .Take(10) 
         .ToList();

            var dtoList = finishedMatches.Select(m => new ResultFootballMatchDto
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
