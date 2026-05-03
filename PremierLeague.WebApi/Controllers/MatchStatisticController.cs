using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DtoLayer.MatchStatisticDtos;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticController : ControllerBase
    {
        private readonly IMatchStatisticService _MatchStatisticService;

        public MatchStatisticController(IMatchStatisticService MatchStatisticService)
        {
            _MatchStatisticService = MatchStatisticService;
        }

        [HttpGet]
        public async Task<IActionResult> MatchStatisticList()
        {
            var values = await _MatchStatisticService.TGetListWithDtoAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddMatchStatistic(CreateMatchStatisticDto dto)
        {
            await _MatchStatisticService.TInsertWithDtoAsync(dto);
            return Ok("Match Statistic added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchStatistic(int id)
        {
            await _MatchStatisticService.TDeleteWithDtoAsync(id);
            return Ok("Match Statistic deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatchStatistic(UpdateMatchStatisticDto dto)
        {
            await _MatchStatisticService.TUpdateWithDtoAsync(dto);
            return Ok("Match Statistic updated successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchStatistic(int id)
        {
            var values = await _MatchStatisticService.TGetByIdWithDtoAsync(id);
            return Ok(values);
        }
    }
}
