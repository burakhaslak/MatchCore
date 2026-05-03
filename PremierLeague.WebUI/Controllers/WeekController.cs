using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PremierLeague.DtoLayer.SeasonDtos;
using PremierLeague.DtoLayer.WeekDtos;
using System.Text;

namespace PremierLeague.WebUI.Controllers
{
    public class WeekController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeekController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WeekList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Week");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWeekDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateWeek()
        {
            var client = _httpClientFactory.CreateClient();

            var seasonResponse = await client.GetAsync("https://localhost:7113/api/Season");
            if (seasonResponse.IsSuccessStatusCode)
            {
                var seasonJson = await seasonResponse.Content.ReadAsStringAsync();
                var seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonJson);

                List<SelectListItem> seasonValues = (from x in seasons
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.Id.ToString()
                                                     }).ToList();

                ViewBag.v_seasons = seasonValues;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeek(CreateWeekDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7113/api/Week", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WeekList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteWeek(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7113/api/Week/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WeekList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWeek(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var seasonResponse = await client.GetAsync("https://localhost:7113/api/Season");
            if (seasonResponse.IsSuccessStatusCode)
            {
                var seasonJson = await seasonResponse.Content.ReadAsStringAsync();
                var seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonJson);

                ViewBag.v_seasons = (from x in seasons
                                     select new SelectListItem
                                     {
                                         Text = x.Name,
                                         Value = x.Id.ToString()
                                     }).ToList();
            }

            var responseMessage = await client.GetAsync($"https://localhost:7113/api/Week/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWeekDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWeek(UpdateWeekDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7113/api/Week", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WeekList");
            }
            return View();
        }
    }
}
