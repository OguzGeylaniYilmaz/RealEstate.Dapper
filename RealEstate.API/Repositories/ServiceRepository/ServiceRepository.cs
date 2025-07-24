using Dapper;
using RealEstate.API.Dtos.ServiceDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public void AddServiceAsync(CreateServiceDto createServiceDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            string query = "SELECT * FROM Service";
            using var connection = _context.CreateConnection();
            var services = await connection.QueryAsync<ResultServiceDto>(query);
            return services.ToList();

        }

        public Task<GetServiceByIdDto> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}
