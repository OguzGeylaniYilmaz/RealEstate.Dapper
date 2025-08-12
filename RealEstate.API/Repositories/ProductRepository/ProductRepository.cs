using Dapper;
using RealEstate.API.Dtos.ProductDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task ChangeStatus(int productId, bool status)
        {
            string query = "Update Product Set DealOfTheDay = @Status Where ProductID = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", productId);
            parameters.Add("Status", status ? 1 : 0);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultProductDto>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultProductWithCategory>> GetAllProductsWithCategoryAsync()
        {
            string query = @"
                SELECT p.ProductID, p.Title, p.Price ,p.CoverImage, p.City, p.District, p.Address, p.Type, p.DealOfTheDay, c.CategoryName 
                FROM Product p
                INNER JOIN Category c ON p.ProductCategory = c.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultProductWithCategory>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultAdsListDto>> GetProductAdsListAsync(int id)
        {
            string query = @"
                SELECT p.ProductID, p.Title, p.Price ,p.CoverImage, p.City, p.District, p.Address, p.Type, p.DealOfTheDay, c.CategoryName 
                FROM Product p
                INNER JOIN Category c ON p.ProductCategory = c.CategoryID where EmployeeID =@EmployeeId";

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultAdsListDto>(query, parameters);
                return result.ToList();
            }

        }
    }
}