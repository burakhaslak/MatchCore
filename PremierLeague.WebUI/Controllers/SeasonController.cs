using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLeague.DtoLayer.SeasonDtos;
using System.Text;

namespace PremierLeague.WebUI.Controllers
{
    public class SeasonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SeasonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SeasonList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Season");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSeason()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason(CreateSeasonDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7113/api/Season", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeasonList");
            }
            return View();
        }

        // 3. DELETE
        public async Task<IActionResult> DeleteSeason(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7113/api/Season/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeasonList");
            }
            return View();
        }

        // 4. UPDATE (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateSeason(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7113/api/Season/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSeasonDto>(jsonData);
                return View(values);
            }

            return View();
        }

        // 4. UPDATE (POST / PUT)
        [HttpPost]
        public async Task<IActionResult> UpdateSeason(UpdateSeasonDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7113/api/Season", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeasonList");
            }
            return View();
        }
    }
}
