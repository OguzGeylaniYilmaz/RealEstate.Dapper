using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.OfferDtos;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class OurServices : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OurServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7047/api/Offer");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ResultOfferDto>>(data);
                return View(services);
            }
            return View();
        }
    }
}
