using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.MatchDetailDtos
{
    public class MatchDetailHeaderDto
    {
        public int MatchId { get; set; }
        public int WeekId { get; set; }
        public string Status { get; set; }
        public int? Attendance { get; set; }

        public string HomeTeamName { get; set; }
        public string HomeTeamLogo { get; set; }
        public int HomeScore { get; set; }
        public int HomeScoreHT { get; set; } // İlk Yarı Skoru

        public string AwayTeamName { get; set; }
        public string AwayTeamLogo { get; set; }
        public int AwayScore { get; set; }
        public int AwayScoreHT { get; set; } // İlk Yarı Skoru

        public string Stadium { get; set; }
        public DateTime MatchDate { get; set; }
        public string Referee { get; set; }
    }
}
