using Dapper;
using RealEstate.API.Dtos.PopularLocationDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDto>> GetPopularLocationsAsync()
        {
            string query = "SELECT * FROM PopularLocation";
            using var connection = _context.CreateConnection();
            var locations = await connection.QueryAsync<ResultPopularLocationDto>(query);
            return [.. locations];

        }
    }
}
