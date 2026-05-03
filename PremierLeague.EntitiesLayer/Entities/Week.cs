namespace PremierLeague.EntityLayer.Entities
{
    public class Week
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }       // 34
        public DateTime StartDate { get; set; }   // 18 Nisan 2025
        public DateTime EndDate { get; set; }     // 20 Nisan 2025

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public List<FootballMatch> Matches { get; set; }
    }
}
