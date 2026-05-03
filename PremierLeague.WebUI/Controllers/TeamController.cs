using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLeague.DtoLayer.TeamDtos;
using System.Text;

namespace PremierLeague.WebUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TeamList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Team");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7113/api/Team", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7113/api/Team/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7113/api/Team/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTeamDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7113/api/Team", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }
    }
}
