using AutoMapper;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DtoLayer.WeekDtos;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.BusinessLayer.Concrete
{
    public class WeekManager : IWeekService
    {
        private readonly IWeekDal _WeekDal;
        private readonly IMapper _mapper;

        public WeekManager(IWeekDal WeekDal, IMapper mapper)
        {
            _WeekDal = WeekDal;
            _mapper = mapper;
        }

        public async Task TDeleteWithDtoAsync(int id)
        {
            await _WeekDal.DeleteAsync(id);
        }
        public async Task<GetWeekByIdDto> TGetByIdWithDtoAsync(int id)
        {
            var value = await _WeekDal.GetByIdAsync(id);
            return _mapper.Map<GetWeekByIdDto>(value);
        }

        public async Task<List<ResultWeekDto>> TGetListWithDtoAsync()
        {
            var values = await _WeekDal.GetListAsync();
            return _mapper.Map<List<ResultWeekDto>>(values);
        }
        public async Task TInsertWithDtoAsync(CreateWeekDto dto)
        {
            var value = _mapper.Map<Week>(dto);
            await _WeekDal.InsertAsync(value);
        }


        public async Task TUpdateWithDtoAsync(UpdateWeekDto dto)
        {
            var value = _mapper.Map<Week>(dto);
            await _WeekDal.UpdateAsync(value);
        }
    }
}
