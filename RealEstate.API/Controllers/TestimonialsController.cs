using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Repositories.TestimonialRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialsController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var testimonials = await _testimonialRepository.GetTestimonialsAsync();
            if (testimonials == null || !testimonials.Any())
            {
                return NotFound("No testimonials found.");
            }
            return Ok(testimonials);
        }
    }
}
