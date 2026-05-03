using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.TeamDtos
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string LogoUrl { get; set; }
        public int FoundedYear { get; set; }
    }
}
