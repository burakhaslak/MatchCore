using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.DefaultDtos;
using PremierLeague.WebUI.Models;

namespace PremierLeague.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLeagueHeaderComponentPartial : ViewComponent
    {
        private readonly Context _context;

        public _DefaultLeagueHeaderComponentPartial(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var activeMatch = _context.FootballMatches
                 .Where(m => m.Status == "In Progress" || m.Status == "Not Played")
                 .OrderBy(m => m.WeekId)    
                 .ThenBy(m => m.MatchDate)  
                 .FirstOrDefault();

            int currentWeekId = activeMatch != null ? activeMatch.WeekId : 38;

            var currentWeek = _context.Weeks.FirstOrDefault(w => w.Id == currentWeekId);
            var weekMatches = _context.FootballMatches.Where(m => m.WeekId == currentWeekId).ToList();

            string dateRangeStr = "Maç Takvimi Belirsiz";
            if (currentWeek != null)
            {
                string start = currentWeek.StartDate.ToString("dd MMMM");
                string end = currentWeek.EndDate.ToString("dd MMMM yyyy");
                dateRangeStr = $"{start} - {end}";
            }

            var model = new LeagueHeaderViewModel
            {
                Week = currentWeek?.WeekNumber ?? 1,
                DateRange = dateRangeStr,
                TotalMatches = weekMatches.Count,

                LiveCount = weekMatches.Count(m => m.Status == "In Progress"),
                FinishedCount = weekMatches.Count(m => m.Status == "Completed"),
                UpcomingCount = weekMatches.Count(m => m.Status == "Not Played")
            };

            return View(model);
        }
    }
}
