using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.WhoWeAreDtos;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class WhoWeAreArea : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhoWeAreArea(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var serviceClint = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7047/api/WhoWeAre");
            var serviceResponse = await serviceClint.GetAsync("https://localhost:7047/api/Service");


            if (response.IsSuccessStatusCode && serviceResponse.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var serviceData = await serviceResponse.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(data);
                var jsonServiceData = JsonConvert.DeserializeObject<List<ResultServiceDto>>(serviceData);

                ViewBag.title = jsonData.Select(x => x.Title).FirstOrDefault();
                ViewBag.subtitle = jsonData.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.shortDescription = jsonData.Select(x => x.ShortDescription).FirstOrDefault();
                ViewBag.longDescription = jsonData.Select(x => x.LongDescription).FirstOrDefault();

                return View(jsonServiceData);
            }

            return View();
        }
    }
}
