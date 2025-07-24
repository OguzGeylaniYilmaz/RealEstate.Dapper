using Dapper;
using RealEstate.API.Dtos.OfferDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.OfferRepository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly Context _context;

        public OfferRepository(Context context)
        {
            _context = context;
        }

        public async void CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            string query = "INSERT INTO Offers (Icon, Title, Description) VALUES (@Icon, @Title, @Description)";
            var parameters = new DynamicParameters();
            parameters.Add("@Icon", createOfferDto.Icon);
            parameters.Add("@Title", createOfferDto.Title);
            parameters.Add("@Description", createOfferDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteOfferAsync(int id)
        {
            string query = "DELETE FROM Offers WHERE OfferID = @OfferID";
            var parameters = new DynamicParameters();
            parameters.Add("@OfferID", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetOfferByIdDto> GetOfferByIdAsync(int id)
        {
            string query = "SELECT * FROM Offers WHERE OfferID = @OfferID";
            var parameters = new DynamicParameters();
            parameters.Add("@OfferID", id);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<GetOfferByIdDto>(query, parameters);
            return result ?? throw new Exception("Offer not found");
        }

        public async Task<List<ResultOfferDto>> GetResultOfferAsync()
        {
            string query = "SELECT OfferID, Icon, Title, Description FROM Offer";
            using (var connection = _context.CreateConnection())
            {
                var offers = await connection.QueryAsync<ResultOfferDto>(query);
                return [.. offers];
            }
        }

        public async void UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            string query = "UPDATE Offers SET Icon = @Icon, Title = @Title, Description = @Description WHERE OfferID = @OfferID";
            var parameters = new DynamicParameters();
            parameters.Add("@Icon", updateOfferDto.Icon);
            parameters.Add("@Title", updateOfferDto.Title);
            parameters.Add("@Description", updateOfferDto.Descriptipn);
            parameters.Add("@OfferID", updateOfferDto.OfferID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
