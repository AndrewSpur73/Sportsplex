using Sportsplex.DTO;
using Sportsplex.Models;

namespace Sportsplex.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(CreateCategoryDTO categoryDTO);
        Task<Category> UpdateCategoryAsync(int id, UpdateCategoryDTO categoryDTO);
        Task<Category> DeleteCategoryAsync(int id);
    }
}
