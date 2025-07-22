using Dapper;
using RealEstate.API.Dtos.CategoryDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            string query = "SELECT * FROM Category";
            using (var connection = _context.CreateConnection())
            {
                var categories = await connection.QueryAsync<ResultCategoryDto>(query);
                return categories.ToList();
            }
        }

        public async void CreateCategory(CreateCategoryDto category)
        {
            string query = "INSERT INTO Category (CategoryName, Status) VALUES (@CategoryName, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", category.CategoryName);
            parameters.Add("@Status", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM Category WHERE CategoryID = @CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", categoryId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public void UpdateCategory(UpdateCategoryDto updateCategory)
        {
            string query = "UPDATE Category SET CategoryName = @CategoryName, Status = @Status WHERE CategoryID = @CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", updateCategory.CategoryID);
            parameters.Add("@CategoryName", updateCategory.CategoryName);
            parameters.Add("@Status", updateCategory.Status);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public async Task<GetCategoryByIdDto?> GetCategoryById(int categoryId)
        {
            var query = "SELECT * FROM Category WHERE CategoryID = @CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", categoryId);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<GetCategoryByIdDto>(query, parameters);
                return result;
            }
        }
    }
}