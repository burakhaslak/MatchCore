using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.MatchDetailDtos;

namespace PremierLeague.WebUI.ViewComponents.MatchDetailComponents
{
    public class _MatchDetailFeatureComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _MatchDetailFeatureComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            if (ViewContext.RouteData.Values["id"] == null)
            {
                return View(new MatchDetailHeaderDto()); // ID yoksa boş model dön
            }

            int matchId = Convert.ToInt32(ViewContext.RouteData.Values["id"]);

            var match = _context.FootballMatches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.MatchStatistic)
                .FirstOrDefault(m => m.Id == matchId);

            if (match == null)
            {
                return View(new MatchDetailHeaderDto());
            }

            var model = new MatchDetailHeaderDto
            {
                MatchId = match.Id,
                WeekId = match.WeekId,
                Status = match.Status,
                Attendance = match.Attendance,

                HomeTeamName = match.HomeTeam.Name,
                HomeTeamLogo = match.HomeTeam.LogoUrl,
                AwayTeamName = match.AwayTeam.Name,
                AwayTeamLogo = match.AwayTeam.LogoUrl,

                Stadium = match.Stadium ?? match.HomeTeam.Stadium,
                MatchDate = match.MatchDate,
                Referee = match.Referee ?? "TBD",

                HomeScore = match.MatchStatistic != null ? match.MatchStatistic.HomeGoalsFirstHalf + match.MatchStatistic.HomeGoalsSecondHalf : 0,
                AwayScore = match.MatchStatistic != null ? match.MatchStatistic.AwayGoalsFirstHalf + match.MatchStatistic.AwayGoalsSecondHalf : 0,
                HomeScoreHT = match.MatchStatistic != null ? match.MatchStatistic.HomeGoalsFirstHalf : 0,
                AwayScoreHT = match.MatchStatistic != null ? match.MatchStatistic.AwayGoalsFirstHalf : 0
            };

            return View(model);
        }
    }
}
