namespace PremierLeague.WebUI.Models
{
    public class MatchContentViewModel
    {
        public int MatchId { get; set; }
        public string SeasonName { get; set; }
        public int WeekId { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public int? Attendance { get; set; }
        public string Referee { get; set; }
        public DateTime MatchDate { get; set; }

        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }

        // İstatistikler (Eğer boşsa hata vermemesi için class olarak tutuyoruz)
        public EntityLayer.Entities.MatchStatistic Statistics { get; set; }

        // Maç Olayları Listesi
        public List<EntityLayer.Entities.MatchEvent> Events { get; set; } = new List<EntityLayer.Entities.MatchEvent>();
    }
}
