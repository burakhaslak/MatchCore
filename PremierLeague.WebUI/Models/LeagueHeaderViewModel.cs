namespace PremierLeague.WebUI.Models
{
    public class LeagueHeaderViewModel
    {
        public int Week { get; set; }
        public string SeasonInfo { get; set; }
        public int TotalMatches { get; set; }
        public int FinishedCount { get; set; }
        public int UpcomingCount { get; set; }
        public int LiveCount { get; set; }
        public string DateRange { get; set; }
    }
}
