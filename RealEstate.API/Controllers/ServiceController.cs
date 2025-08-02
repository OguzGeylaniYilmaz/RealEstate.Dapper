using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.ServiceDtos;
using RealEstate.API.Repositories.ServiceRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var services = await _serviceRepository.GetAllServicesAsync();
            if (services == null || !services.Any())
            {
                return NotFound("No services found.");
            }
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            try
            {
                var service = await _serviceRepository.GetService(id);
                return Ok(service);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            if (createServiceDto == null || string.IsNullOrWhiteSpace(createServiceDto.ServiceName))
            {
                return BadRequest("Invalid service data.");
            }

            _serviceRepository.AddServiceAsync(createServiceDto);
            return Ok("Service created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (updateServiceDto == null || updateServiceDto.ServiceID <= 0 || string.IsNullOrWhiteSpace(updateServiceDto.ServiceName))
            {
                return BadRequest("Invalid service data.");
            }
            try
            {
                _serviceRepository.UpdateServiceAsync(updateServiceDto);
                return Ok("Service updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid service ID.");
            }
            try
            {
                _serviceRepository.DeleteService(id);
                return Ok("Service deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}