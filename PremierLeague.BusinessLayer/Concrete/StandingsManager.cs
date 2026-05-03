using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DtoLayer.StandingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.BusinessLayer.Concrete
{
    public class StandingsManager : IStandingsService
    {
        private readonly IStandingsDal _standingsDal;

        public StandingsManager(IStandingsDal standingsDal)
        {
            _standingsDal = standingsDal;
        }

        public List<ResultStandingsDto> GetStandings()
        {
            return _standingsDal.GetStandings();
        }
    }
}
