using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PremierLeague.DtoLayer.FootballMatchDtos;
using PremierLeague.DtoLayer.MatchStatisticDtos;
using System.Text;

namespace PremierLeague.WebUI.Controllers
{
    public class MatchStatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // 1. LISTING (GET)
        public async Task<IActionResult> MatchStatisticList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/MatchStatistic");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMatchStatisticDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // 2. CREATE (GET)
        [HttpGet]
        public async Task<IActionResult> CreateMatchStatistic()
        {
            var client = _httpClientFactory.CreateClient();

            // Fetch Football Matches from DB for the Dropdown
            var matchResponse = await client.GetAsync("https://localhost:7113/api/FootballMatch");
            if (matchResponse.IsSuccessStatusCode)
            {
                var matchJson = await matchResponse.Content.ReadAsStringAsync();
                var matches = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(matchJson);

                List<SelectListItem> matchValues = (from x in matches
                                                    select new SelectListItem
                                                    {
                                                        // Update Text property based on your FootballMatchDto structure
                                                        Text = $"Match ID: {x.Id}",
                                                        Value = x.Id.ToString()
                                                    }).ToList();

                ViewBag.v_matches = matchValues;
            }

            return View();
        }

        // 2. CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> CreateMatchStatistic(CreateMatchStatisticDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7113/api/MatchStatistic", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchStatisticList");
            }
            return View();
        }

        // 3. DELETE
        public async Task<IActionResult> DeleteMatchStatistic(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7113/api/MatchStatistic/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchStatisticList");
            }
            return View();
        }

        // 4. UPDATE (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateMatchStatistic(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Fetch dropdown data for the Update page
            var matchResponse = await client.GetAsync("https://localhost:7113/api/FootballMatch");
            if (matchResponse.IsSuccessStatusCode)
            {
                var matchJson = await matchResponse.Content.ReadAsStringAsync();
                var matches = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(matchJson);

                ViewBag.v_matches = (from x in matches
                                     select new SelectListItem
                                     {
                                         Text = $"Match ID: {x.Id}",
                                         Value = x.Id.ToString()
                                     }).ToList();
            }

            // Fetch the existing statistics record to fill the form
            var responseMessage = await client.GetAsync($"https://localhost:7113/api/MatchStatistic/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMatchStatisticDto>(jsonData);
                return View(values);
            }

            return View();
        }

        // 4. UPDATE (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateMatchStatistic(UpdateMatchStatisticDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7113/api/MatchStatistic", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchStatisticList");
            }
            return View();
        }
    }
}
