using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.WhoWeAreDtos;

namespace RealEstate.UI.Controllers
{
    public class WhoWeAreController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhoWeAreController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7047/api/WhoWeAre");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var whoWeAreList = JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(jsonData);
                return View(whoWeAreList);
            }
            else
            {
                ModelState.AddModelError("", "Who We Are bilgileri alınamadı.");
                return View(new List<CreateWhoWeAreDto>());
            }
        }

        [HttpGet]
        public IActionResult CreateWhoWeAre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto whoWeAreDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(whoWeAreDto);
            StringContent content = new(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7047/api/WhoWeAre", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7047/api/WhoWeAre/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Could not delete Who We Are information.");
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWhoWeAre(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7047/api/WhoWeAre/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWhoWeAreDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto whoWeAreDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(whoWeAreDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7047/api/WhoWeAre/{whoWeAreDto.WhoWeAreID}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Who We Are information could not be updated.");
                return View();
            }
        }
    }
}