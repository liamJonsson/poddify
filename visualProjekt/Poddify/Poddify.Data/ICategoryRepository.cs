using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(string name);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByNameAsync(string name);
        Task<Category> GetCategoryByIdAsync(string categoryId);
        Task<bool> UpdateCategoryNameAsync(string categoryId, string newName);
        Task DeleteCategoryAsync(string categoryId);
    }
}
