using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.BusinessLayer.Abstract;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingsController : ControllerBase
    {
        private readonly IStandingsService _standingsService;

        public StandingsController(IStandingsService standingsService)
        {
            _standingsService = standingsService;
        }

        [HttpGet]
        public IActionResult GetStandings()
        {
            var values = _standingsService.GetStandings();
            return Ok(values);
        }
    }
}
