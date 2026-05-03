using PremierLeague.DtoLayer.MatchDtos;
using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DataAccessLayer.Abstract
{
    public interface IFootballMatchDal : IGenericDal<FootballMatch>
    {
        ResultMatchSummaryDto GetMatchSummary(int matchId);
        Task<List<FootballMatch>> GetFootballMatchesWithTeamsAsync();
    }
}
