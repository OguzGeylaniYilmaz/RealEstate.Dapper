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
                SELECT p.ProductID, p.Title, p.Price, p.City, p.District, c.CategoryName 
                FROM Product p
                INNER JOIN Category c ON p.ProductCategory = c.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultProductWithCategory>(query);
                return result.ToList();
            }
        }
    }
}