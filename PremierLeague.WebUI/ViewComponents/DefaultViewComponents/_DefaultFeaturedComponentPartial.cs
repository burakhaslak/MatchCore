using Microsoft.AspNetCore.Mvc;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FootballMatchDtos;
using Microsoft.EntityFrameworkCore;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeaturedComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _DefaultFeaturedComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // IsFeatured = true olan en güncel maçı buluyoruz.
            var featuredMatch = _context.FootballMatches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Include(x => x.MatchStatistic) // İstatistikleri de dahil ettik
                .Where(x => x.IsFeatured == true)
                .OrderByDescending(x => x.MatchDate)
                .FirstOrDefault();

            // Eğer öne çıkan bir maç yoksa, View'a null gönderiyoruz.
            if (featuredMatch == null)
            {
                return View(null);
            }

            // --- İŞTE EKSİK OLAN VE EKLENEN TOPLAMA İŞLEMİ BURASI ---
            int totalHomeScore = 0;
            int totalAwayScore = 0;

            if (featuredMatch.MatchStatistic != null)
            {
                // Kolonlar int olduğu için doğrudan toplayabiliriz
                totalHomeScore = featuredMatch.MatchStatistic.HomeGoalsFirstHalf +
                                 featuredMatch.MatchStatistic.HomeGoalsSecondHalf;

                totalAwayScore = featuredMatch.MatchStatistic.AwayGoalsFirstHalf +
                                 featuredMatch.MatchStatistic.AwayGoalsSecondHalf;
            }
            // ---------------------------------------------------------

            // Gelen veriyi DTO'ya mapliyoruz.
            var model = new ResultFootballMatchDto
            {
                Id = featuredMatch.Id,
                HomeTeamName = featuredMatch.HomeTeam.Name,
                HomeTeamLogo = featuredMatch.HomeTeam.LogoUrl,
                AwayTeamName = featuredMatch.AwayTeam.Name,
                AwayTeamLogo = featuredMatch.AwayTeam.LogoUrl,
                MatchDate = featuredMatch.MatchDate,
                Stadium = featuredMatch.Stadium,
                Status = featuredMatch.Status,
                FirstHalfScore = featuredMatch.MatchStatistic != null
        ? $"{featuredMatch.MatchStatistic.HomeGoalsFirstHalf}-{featuredMatch.MatchStatistic.AwayGoalsFirstHalf}"
        : "0-0",
                // Ve hesapladığımız bu skorları artık DTO'ya sorunsuzca verebiliriz!
                HomeScore = totalHomeScore,
                AwayScore = totalAwayScore
            };

            return View(model);
        }
    }
}
