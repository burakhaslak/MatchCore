using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DtoLayer.SeasonDtos
{
    public class CreateSeasonDto
    {
        public string Name { get; set; }      
        public int StartYear { get; set; }     
        public int EndYear { get; set; }        
        public bool IsActive { get; set; }
    }
}
