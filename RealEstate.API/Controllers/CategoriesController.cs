using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.CategoryDtos;
using RealEstate.API.Repositories.CategoryRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found.");
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            _categoryRepository.CreateCategory(categoryDto);
            return Ok("Category created successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Invalid category ID.");
            }
            _categoryRepository.DeleteCategory(categoryId);
            return Ok("Category deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto == null || updateCategoryDto.CategoryID <= 0)
            {
                return BadRequest("Invalid category data.");
            }
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Category updated successfully.");
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Invalid category ID.");
            }
            var category = await _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            return Ok(category);
        }
    }
}
