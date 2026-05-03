using PremierLeague.DtoLayer.StandingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.BusinessLayer.Abstract
{
    public interface IStandingsService
    {
        List<ResultStandingsDto> GetStandings();
    }
}
