namespace PremierLeague.EntityLayer.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }        // "2024/2025"
        public int StartYear { get; set; }      // 2024
        public int EndYear { get; set; }        // 2025
        public bool IsActive { get; set; }      // Güncel sezon mu?

        public List<Week> Weeks { get; set; }
    }
}
