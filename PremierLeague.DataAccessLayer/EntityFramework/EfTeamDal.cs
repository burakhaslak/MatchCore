using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DataAccessLayer.Repository;
using PremierLeague.DtoLayer.TeamDtos;
using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DataAccessLayer.EntityFramework
{
    public class EfTeamDal : GenericRepository<Team>, ITeamDal
    {
        private readonly Context _context;
        public EfTeamDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<ResultTeamFormDto> GetTeamLastFiveMatches(int teamId)
        {
            return _context.ResultTeamForms.FromSqlInterpolated($"EXEC SP_GetTeamLastFiveMatches {teamId}").ToList();
        }
    }
}
