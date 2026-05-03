namespace PremierLeague.EntityLayer.Entities
{
    public class FootballMatch
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public string? Stadium { get; set; }
        public string Status { get; set; }        // "NotStarted" | "InProgress" | "Finished"
        public int? Attendance { get; set; }
        public string? Referee { get; set; }
        public bool IsFeatured { get; set; }

        public Week Week { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public MatchStatistic MatchStatistic { get; set; }
        public List<MatchEvent> Events { get; set; }
    }
}
