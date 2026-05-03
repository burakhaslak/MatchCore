using Microsoft.EntityFrameworkCore;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DataAccessLayer.Repository;
using PremierLeague.DtoLayer.MatchDtos;
using PremierLeague.EntityLayer.Entities;
using System.Text.Json;

namespace PremierLeague.DataAccessLayer.EntityFramework
{
    public class EfFootballMatchDal : GenericRepository<FootballMatch>, IFootballMatchDal
    {
        private readonly Context _context;
        public EfFootballMatchDal(Context context) : base(context)
        {
            _context = context;
        }

        public ResultMatchSummaryDto GetMatchSummary(int matchId)
        {
            var jsonResult = _context.ResultJsonStrings.FromSqlInterpolated($"EXEC SP_GetMatchSummary {matchId}").AsEnumerable().FirstOrDefault();

            if (jsonResult != null && !string.IsNullOrEmpty(jsonResult.JsonSummary))
            {
                // SQL'den gelen metni C# DTO'suna çeviriyoruz
                return JsonSerializer.Deserialize<ResultMatchSummaryDto>(jsonResult.JsonSummary);
            }

            return null;
        }

        public async Task<List<FootballMatch>> GetFootballMatchesWithTeamsAsync()
        {
            return await _context.FootballMatches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .ToListAsync();
        }
    }
}
