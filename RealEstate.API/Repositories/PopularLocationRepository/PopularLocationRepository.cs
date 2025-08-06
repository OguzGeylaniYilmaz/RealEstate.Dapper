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

        public async void AddPopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "INSERT INTO PopularLocation (CityName, ImageUrl) VALUES (@CityName, @ImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("CityName", createPopularLocationDto.CityName);
            parameters.Add("ImageUrl", createPopularLocationDto.ImageUrl);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
        public async void DeletePopularLocationAsync(int locationId)
        {
            string query = "DELETE FROM PopularLocation WHERE LocationID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", locationId);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetPopularLocationByIdDto> GetPopularLocationByIdAsync(int locationId)
        {
            string query = "SELECT * FROM PopularLocation WHERE LocationID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", locationId);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<GetPopularLocationByIdDto>(query, parameters);
            return result ?? throw new Exception("Popular location not found");
        }

        public async Task<List<ResultPopularLocationDto>> GetPopularLocationsAsync()
        {
            string query = "SELECT * FROM PopularLocation";
            using var connection = _context.CreateConnection();
            var locations = await connection.QueryAsync<ResultPopularLocationDto>(query);
            return [.. locations];

        }
        public async void UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "UPDATE PopularLocation SET CityName = @CityName, ImageUrl = @ImageUrl WHERE LocationID = @LocationID";
            var parameters = new DynamicParameters();
            parameters.Add("CityName", updatePopularLocationDto.CityName);
            parameters.Add("ImageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("LocationID", updatePopularLocationDto.LocationID);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
