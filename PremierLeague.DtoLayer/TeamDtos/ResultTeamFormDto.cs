using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.TeamDtos
{
    public class ResultTeamFormDto
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public string OpponentName { get; set; }
        public string HomeOrAway { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public string MatchResult { get; set; }
    }
}
