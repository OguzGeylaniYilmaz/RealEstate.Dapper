using RealEstate.API.Dtos.PopularLocationDtos;

namespace RealEstate.API.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetPopularLocationsAsync();
        Task<GetPopularLocationByIdDto> GetPopularLocationByIdAsync(int locationId);
        void AddPopularLocationAsync(CreatePopularLocationDto createPopularLocationDto);
        void UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto);
        void DeletePopularLocationAsync(int locationId);
    }
}
