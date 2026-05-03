using AutoMapper;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.EntityFramework;
using PremierLeague.DtoLayer.TeamDtos;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _TeamDal;
        private readonly IMapper _mapper;

        public TeamManager(ITeamDal TeamDal, IMapper mapper)
        {
            _TeamDal = TeamDal;
            _mapper = mapper;
        }

        public async Task TDeleteWithDtoAsync(int id)
        {
            await _TeamDal.DeleteAsync(id);
        }
        public async Task<GetTeamByIdDto> TGetByIdWithDtoAsync(int id)
        {
            var value = await _TeamDal.GetByIdAsync(id);
            return _mapper.Map<GetTeamByIdDto>(value);
        }

        public async Task<List<ResultTeamDto>> TGetListWithDtoAsync()
        {
            var values = await _TeamDal.GetListAsync();
            return _mapper.Map<List<ResultTeamDto>>(values);
        }
        public async Task TInsertWithDtoAsync(CreateTeamDto dto)
        {
            var value = _mapper.Map<Team>(dto);
            await _TeamDal.InsertAsync(value);
        }


        public async Task TUpdateWithDtoAsync(UpdateTeamDto dto)
        {
            var value = _mapper.Map<Team>(dto);
            await _TeamDal.UpdateAsync(value);
        }

        public List<ResultTeamFormDto> GetTeamLastFiveMatches(int teamId)
        {
            return _TeamDal.GetTeamLastFiveMatches(teamId);
        }
    }
}
