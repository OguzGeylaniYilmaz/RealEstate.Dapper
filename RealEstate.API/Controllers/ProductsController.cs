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
    }
}
