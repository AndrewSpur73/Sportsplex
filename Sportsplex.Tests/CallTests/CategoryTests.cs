using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;
using Sportsplex.Services;
using Moq;

namespace Sportsplex.Tests.CallTests
{
    public class CategoryTests
    {
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        private readonly ICategoryService _categoryService;

        public CategoryTests()
        {
            // Initialize mock repository and service
            _mockCategoryRepository = new Mock<ICategoryRepository>();
            _categoryService = new CategoryService(_mockCategoryRepository.Object);
        }

        [Fact]
        public async Task GetCategoriesAsync_WhenCalled_ReturnCategoriesAsync()
        {
            // Arrange: Create a list of categories to be returned by the mock repository
            var categories = new List<Category>
        {
            new Category {Id = 1 },
            new Category {Id = 2 },
            new Category {Id = 3 }
        };

            _mockCategoryRepository.Setup(x => x.GetAllCategoriesAsync()).ReturnsAsync(categories);

            // Act: Call the service method
            var result = await _categoryService.GetAllCategoriesAsync();

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CreateCategoryAsync_WhenCalled_ReturnNewCategoryAsync()
        {
            // Arrange: Create a DTO and expected category
            var categoryDTO = new CreateCategoryDTO
            {
                Name = "Tennis"
            };

            var category = new Category
            {
                Name = categoryDTO.Name
            };

            _mockCategoryRepository.Setup(x => x.CreateCategoryAsync(categoryDTO)).ReturnsAsync(category);

            // Act: Call the service method
            var result = await _categoryService.CreateCategoryAsync(categoryDTO);

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(categoryDTO.Name, result.Name);
        }

        [Fact]
        public async Task UpdateCategoryAsync_WhenCalled_ReturnUpdateCategoryAsync()
        {
            // Arrange: Create IDs, existing category, and updated DTO
            int categoryId = 1;

            var category = new Category
            {
                Name = "Swimming"
            };

            var editCategoryDTO = new UpdateCategoryDTO
            {
                Name = "Lacrosse"
            };

            var updatedCategory = new Category
            {
                Name = editCategoryDTO.Name
            };

            _mockCategoryRepository.Setup(x => x.GetCategoryByIdAsync(categoryId)).ReturnsAsync(category);
            _mockCategoryRepository.Setup(x => x.UpdateCategoryAsync(categoryId, editCategoryDTO)).ReturnsAsync(updatedCategory);

            // Act: Call the service method
            var result = await _categoryService.UpdateCategoryAsync(categoryId, editCategoryDTO);

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(editCategoryDTO.Name, result.Name);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_WhenCalled_ReturnCategoryByIdAsync()
        {
            // Arrange: Create a category with ID and Name
            var category = new Category
            {
                Id = 1,
                Name = "Pickleball"
            };

            _mockCategoryRepository.Setup(x => x.GetCategoryByIdAsync(category.Id)).ReturnsAsync(category);

            // Act: Call the service method
            var result = await _categoryService.GetCategoryByIdAsync(category.Id);

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(category.Id, result.Id);
            Assert.Equal(category.Name, result.Name);
        }

        [Fact]
        public async Task DeleteCategoryAsync_WhenCalled_ReturnDeletedCategoryAsync()
        {
            // Arrange: Create a category to be deleted
            var category = new Category
            {
                Id = 1,
                Name = "Pickleball"
            };

            _mockCategoryRepository.Setup(x => x.GetCategoryByIdAsync(category.Id)).ReturnsAsync(category);

            // Act: Call the service method to delete the category
            await _categoryService.DeleteCategoryAsync(category.Id);

            // Assert: Verify the delete method was called once and the category is now null
            _mockCategoryRepository.Verify(x => x.DeleteCategoryAsync(category.Id), Times.Once);
            _mockCategoryRepository.Setup(x => x.GetCategoryByIdAsync(category.Id)).ReturnsAsync((Category)null);
        }
    }
}
