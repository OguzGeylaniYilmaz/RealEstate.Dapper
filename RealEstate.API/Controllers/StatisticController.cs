using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Repositories.StatisticRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {

        private readonly IStatisticRepository _statisticRepository;

        public StatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("active-category-count")]
        public IActionResult GetActiveCategoryCount() => Ok(_statisticRepository.ActiveCategoryCount());

        [HttpGet("passive-category-count")]
        public IActionResult GetPassiveCategoryCount() => Ok(_statisticRepository.PassiveCategoryCount());

        [HttpGet("category-count")]
        public IActionResult GetCategoryCount() => Ok(_statisticRepository.CategoryCount());

        [HttpGet("active-employee-count")]
        public IActionResult GetActiveEmployeeCount() => Ok(_statisticRepository.ActiveEmployeeCount());

        [HttpGet("product-count")]
        public IActionResult GetProductCount() => Ok(_statisticRepository.ProductCount());

        [HttpGet("apartment-count")]
        public IActionResult GetApartmentCount() => Ok(_statisticRepository.ApartmentCount());

        [HttpGet("average-room-count")]
        public IActionResult GetAverageRoomCount() => Ok(_statisticRepository.AverageRoomCount());

        [HttpGet("distinct-city-count")]
        public IActionResult GetNumberOfDifferentCities() => Ok(_statisticRepository.NumberOfDifferentCities());

        [HttpGet("average-price/rent")]
        public IActionResult GetAverageProductPriceByRent() => Ok(_statisticRepository.AverageProductPriceByRent);

        [HttpGet("average-price/sale")]
        public IActionResult GetAverageProductPriceBySale() => Ok(_statisticRepository.AverageProductPriceBySale());

        [HttpGet("final-product-price")]
        public IActionResult GetFinalProductPrice() => Ok(_statisticRepository.ProductCount());

        [HttpGet("top-category-by-product")]
        public IActionResult GetCategoryNameByMaxProductCount() => Ok(_statisticRepository.CategoryNameByMaxProductCount());

        [HttpGet("top-city-by-product")]
        public IActionResult GetCityWithMostProductsCount() => Ok(_statisticRepository.CityWithMostProductsCount());

        [HttpGet("top-employee-by-product")]
        public IActionResult GetEmployeeNameByMaxProductCount() => Ok(_statisticRepository.EmployeeNameByMaxProductCount());

        [HttpGet("newest-building-year")]
        public IActionResult GetNewestBuildingYear() => Ok(_statisticRepository.NewestBuildingYear());

        [HttpGet("oldest-building-year")]
        public IActionResult GetOldestBuildingYear() => Ok(_statisticRepository.OldestBuildungYear());
    }
}
