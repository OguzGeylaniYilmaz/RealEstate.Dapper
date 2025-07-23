using Dapper;
using RealEstate.API.Dtos.WhoWeAreDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAre(CreateWhoWeAreDto dto)
        {
            var query = "INSERT INTO WhoWeAre (Title, Subtitle, ShortDescription, LongDescription) VALUES (@Title, @Subtitle, @ShortDescription, @LongDescription)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", dto.Title);
            parameters.Add("@Subtitle", dto.Subtitle);
            parameters.Add("@ShortDescription", dto.ShortDescription);
            parameters.Add("@LongDescription", dto.LongDescription);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public void DeleteWhoWeAre(int id)
        {

            string query = "DELETE FROM WhoWeAre WHERE WhoWeAreID = @WhoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreID", id);
            using var connection = _context.CreateConnection();
            connection.Execute(query, parameters);
        }

        public async Task<GetWhoWeAreByIdDto> GetWhoWeAre(int id)
        {
            string query = "SELECT * FROM WhoWeAre WHERE WhoWeAreID = @WhoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreID", id);
            using var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<GetWhoWeAreByIdDto>(query, parameters);
            return value;
        }

        public async Task<List<ResultWhoWeAreDto>> GetWhoWeAreListAsync()
        {
            string query = "SELECT * FROM WhoWeAre";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultWhoWeAreDto>(query);
            return values.ToList();
        }

        public async void UpdateWhoWeAre(UpdateWhoWeAreDto dto)
        {
            string query = "UPDATE WhoWeAre SET Title = @Title, Subtitle = @Subtitle, ShortDescription = @ShortDescription, LongDescription = @LongDescription WHERE WhoWeAreID = @WhoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreID", dto.WhoWeAreID);
            parameters.Add("@Title", dto.Title);
            parameters.Add("@Subtitle", dto.Subtitle);
            parameters.Add("@ShortDescription", dto.ShortDescription);
            parameters.Add("@LongDescription", dto.LongDescription);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
