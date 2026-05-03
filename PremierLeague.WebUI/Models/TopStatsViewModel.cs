namespace PremierLeague.WebUI.Models
{
    public class TopStatsViewModel
    {
        public string LeaderShortName { get; set; } 
        public string LeaderName { get; set; }      
        public int LeaderPoints { get; set; }

        public string MostGoalsTeam { get; set; }
        public int MostGoalsValue { get; set; }

        public string FewestConcededTeam { get; set; }
        public int FewestConcededValue { get; set; }

        public string MotwText { get; set; }        
        public string MotwStadium { get; set; }
    }
}
