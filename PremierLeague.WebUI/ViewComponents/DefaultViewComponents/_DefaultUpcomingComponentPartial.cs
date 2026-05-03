using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FootballMatchDtos;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultUpcomingComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _DefaultUpcomingComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            // 1. Önce aktif haftayı (currentWeekId) buluyoruz (Header ile aynı mantık)
            var activeMatch = _context.FootballMatches
                .Where(m => m.Status == "In Progress" || m.Status == "Not Played")
                .OrderBy(m => m.WeekId)
                .ThenBy(m => m.MatchDate)
                .FirstOrDefault();

            int currentWeekId = activeMatch != null ? activeMatch.WeekId : 38;

            // 2. YALNIZCA o haftaya ait olan "Not Played" maçları çekiyoruz
            var upcomingMatches = _context.FootballMatches
         .Include(x => x.HomeTeam)
         .Include(x => x.AwayTeam)
         .Where(x => x.Status == "Not Played")
         .OrderBy(x => x.MatchDate) // Yaklaşan maçlar sırasıyla
         .Take(10) // <-- İŞTE ANASAYFAYI KURTARAN KOD
         .ToList();

            var dtoList = upcomingMatches.Select(m => new ResultFootballMatchDto
            {
                Id = m.Id,
                HomeTeamName = m.HomeTeam.Name,
                HomeTeamLogo = m.HomeTeam.LogoUrl,
                AwayTeamName = m.AwayTeam.Name,
                AwayTeamLogo = m.AwayTeam.LogoUrl,
                MatchDate = m.MatchDate,

                HomeScore = 0,
                AwayScore = 0
            }).ToList();

            return View(dtoList);
        }
    }
}
