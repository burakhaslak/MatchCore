using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLeague.DtoLayer.StandingDto;

namespace PremierLeague.WebUI.Controllers
{
    public class StandingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StandingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Standings");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStandingsDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
