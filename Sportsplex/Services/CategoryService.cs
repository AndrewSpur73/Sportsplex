using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var singleCategory = _categoryRepo.GetCategoryByIdAsync(id);

            if (singleCategory == null)
            {
                throw new ArgumentException("Category not found.");
            }

            return await _categoryRepo.GetCategoryByIdAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryDTO categoryDTO)
        {
            return await _categoryRepo.CreateCategoryAsync(categoryDTO);
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            return await _categoryRepo.DeleteCategoryAsync(id);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepo.GetAllCategoriesAsync();
        }

        public async Task<Category> UpdateCategoryAsync(int id, UpdateCategoryDTO categoryDTO)
        {
            return await _categoryRepo.UpdateCategoryAsync(id, categoryDTO);

        }
    }
}
