using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DtoLayer.TeamDtos;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _TeamService;

        public TeamController(ITeamService TeamService)
        {
            _TeamService = TeamService;
        }

        [HttpGet]
        public async Task<IActionResult> TeamList()
        {
            var values = await _TeamService.TGetListWithDtoAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamDto dto)
        {
            await _TeamService.TInsertWithDtoAsync(dto);
            return Ok("Match Statistic added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _TeamService.TDeleteWithDtoAsync(id);
            return Ok("Match Statistic deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto dto)
        {
            await _TeamService.TUpdateWithDtoAsync(dto);
            return Ok("Match Statistic updated successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var values = await _TeamService.TGetByIdWithDtoAsync(id);
            return Ok(values);
        }

        [HttpGet("GetTeamForm/{id}")]
        public IActionResult GetTeamForm(int id)
        {
            var values = _TeamService.GetTeamLastFiveMatches(id);
            return Ok(values);
        }
    }
}
