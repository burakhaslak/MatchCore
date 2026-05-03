using PremierLeague.DtoLayer.MatchStatisticDtos;

namespace PremierLeague.BusinessLayer.Abstract
{
    public interface IMatchStatisticService
    {
        Task<List<ResultMatchStatisticDto>> TGetListWithDtoAsync();
        Task<GetMatchStatisticByIdDto> TGetByIdWithDtoAsync(int id);
        Task TInsertWithDtoAsync(CreateMatchStatisticDto dto);
        Task TUpdateWithDtoAsync(UpdateMatchStatisticDto dto);
        Task TDeleteWithDtoAsync(int id);
    }
}
