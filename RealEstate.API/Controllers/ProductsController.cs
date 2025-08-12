using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Repositories.ProductRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            var products = await _productRepository.GetAllProductsWithCategoryAsync();
            return Ok(products);
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(int productId, bool status)
        {
            await _productRepository.ChangeStatus(productId, status);
            return Ok(new { Message = "Product status updated successfully." });
        }

        [HttpGet("AdsList")]
        public async Task<IActionResult> GetProductAdsList(int id)
        {
            var adsList = await _productRepository.GetProductAdsListAsync(id);
            return Ok(adsList);
        }
    }
}
