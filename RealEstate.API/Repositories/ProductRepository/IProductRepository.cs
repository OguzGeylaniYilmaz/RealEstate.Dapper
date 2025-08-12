using RealEstate.API.Dtos.ProductDtos;

namespace RealEstate.API.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<List<ResultProductWithCategory>> GetAllProductsWithCategoryAsync();
        Task<List<ResultAdsListDto>> GetProductAdsListAsync(int id);

        Task ChangeStatus(int productId, bool status);
    }
}
