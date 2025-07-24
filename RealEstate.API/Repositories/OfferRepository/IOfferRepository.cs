using RealEstate.API.Dtos.OfferDtos;

namespace RealEstate.API.Repositories.OfferRepository
{
    public interface IOfferRepository
    {
        Task<List<ResultOfferDto>> GetResultOfferAsync();
        Task<GetOfferByIdDto> GetOfferByIdAsync(int id);
        void CreateOfferAsync(CreateOfferDto createOfferDto);
        void UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        void DeleteOfferAsync(int id);
    }
}
