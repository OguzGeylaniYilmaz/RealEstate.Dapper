using Microsoft.AspNetCore.Mvc;
using RealEstate.UI.Dtos.TestimonialDtos;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class OurClients : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OurClients(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7047/api/Testimonials");

            if (response.IsSuccessStatusCode)
            {
                var testimonials = await response.Content.ReadAsStringAsync();
                var jsonTestimonials = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(testimonials);
                return View(jsonTestimonials);
            }
            return View();
        }
    }
}
