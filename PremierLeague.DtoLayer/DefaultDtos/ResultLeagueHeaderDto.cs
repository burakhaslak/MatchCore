using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.DefaultDtos
{
    public class ResultLeagueHeaderDto
    {
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalMatches { get; set; }
        public int LiveMatches { get; set; }
        public int FinishedMatches { get; set; }
        public int UpcomingMatches { get; set; }
    }
}
