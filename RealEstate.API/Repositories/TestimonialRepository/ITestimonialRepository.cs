using RealEstate.API.Dtos.TestimonialDtos;

namespace RealEstate.API.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetTestimonialsAsync();
    }
}
