using RealEstate.API.Dtos.CategoryDtos;

namespace RealEstate.API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        void CreateCategory(CreateCategoryDto category);
        void UpdateCategory(UpdateCategoryDto category);
        void DeleteCategory(int categoryId);
        Task<GetCategoryByIdDto> GetCategoryById(int categoryId);
    }
}
