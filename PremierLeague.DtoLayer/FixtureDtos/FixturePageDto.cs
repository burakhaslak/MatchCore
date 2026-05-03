using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.FixtureDtos
{
    public class FixturePageDto
    {
        public int ActiveWeek { get; set; }
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekEndDate { get; set; }
        public int TotalMatchesInWeek { get; set; }
        public int TotalWeeksInSeason { get; set; }

        // JavaScript'e geri sayım için göndereceğimiz ISO formatındaki tarih
        public string NextMatchDateIso { get; set; }
    }
}
