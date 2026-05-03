using PremierLeague.DtoLayer.SeasonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.BusinessLayer.Abstract
{
    public interface ISeasonService
    {
        Task<List<ResultSeasonDto>> TGetListWithDtoAsync();
        Task<GetSeasonByIdDto> TGetByIdWithDtoAsync(int id);
        Task TInsertWithDtoAsync(CreateSeasonDto dto);
        Task TUpdateWithDtoAsync(UpdateSeasonDto dto);
        Task TDeleteWithDtoAsync(int id);
    }
}
