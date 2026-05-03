using AutoMapper;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DtoLayer.MatchEventDtos;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.BusinessLayer.Concrete
{
    public class MatchEventManager : IMatchEventService
    {
        private readonly IMatchEventDal _MatchEventDal;
        private readonly IMapper _mapper;

        public MatchEventManager(IMatchEventDal MatchEventDal, IMapper mapper)
        {
            _MatchEventDal = MatchEventDal;
            _mapper = mapper;
        }

        public async Task TDeleteWithDtoAsync(int id)
        {
            await _MatchEventDal.DeleteAsync(id);
        }
        public async Task<GetMatchEventByIdDto> TGetByIdWithDtoAsync(int id)
        {
            var value = await _MatchEventDal.GetByIdAsync(id);
            return _mapper.Map<GetMatchEventByIdDto>(value);
        }

        public async Task<List<ResultMatchEventDto>> TGetListWithDtoAsync()
        {
            var values = await _MatchEventDal.GetMatchEventsWithMatchInfoAsync();

            return _mapper.Map<List<ResultMatchEventDto>>(values);
        }
        public async Task TInsertWithDtoAsync(CreateMatchEventDto dto)
        {
            var value = _mapper.Map<MatchEvent>(dto);
            await _MatchEventDal.InsertAsync(value);
        }


        public async Task TUpdateWithDtoAsync(UpdateMatchEventDto dto)
        {
            var value = _mapper.Map<MatchEvent>(dto);
            await _MatchEventDal.UpdateAsync(value);
        }
    }
}
