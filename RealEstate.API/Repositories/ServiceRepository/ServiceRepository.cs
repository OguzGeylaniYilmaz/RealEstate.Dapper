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

        public async void AddServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "INSERT INTO Service (ServiceName, ServiceStatus) VALUES (@ServiceName, @ServiceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("ServiceName", createServiceDto.ServiceName);
            parameters.Add("ServiceStatus", true);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async void DeleteService(int id)
        {
            var query = "DELETE FROM Service WHERE ServiceID = @ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("ServiceID", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            string query = "SELECT * FROM Service";
            using var connection = _context.CreateConnection();
            var services = await connection.QueryAsync<ResultServiceDto>(query);
            return services.ToList();

        }

        public async Task<GetServiceByIdDto> GetService(int id)
        {
            string query = "SELECT * FROM Service WHERE ServiceID = @ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("ServiceID", id);
            using var connection = _context.CreateConnection();
            var service = await connection.QueryFirstOrDefaultAsync<GetServiceByIdDto>(query, parameters);

            return service == null ? throw new KeyNotFoundException($"Service with ID {id} not found.") : service;
        }

        public async void UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            string query = "UPDATE Service SET ServiceName = @ServiceName, ServiceStatus = @ServiceStatus WHERE ServiceID = @ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("ServiceName", updateServiceDto.ServiceName);
            parameters.Add("ServiceStatus", updateServiceDto.ServiceStatus);
            parameters.Add("ServiceID", updateServiceDto.ServiceID);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
