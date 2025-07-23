using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.WhoWeAreDtos;
using RealEstate.API.Repositories.WhoWeAreRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        private readonly IWhoWeAreRepository _repository;

        public WhoWeAreController(IWhoWeAreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreList()
        {
            var result = await _repository.GetWhoWeAreListAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No WhoWeAre records found.");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAre(int id)
        {
            var result = await _repository.GetWhoWeAre(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto dto)
        {

            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }
            _repository.CreateWhoWeAre(dto);
            return Ok("WhoWeAre created successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }
            _repository.DeleteWhoWeAre(id);
            return Ok("WhoWeAre deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto dto)
        {
            if (dto == null || dto.WhoWeAreID <= 0)
            {
                return BadRequest("Invalid data.");
            }
            _repository.UpdateWhoWeAre(dto);
            return Ok("WhoWeAre updated successfully.");
        }
    }
}
