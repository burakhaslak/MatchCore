using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.FootballMatchDtos
{
    public class ResultFootballMatchDto
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public string Status { get; set; }        // "NotStarted" | "InProgress" | "Finished"
        public string? FirstHalfScore { get; set; } // "1-1"
        public int? Attendance { get; set; }
        public string? Referee { get; set; }
        public bool IsFeatured { get; set; }

        //güncelleme
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeTeamLogo { get; set; }
        public string AwayTeamLogo { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
