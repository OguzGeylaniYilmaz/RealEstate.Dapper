using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.PopularLocationDtos;
using RealEstate.API.Repositories.PopularLocationRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularLocationsAsync()
        {
            try
            {
                var locations = await _popularLocationRepository.GetPopularLocationsAsync();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            try
            {
                var location = await _popularLocationRepository.GetPopularLocationByIdAsync(id);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            if (createPopularLocationDto == null)
            {
                return BadRequest("Invalid data.");
            }
            try
            {
                _popularLocationRepository.AddPopularLocationAsync(createPopularLocationDto);
                return Ok("Popular location created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            if (updatePopularLocationDto == null)
            {
                return BadRequest("Invalid data.");
            }
            try
            {
                _popularLocationRepository.UpdatePopularLocationAsync(updatePopularLocationDto);
                return Ok("Popular location updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocationAsync(int id)
        {
            try
            {
                _popularLocationRepository.DeletePopularLocationAsync(id);
                return Ok("Popular location deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
