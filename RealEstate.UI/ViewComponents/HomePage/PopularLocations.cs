using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.PopularLocationDto;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class PopularLocations : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PopularLocations(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7047/api/PopularLocations");

            if (response.IsSuccessStatusCode)
            {
                var locations = await response.Content.ReadAsStringAsync();
                var jsonLocations = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(locations);
                return View(jsonLocations);
            }
            return View();
        }
    }
}
