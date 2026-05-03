using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DtoLayer.FootballMatchDtos;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballMatchController : ControllerBase
    {
        private readonly IFootballMatchService _footballMatchService;

        public FootballMatchController(IFootballMatchService footballMatchService)
        {
            _footballMatchService = footballMatchService;
        }

        [HttpGet]
        public async Task<IActionResult> FootballMatchList()
        {
            var values = await _footballMatchService.TGetListWithDtoAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddFootballMatch(CreateFootballMatchDto dto)
        {
            await _footballMatchService.TInsertWithDtoAsync(dto);
            return Ok("Football match added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootballMatch(int id)
        {
            await _footballMatchService.TDeleteWithDtoAsync(id);
            return Ok("Football match deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFootballMatch(UpdateFootballMatchDto dto)
        {
            await _footballMatchService.TUpdateWithDtoAsync(dto);
            return Ok("Football match updated successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFootballMatch(int id)
        {
            var values = await _footballMatchService.TGetByIdWithDtoAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMatchSummary/{id}")]
        public IActionResult GetMatchSummary(int id)
        {
            var value = _footballMatchService.GetMatchSummary(id);

            if (value == null)
            {
                return NotFound("Football match could not be found.");
            }

            return Ok(value);
        }
    }
}
