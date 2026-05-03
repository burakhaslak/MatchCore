using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FixtureDtos;

namespace PremierLeague.WebUI.ViewComponents.FixtureViewComponents
{
    public class _FixtureDaysSummaryComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _FixtureDaysSummaryComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // 1. Aktif haftayı bul (Diğer componentlerle aynı mantık)
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

            // 2. O haftaya ait maçları takımlarıyla beraber çek
            var matches = _context.FootballMatches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => m.WeekId == currentWeek)
                .OrderBy(m => m.MatchDate)
                .ToList();

            // 3. MUCİZE BURADA: Maçları SADECE TARİH kısmına göre grupla (Saatleri yoksayarak)
            var groupedMatches = matches
                .GroupBy(m => m.MatchDate.Date)
                .Select(g => new FixtureDayGroupDto
                {
                    Date = g.Key, // O grubun günü (Örn: 18 Nisan)
                    Matches = g.Select(m => new FixtureMatchItemDto
                    {
                        Id = m.Id,
                        MatchDate = m.MatchDate,
                        HomeTeamName = m.HomeTeam.Name,
                        HomeTeamLogo = m.HomeTeam.LogoUrl,
                        AwayTeamName = m.AwayTeam.Name,
                        AwayTeamLogo = m.AwayTeam.LogoUrl,
                        Stadium = m.HomeTeam.Stadium ?? "Ev Sahibi Stadyumu" // Stadyum verin yoksa varsayılan
                    }).ToList()
                }).ToList();

            // Modeli sayfaya gönder
            return View(groupedMatches);
        }
    }
}
