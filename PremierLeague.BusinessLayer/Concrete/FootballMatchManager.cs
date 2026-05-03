using AutoMapper;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.EntityFramework;
using PremierLeague.DtoLayer.FootballMatchDtos;
using PremierLeague.DtoLayer.MatchDtos;
using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.BusinessLayer.Concrete
{
    public class FootballMatchManager : IFootballMatchService
    {
        private readonly IFootballMatchDal _FootballMatchDal;
        private readonly IMapper _mapper;

        public FootballMatchManager(IFootballMatchDal FootballMatchDal, IMapper mapper)
        {
            _FootballMatchDal = FootballMatchDal;
            _mapper = mapper;
        }

        public async Task TDeleteWithDtoAsync(int id)
        {
            await _FootballMatchDal.DeleteAsync(id);
        }
        public async Task<GetFootballMatchByIdDto> TGetByIdWithDtoAsync(int id)
        {
            var value = await _FootballMatchDal.GetByIdAsync(id);
            return _mapper.Map<GetFootballMatchByIdDto>(value);
        }

        public async Task<List<ResultFootballMatchDto>> TGetListWithDtoAsync()
        {
            var values = await _FootballMatchDal.GetFootballMatchesWithTeamsAsync();

            return _mapper.Map<List<ResultFootballMatchDto>>(values);
        }
        public async Task TInsertWithDtoAsync(CreateFootballMatchDto dto)
        {
            var value = _mapper.Map<FootballMatch>(dto);
            await _FootballMatchDal.InsertAsync(value);
        }


        public async Task TUpdateWithDtoAsync(UpdateFootballMatchDto dto)
        {
            var value = _mapper.Map<FootballMatch>(dto);
            await _FootballMatchDal.UpdateAsync(value);
        }

        public ResultMatchSummaryDto GetMatchSummary(int matchId)
        {
            return _FootballMatchDal.GetMatchSummary(matchId);
        }
    }
}
