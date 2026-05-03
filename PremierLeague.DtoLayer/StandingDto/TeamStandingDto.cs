using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.StandingDto
{
    public class TeamStandingDto
    {
        public int Rank { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string LogoUrl { get; set; }

        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }    // Atılan Gol (GF)
        public int GoalsAgainst { get; set; } // Yenilen Gol (GA)

        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Points { get; set; }

        // Son 5 maçın "W", "D", "L" bilgisi
        public List<string> Form { get; set; } = new List<string>();
    }
}
