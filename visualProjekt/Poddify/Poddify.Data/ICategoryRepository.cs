using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface ICategoryRepository
    {
        Task AddCategory(string name);
        Task<List<Category>> GetAllCategories();
        Task<bool> UpdateName(string categoryId, string newName);
        Task<Category> GetCategoryIdAsync(string categoryId);
        Task DeleteCategory(string categoryId);
    }
}
