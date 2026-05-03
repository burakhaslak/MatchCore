using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DataAccessLayer.Repository;
using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DataAccessLayer.EntityFramework
{
    public class EfMatchEventDal : GenericRepository<MatchEvent>, IMatchEventDal
    {
        private readonly Context _context;

        public EfMatchEventDal(Context context) : base(context)
        {
            _context = context;

        }

        public async Task<List<MatchEvent>> GetMatchEventsWithMatchInfoAsync()
        {
            return await _context.MatchEvents
                .Include(x => x.FootballMatch)          
                    .ThenInclude(y => y.HomeTeam)       
                .Include(x => x.FootballMatch)         
                    .ThenInclude(y => y.AwayTeam)        
                .ToListAsync();
        }
    }
}
