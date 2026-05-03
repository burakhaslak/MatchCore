using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.MatchDtos
{
    public class ResultMatchSummaryDto
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public string Status { get; set; }
        public string Referee { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeamLogo { get; set; }
        public string AwayTeamLogo { get; set; }
        public int HomeTotalGoals { get; set; }
        public int AwayTotalGoals { get; set; }
        public int HomePossession { get; set; }
        public int AwayPossession { get; set; }

        // İç içe geçmiş olaylar listesi
        public List<MatchEventItemDto> MatchEvents { get; set; }
    }
}
