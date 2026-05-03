using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PremierLeague.DtoLayer.FootballMatchDtos;
using PremierLeague.DtoLayer.MatchEventDtos;
using System.Text;

namespace PremierLeague.WebUI.Controllers
{
    public class MatchEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MatchEventList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/MatchEvent");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    
        [HttpGet]
        public async Task<IActionResult> CreateMatchEvent()
        {
            var client = _httpClientFactory.CreateClient();

            var matchResponse = await client.GetAsync("https://localhost:7113/api/FootballMatch");
            if (matchResponse.IsSuccessStatusCode)
            {
                var matchJson = await matchResponse.Content.ReadAsStringAsync();
                var matches = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(matchJson);

                List<SelectListItem> matchValues = (from x in matches
                                                    select new SelectListItem
                                                    {
                                                        Text = $"Match ID: {x.Id}",
                                                        Value = x.Id.ToString()
                                                    }).ToList();

                ViewBag.v_matches = matchValues;
            }


            List<SelectListItem> actionTypeValues = new List<SelectListItem>
            {
                new SelectListItem { Text = "Goal", Value = "Goal" },
                new SelectListItem { Text = "Yellow Card", Value = "YellowCard" },
                new SelectListItem { Text = "Red Card", Value = "RedCard" },
                new SelectListItem { Text = "Substitution", Value = "Substitution" }
            };
            ViewBag.v_actionTypes = actionTypeValues;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatchEvent(CreateMatchEventDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7113/api/MatchEvent", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchEventList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteMatchEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7113/api/MatchEvent/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchEventList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMatchEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();

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

            ViewBag.v_actionTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Goal", Value = "Goal" },
                new SelectListItem { Text = "Yellow Card", Value = "YellowCard" },
                new SelectListItem { Text = "Red Card", Value = "RedCard" },
                new SelectListItem { Text = "Substitution", Value = "Substitution" }
            };

            var responseMessage = await client.GetAsync($"https://localhost:7113/api/MatchEvent/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMatchEventDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMatchEvent(UpdateMatchEventDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7113/api/MatchEvent", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchEventList");
            }
            return View();
        }
    }
}
