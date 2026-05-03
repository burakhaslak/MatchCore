using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.FixtureDtos
{
    public class FixtureDayGroupDto
    {
        public DateTime Date { get; set; }
        public List<FixtureMatchItemDto> Matches { get; set; } = new List<FixtureMatchItemDto>();
    }
}
