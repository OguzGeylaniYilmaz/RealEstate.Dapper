using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = client.GetAsync("https://localhost:7047/api/Statistic/active-category-count");
            var jsonData = await response.Result.Content.ReadAsStringAsync();
            ViewBag.ActiveCategory = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var response2 = client2.GetAsync("https://localhost:7047/api/Statistic/passive-category-count");
            var jsonData2 = await response2.Result.Content.ReadAsStringAsync();
            ViewBag.PassiveCategory = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var response3 = client3.GetAsync("https://localhost:7047/api/Statistic/category-count");
            var jsonData3 = await response3.Result.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var response4 = client4.GetAsync("https://localhost:7047/api/Statistic/active-employee-count");
            var jsonData4 = await response4.Result.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonData4;

            var client5 = _httpClientFactory.CreateClient();
            var response5 = client5.GetAsync("https://localhost:7047/api/Statistic/product-count");
            var jsonData5 = await response5.Result.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData5;

            var client6 = _httpClientFactory.CreateClient();
            var response6 = client6.GetAsync("https://localhost:7047/api/Statistic/apartment-count");
            var jsonData6 = await response6.Result.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonData6;

            var client7 = _httpClientFactory.CreateClient();
            var response7 = client7.GetAsync("https://localhost:7047/api/Statistic/avereage-room-count");
            var jsonData7 = await response7.Result.Content.ReadAsStringAsync();
            ViewBag.AverageRoomCount = jsonData7;

            var client8 = _httpClientFactory.CreateClient();
            var response8 = client8.GetAsync("https://localhost:7047/api/Statistic/distinct-city-count");
            var jsonData8 = await response8.Result.Content.ReadAsStringAsync();
            ViewBag.DistinctCityCount = jsonData8;

            var client9 = _httpClientFactory.CreateClient();
            var response9 = client9.GetAsync("https://localhost:7047/api/Statistic/average-price/rent");
            var jsonData9 = await response9.Result.Content.ReadAsStringAsync();
            ViewBag.AveragePriceRent = jsonData9;

            var client10 = _httpClientFactory.CreateClient();
            var response10 = client10.GetAsync("https://localhost:7047/api/Statistic/average-price/sale");
            var jsonData10 = await response10.Result.Content.ReadAsStringAsync();
            ViewBag.AveragePriceSale = jsonData10;

            var client11 = _httpClientFactory.CreateClient();
            var response11 = client11.GetAsync("https://localhost:7047/api/Statistic/final-product-price");
            var jsonData11 = await response11.Result.Content.ReadAsStringAsync();
            ViewBag.FinalProductPrice = jsonData11;

            var client12 = _httpClientFactory.CreateClient();
            var response12 = client12.GetAsync("https://localhost:7047/api/Statistic/top-category-by-product");
            var jsonData12 = await response12.Result.Content.ReadAsStringAsync();
            ViewBag.TopCategoryByProduct = jsonData12;

            var client13 = _httpClientFactory.CreateClient();
            var response13 = client13.GetAsync("https://localhost:7047/api/Statistic/top-city-by-product");
            var jsonData13 = await response13.Result.Content.ReadAsStringAsync();
            ViewBag.TopCityByProduct = jsonData13;

            var client14 = _httpClientFactory.CreateClient();
            var response14 = client14.GetAsync("https://localhost:7047/api/Statistic/top-employee-by-product");
            var jsonData14 = await response14.Result.Content.ReadAsStringAsync();
            ViewBag.TopEmployeeByProduct = jsonData14;

            var client15 = _httpClientFactory.CreateClient();
            var response15 = client15.GetAsync("https://localhost:7047/api/Statistic/newest-buildung-year");
            var jsonData15 = await response15.Result.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsonData15;

            var client16 = _httpClientFactory.CreateClient();
            var response16 = client16.GetAsync("https://localhost:7047/api/Statistic/oldest-building-year");
            var jsonData16 = await response16.Result.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsonData16;

            return View();
        }
    }
}
