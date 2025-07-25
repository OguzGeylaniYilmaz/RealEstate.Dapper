using RealEstate.API.Dtos.PopularLocationDtos;

namespace RealEstate.API.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetPopularLocationsAsync();
    }
}
