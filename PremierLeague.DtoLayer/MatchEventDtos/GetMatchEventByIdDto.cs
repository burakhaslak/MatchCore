using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.MatchEventDtos
{
    public class GetMatchEventByIdDto
    {
        public int Id { get; set; }
        public int FootballMatchId { get; set; }
        public string ActionType { get; set; }
        public int Minute { get; set; }
        public bool IsHomeTeam { get; set; }
        public string? PlayerName { get; set; }
        public string? PlayerIn { get; set; }
        public string? PlayerOut { get; set; }
        public string? Description { get; set; }
    }
}
