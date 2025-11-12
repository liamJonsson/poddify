using Poddify.Models;

namespace Poddify.BusinessLayer
{
    public interface ICategoryRepository
    {
        void AddCategory(Category enCategory);
        List<Category> GetAllCategories();
        bool UpdateName(Category enCategory);
        bool DeleteCategory(Category enCategory);
    }
}
