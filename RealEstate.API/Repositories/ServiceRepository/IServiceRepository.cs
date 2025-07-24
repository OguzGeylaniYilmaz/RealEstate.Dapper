using RealEstate.API.Dtos.ServiceDtos;

namespace RealEstate.API.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServicesAsync();
        void AddServiceAsync(CreateServiceDto createServiceDto);
        void UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task<GetServiceByIdDto> GetService(int id);
        void DeleteService(int id);
    }
}
