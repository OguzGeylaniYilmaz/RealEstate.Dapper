using Dapper;
using RealEstate.API.Dtos.TestimonialDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.TestimonialRepository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDto>> GetTestimonialsAsync()
        {
            string query = "SELECT * FROM Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var testimonials = await connection.QueryAsync<ResultTestimonialDto>(query);
                return testimonials.ToList();
            }
        }
    }
}
