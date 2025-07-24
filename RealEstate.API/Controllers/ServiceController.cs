using Microsoft.AspNetCore.Mvc;
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
    }
}
