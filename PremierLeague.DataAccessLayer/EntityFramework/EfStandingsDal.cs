using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.StandingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DataAccessLayer.EntityFramework
{
    public class EfStandingsDal : IStandingsDal
    {
        private readonly Context _context;

        public EfStandingsDal(Context context)
        {
            _context = context;
        }

        public List<ResultStandingsDto> GetStandings()
        {
            return _context.ResultStandings.FromSqlRaw("EXEC SP_CalculateStandings").ToList();
        }
    }
}
