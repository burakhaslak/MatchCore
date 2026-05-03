using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.FixtureDtos
{
    public class FixtureMatchItemDto
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLogo { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamLogo { get; set; }
        public string Stadium { get; set; }
    }
}
