using AutoMapper;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DtoLayer.MatchStatisticDtos;
using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.BusinessLayer.Concrete
{
    public class MatchStatisticManager : IMatchStatisticService
    {
        private readonly IMatchStatisticsDal _MatchStatisticDal;
        private readonly IMapper _mapper;

        public MatchStatisticManager(IMatchStatisticsDal MatchStatisticDal, IMapper mapper)
        {
            _MatchStatisticDal = MatchStatisticDal;
            _mapper = mapper;
        }

        public async Task TDeleteWithDtoAsync(int id)
        {
            await _MatchStatisticDal.DeleteAsync(id);
        }
        public async Task<GetMatchStatisticByIdDto> TGetByIdWithDtoAsync(int id)
        {
            var value = await _MatchStatisticDal.GetByIdAsync(id);
            return _mapper.Map<GetMatchStatisticByIdDto>(value);
        }

        public async Task<List<ResultMatchStatisticDto>> TGetListWithDtoAsync()
        {
            var values = await _MatchStatisticDal.GetListAsync();
            return _mapper.Map<List<ResultMatchStatisticDto>>(values);
        }
        public async Task TInsertWithDtoAsync(CreateMatchStatisticDto dto)
        {
            var value = _mapper.Map<MatchStatistic>(dto);
            await _MatchStatisticDal.InsertAsync(value);
        }


        public async Task TUpdateWithDtoAsync(UpdateMatchStatisticDto dto)
        {
            var value = _mapper.Map<MatchStatistic>(dto);
            await _MatchStatisticDal.UpdateAsync(value);
        }
    }
}
