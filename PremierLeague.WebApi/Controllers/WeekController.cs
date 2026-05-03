using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DtoLayer.WeekDtos;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekController : ControllerBase
    {
        private readonly IWeekService _WeekService;

        public WeekController(IWeekService WeekService)
        {
            _WeekService = WeekService;
        }

        [HttpGet]
        public async Task<IActionResult> WeekList()
        {
            var values = await _WeekService.TGetListWithDtoAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddWeek(CreateWeekDto dto)
        {
            await _WeekService.TInsertWithDtoAsync(dto);
            return Ok("Match Statistic added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeek(int id)
        {
            await _WeekService.TDeleteWithDtoAsync(id);
            return Ok("Match Statistic deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWeek(UpdateWeekDto dto)
        {
            await _WeekService.TUpdateWithDtoAsync(dto);
            return Ok("Match Statistic updated successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeek(int id)
        {
            var values = await _WeekService.TGetByIdWithDtoAsync(id);
            return Ok(values);
        }
    }
}
