using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.ProductDtos;

namespace RealEstate.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyAdsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7047/api/Products/AdsList?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultAdsListDto>>(jsonData);
                return View(products);
            }
            return View();
        }
    }
}
