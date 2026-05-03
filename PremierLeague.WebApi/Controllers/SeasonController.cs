using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DtoLayer.SeasonDtos;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _SeasonService;

        public SeasonController(ISeasonService SeasonService)
        {
            _SeasonService = SeasonService;
        }

        [HttpGet]
        public async Task<IActionResult> SeasonList()
        {
            var values = await _SeasonService.TGetListWithDtoAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeason(CreateSeasonDto dto)
        {
            await _SeasonService.TInsertWithDtoAsync(dto);
            return Ok("Match Statistic added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            await _SeasonService.TDeleteWithDtoAsync(id);
            return Ok("Match Statistic deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeason(UpdateSeasonDto dto)
        {
            await _SeasonService.TUpdateWithDtoAsync(dto);
            return Ok("Match Statistic updated successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeason(int id)
        {
            var values = await _SeasonService.TGetByIdWithDtoAsync(id);
            return Ok(values);
        }
    }
}
