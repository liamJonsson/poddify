using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface ICategoryRepository
    {
        Task AddCategory(string name);
        Task<List<Category>> GetAllCategories();
        Task<bool> UpdateName(string id, string newName);
        Task DeleteCategory(string categoryId);
    }
}
