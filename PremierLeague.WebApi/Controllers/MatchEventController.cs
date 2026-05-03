using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DtoLayer.MatchEventDtos;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventController : ControllerBase
    {
        private readonly IMatchEventService _MatchEventService;

        public MatchEventController(IMatchEventService MatchEventService)
        {
            _MatchEventService = MatchEventService;
        }

        [HttpGet]
        public async Task<IActionResult> MatchEventList()
        {
            var values = await _MatchEventService.TGetListWithDtoAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddMatchEvent(CreateMatchEventDto dto)
        {
            await _MatchEventService.TInsertWithDtoAsync(dto);
            return Ok("Match event added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchEvent(int id)
        {
            await _MatchEventService.TDeleteWithDtoAsync(id);
            return Ok("Match event deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatchEvent(UpdateMatchEventDto dto)
        {
            await _MatchEventService.TUpdateWithDtoAsync(dto);
            return Ok("Match event updated successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchEvent(int id)
        {
            var values = await _MatchEventService.TGetByIdWithDtoAsync(id);
            return Ok(values);
        }
    }
}
