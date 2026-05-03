namespace PremierLeague.EntityLayer.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string LogoUrl { get; set; }
        public int FoundedYear { get; set; }

        public List<FootballMatch> HomeMatches { get; set; }
        public List<FootballMatch> AwayMatches { get; set; }
    }
}
