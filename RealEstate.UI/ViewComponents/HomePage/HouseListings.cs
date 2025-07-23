using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.ProductDtos;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class HouseListings : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HouseListings(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7047/api/Products/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(products);
                return View(values);
            }
            return View();
        }
    }
}
