using RealEstate.API.Dtos.ContactDtos;

namespace RealEstate.API.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetContactsAsync();
        Task<List<LastFourContactResultDto>> GetLast4Contact();
        Task<GetContactByIdDto> GetContactByIdAsync(int id);
        void CeateContact(CreateContactDto createContactDto);
    }
}
