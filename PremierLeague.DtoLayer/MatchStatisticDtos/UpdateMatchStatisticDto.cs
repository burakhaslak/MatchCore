using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.MatchStatisticDtos
{
    public class UpdateMatchStatisticDto
    {
        public int Id { get; set; }
        public int FootballMatchId { get; set; }

        public int HomeGoalsFirstHalf { get; set; }
        public int HomeGoalsSecondHalf { get; set; }
        public int AwayGoalsFirstHalf { get; set; }
        public int AwayGoalsSecondHalf { get; set; }

        public int HomePossession { get; set; }
        public int AwayPossession { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int AwayShotsOnTarget { get; set; }

        public int HomePasses { get; set; }
        public int AwayPasses { get; set; }
        public int HomePassAccuracy { get; set; }
        public int AwayPassAccuracy { get; set; }

        public int HomeCorners { get; set; }
        public int AwayCorners { get; set; }
        public int HomeFouls { get; set; }
        public int AwayFouls { get; set; }
        public int HomeOffsides { get; set; }
        public int AwayOffsides { get; set; }
        public int HomeYellowCards { get; set; }
        public int AwayYellowCards { get; set; }
        public int HomeRedCards { get; set; }
        public int AwayRedCards { get; set; }
    }
}
