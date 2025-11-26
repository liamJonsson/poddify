using MongoDB.Driver;
using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(string name, IClientSessionHandle session);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByNameAsync(string name);
        Task<Category> GetCategoryByIdAsync(string categoryId);
        Task<bool> UpdateCategoryNameAsync(string categoryId, string newName, IClientSessionHandle session);
        Task DeleteCategoryAsync(string categoryId, IClientSessionHandle session);
    }
}
