using Microsoft.EntityFrameworkCore;
using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SportsplexDbContext _context;

        public CategoryRepository(SportsplexDbContext context)
        {
            _context = context;
        }

        //Get all Categories
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            {

                var category = await _context.Categories
                    .ToListAsync();

                if (category == null)
                {
                    return null;
                }

                return category;

            };
        }


        //Create a Category
        public async Task<Category> CreateCategoryAsync(CreateCategoryDTO categoryDTO)
        {

            var newCategory = new Category
            {
                Name = categoryDTO.Name
            };

            try
            {
                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();
                return newCategory;
            }
            catch (DbUpdateException)
            {
                return null;
            }

        }


        //Update a Category
        public async Task<Category> UpdateCategoryAsync(int id, UpdateCategoryDTO categoryDTO)
        {
            var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categoryToUpdate == null)
            {
                return null;
            }
            categoryToUpdate.Name = categoryDTO.Name;

            try
            {
                await _context.SaveChangesAsync();
                return categoryToUpdate;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
        }

        //Delete a Category
        public async Task<Category> DeleteCategoryAsync(int id)
        {

            var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return null;
            }

            // Remove the category
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;

        }

        //Get a Single Category
        public async Task<Category> GetCategoryByIdAsync(int id)
        {

            var singleCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

            try
            {
                await _context.SaveChangesAsync();
                return singleCategory;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }

        }
    }
}
