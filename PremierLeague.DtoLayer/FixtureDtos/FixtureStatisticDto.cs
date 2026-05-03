using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.FixtureDtos
{
    public class FixtureStatisticDto
    {
        public int TotalMatches { get; set; }
        public string StartDay { get; set; }   
        public string MonthYear { get; set; }  
    }
}
