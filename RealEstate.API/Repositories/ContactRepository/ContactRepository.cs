using Dapper;
using RealEstate.API.Dtos.ContactDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async void CeateContact(CreateContactDto createContactDto)
        {
            string query = @"INSERT INTO Contact (Name, Subject, Email, Message, DateOfPosting) 
                      VALUES (@Name, @Subject, @Email, @Message, @DateOfPosting)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createContactDto.Name);
            parameters.Add("@Subject", createContactDto.Subject);
            parameters.Add("@Email", createContactDto.Email);
            parameters.Add("@Message", createContactDto.Message);
            parameters.Add("@DateOfPosting", createContactDto.DateOfPosting);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task<GetContactByIdDto> GetContactByIdAsync(int id)
        {
            string query = @"SELECT * FROM Contact WHERE ContactID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            var contact = await connection.QueryFirstOrDefaultAsync<GetContactByIdDto>(query, parameters);
            return contact ?? throw new KeyNotFoundException($"Contact with ID {id} not found.");
        }

        public async Task<List<ResultContactDto>> GetContactsAsync()
        {
            string query = @"SELECT * FROM Contact";
            using var connection = _context.CreateConnection();
            var contacts = await connection.QueryAsync<ResultContactDto>(query);
            return contacts.ToList();
        }

        public async Task<List<LastFourContactResultDto>> GetLast4Contact()
        {
            string query = @"SELECT TOP 4 * FROM Contact ORDER BY ContactID DESC";
            using var connection = _context.CreateConnection();
            var contacts = await connection.QueryAsync<LastFourContactResultDto>(query);
            return contacts.ToList();
        }
    }
}
