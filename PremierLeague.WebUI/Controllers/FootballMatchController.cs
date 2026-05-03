using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PremierLeague.DtoLayer.FootballMatchDtos;
using PremierLeague.DtoLayer.TeamDtos;
using PremierLeague.DtoLayer.WeekDtos;
using System.Text;

namespace PremierLeague.WebUI.Controllers
{
    public class FootballMatchController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FootballMatchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> FootballMatchList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/FootballMatch");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(jsonData);

                return View(values);
            }
            return View(new List<ResultFootballMatchDto>());
        }
            

        [HttpGet]
        public async Task<IActionResult> CreateMatch()
        {
            var client = _httpClientFactory.CreateClient();

            var teamResponse = await client.GetAsync("https://localhost:7113/api/Team");
            if (teamResponse.IsSuccessStatusCode)
            {
                var teamJson = await teamResponse.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJson);

                List<SelectListItem> teamValues = (from x in teams
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();

                ViewBag.v_teams = teamValues;
            }

            var weekResponse = await client.GetAsync("https://localhost:7113/api/Week");
            if (weekResponse.IsSuccessStatusCode)
            {
                var weekJson = await weekResponse.Content.ReadAsStringAsync();
                var weeks = JsonConvert.DeserializeObject<List<ResultWeekDto>>(weekJson);

                List<SelectListItem> weekValues = (from x in weeks
                                                   select new SelectListItem
                                                   {
                                                       Text = "Week " + x.WeekNumber.ToString(),
                                                       Value = x.Id.ToString()
                                                   }).ToList();

                ViewBag.v_weeks = weekValues;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateFootballMatchDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7113/api/FootballMatch", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FootballMatchList"); 
            }
            return View();
        }

        // 3. Silme (Delete)
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7113/api/FootballMatch/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FootballMatchList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMatch(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var teamResponse = await client.GetAsync("https://localhost:7113/api/Team");
            if (teamResponse.IsSuccessStatusCode)
            {
                var teamJson = await teamResponse.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJson);
                ViewBag.v_teams = (from x in teams
                                   select new SelectListItem
                                   {
                                       Text = x.Name,
                                       Value = x.Id.ToString()
                                   }).ToList();
            }

            var weekResponse = await client.GetAsync("https://localhost:7113/api/Week");
            if (weekResponse.IsSuccessStatusCode)
            {
                var weekJson = await weekResponse.Content.ReadAsStringAsync();
                var weeks = JsonConvert.DeserializeObject<List<ResultWeekDto>>(weekJson);
                ViewBag.v_weeks = (from x in weeks
                                   select new SelectListItem
                                   {
                                       Text = "Week " + x.WeekNumber.ToString(),
                                       Value = x.Id.ToString()
                                   }).ToList();
            }

            var responseMessage = await client.GetAsync($"https://localhost:7113/api/FootballMatch/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFootballMatchDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMatch(UpdateFootballMatchDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7113/api/FootballMatch", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FootballMatchList");
            }
            return View();
        }
    }
}
