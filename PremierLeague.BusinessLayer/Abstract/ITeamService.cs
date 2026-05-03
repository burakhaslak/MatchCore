using PremierLeague.DtoLayer.TeamDtos;

namespace PremierLeague.BusinessLayer.Abstract
{
    public interface ITeamService
    {
        Task<List<ResultTeamDto>> TGetListWithDtoAsync();
        Task<GetTeamByIdDto> TGetByIdWithDtoAsync(int id);
        Task TInsertWithDtoAsync(CreateTeamDto dto);
        Task TUpdateWithDtoAsync(UpdateTeamDto dto);
        Task TDeleteWithDtoAsync(int id);

        List<ResultTeamFormDto> GetTeamLastFiveMatches(int teamId);
    }
}
