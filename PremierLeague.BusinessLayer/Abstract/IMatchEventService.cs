using PremierLeague.DtoLayer.MatchEventDtos;


namespace PremierLeague.BusinessLayer.Abstract
{
    public interface IMatchEventService
    {
        Task<List<ResultMatchEventDto>> TGetListWithDtoAsync();
        Task<GetMatchEventByIdDto> TGetByIdWithDtoAsync(int id);
        Task TInsertWithDtoAsync(CreateMatchEventDto dto);
        Task TUpdateWithDtoAsync(UpdateMatchEventDto dto);
        Task TDeleteWithDtoAsync(int id);
    }
}
