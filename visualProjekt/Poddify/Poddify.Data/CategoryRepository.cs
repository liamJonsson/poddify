using MongoDB.Driver;
using Poddify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poddify.DataLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> categoryCollection;

        //Skapar en ny kategori och lägger in den i en kollektion i databasen
        public async Task AddCategory(string name)
        {
            var newCategory = new Category { Name = name };
            await categoryCollection.InsertOneAsync(newCategory);
        }

        //Hämtar alla kategorier
        public async Task<List<Category>> GetAllCategories()
        {
            return await categoryCollection.Find(FilterDefinition<Category>.Empty).ToListAsync();
        }

        //Hämtar en specifik kategori
        public async Task<Category> GetCategoryIdAsync(string categoryId)
        {
            var filter = Builders<Category>.Filter.Eq(p => p.Id, categoryId);
            return await categoryCollection.Find(filter).FirstOrDefaultAsync();
        }

        //Ändra namnet på en kategori
        public async Task<bool> UpdateName(string categoryId, string newName)
        {
            var filter = Builders<Category>.Filter.Eq(p => p.Id, categoryId);
            var update = Builders<Category>.Update.Set(p => p.Name, newName);
            return (await categoryCollection.UpdateOneAsync(filter, update)).ModifiedCount > 0;
        }

        //Radera en kategori
        public async Task DeleteCategory(string categoryId)
        {
            var filter = Builders<Category>.Filter.Eq(p => p.Id, categoryId);
            await categoryCollection.DeleteOneAsync(filter);
        }
    }
}
