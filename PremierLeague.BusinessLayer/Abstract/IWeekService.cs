using PremierLeague.DtoLayer.WeekDtos;


namespace PremierLeague.BusinessLayer.Abstract
{
    public interface IWeekService
    {
        Task<List<ResultWeekDto>> TGetListWithDtoAsync();
        Task<GetWeekByIdDto> TGetByIdWithDtoAsync(int id);
        Task TInsertWithDtoAsync(CreateWeekDto dto);
        Task TUpdateWithDtoAsync(UpdateWeekDto dto);
        Task TDeleteWithDtoAsync(int id);
    }
}
