using PremierLeague.DtoLayer.FootballMatchDtos;
using PremierLeague.DtoLayer.MatchDtos;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.BusinessLayer.Abstract
{
    public interface IFootballMatchService
    {
        Task<List<ResultFootballMatchDto>> TGetListWithDtoAsync();
        Task<GetFootballMatchByIdDto> TGetByIdWithDtoAsync(int id);
        Task TInsertWithDtoAsync(CreateFootballMatchDto dto);
        Task TUpdateWithDtoAsync(UpdateFootballMatchDto dto);
        Task TDeleteWithDtoAsync(int id);
        ResultMatchSummaryDto GetMatchSummary(int matchId);
    }
}
