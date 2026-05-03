using AutoMapper;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DtoLayer.SeasonDtos;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.BusinessLayer.Concrete
{
    public class SeasonManager : ISeasonService
    {
        private readonly ISeasonDal _SeasonDal;
        private readonly IMapper _mapper;

        public SeasonManager(ISeasonDal SeasonDal, IMapper mapper)
        {
            _SeasonDal = SeasonDal;
            _mapper = mapper;
        }

        public async Task TDeleteWithDtoAsync(int id)
        {
            await _SeasonDal.DeleteAsync(id);
        }
        public async Task<GetSeasonByIdDto> TGetByIdWithDtoAsync(int id)
        {
            var value = await _SeasonDal.GetByIdAsync(id);
            return _mapper.Map<GetSeasonByIdDto>(value);
        }

        public async Task<List<ResultSeasonDto>> TGetListWithDtoAsync()
        {
            var values = await _SeasonDal.GetListAsync();
            return _mapper.Map<List<ResultSeasonDto>>(values);
        }
        public async Task TInsertWithDtoAsync(CreateSeasonDto dto)
        {
            var value = _mapper.Map<Season>(dto);
            await _SeasonDal.InsertAsync(value);
        }


        public async Task TUpdateWithDtoAsync(UpdateSeasonDto dto)
        {
            var value = _mapper.Map<Season>(dto);
            await _SeasonDal.UpdateAsync(value);
        }
    }
}
