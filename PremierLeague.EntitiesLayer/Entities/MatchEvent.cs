namespace PremierLeague.EntityLayer.Entities
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int FootballMatchId { get; set; }
        public string ActionType { get; set; }   // "Goal" | "YellowCard" | "RedCard" | "Substitution"
        public int Minute { get; set; }
        public bool IsHomeTeam { get; set; }
        public string? PlayerName { get; set; }  // Golü atan / kart gören
        public string? PlayerIn { get; set; }    // Değişiklikte giren
        public string? PlayerOut { get; set; }   // Değişiklikte çıkan
        public string? Description { get; set; } // Opsiyonel açıklama

        public FootballMatch FootballMatch { get; set; }
    }
}
