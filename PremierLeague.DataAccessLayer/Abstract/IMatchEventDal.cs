using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DataAccessLayer.Abstract
{
    public interface IMatchEventDal : IGenericDal<MatchEvent>
    {
        Task<List<MatchEvent>> GetMatchEventsWithMatchInfoAsync();
    }
}
