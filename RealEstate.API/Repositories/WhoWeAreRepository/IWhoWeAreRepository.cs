using RealEstate.API.Dtos.WhoWeAreDtos;

namespace RealEstate.API.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDto>> GetWhoWeAreListAsync();
        void CreateWhoWeAre(CreateWhoWeAreDto dto);
        void DeleteWhoWeAre(int id);
        void UpdateWhoWeAre(UpdateWhoWeAreDto dto);
        Task<GetWhoWeAreByIdDto> GetWhoWeAre(int id);

    }
}
