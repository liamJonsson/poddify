using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface ICategoryRepository
    {
        void AddCategory(Category enCategory);
        List<Category> GetAllCategories();
        bool UpdateName(Category enCategory);
        bool DeleteCategory(Category enCategory);
    }
}
