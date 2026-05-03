using PremierLeague.DtoLayer.StandingDto;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.WebUI.Models
{
    public class DashboardViewModel
    {
        public int TotalMatches { get; set; }
        public int TotalGoals { get; set; }
        public int TotalRedCards { get; set; }
        public int ActiveTeams { get; set; }

        // Bar Chart (Haftalık Goller)
        public List<string> WeeklyLabels { get; set; } = new List<string>();
        public List<int> WeeklyGoals { get; set; } = new List<int>();

        // Doughnut Chart (Kart Dağılımı)
        public int YellowCardsCount { get; set; }
        public int RedCardsCount { get; set; }

        // Alt Tablolar
        public List<FootballMatch> RecentMatches { get; set; }
        public List<TeamStandingDto> Top5Teams { get; set; }
    }
}
