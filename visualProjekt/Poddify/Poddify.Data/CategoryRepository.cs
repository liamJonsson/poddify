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
        public async Task AddCategoryAsync(string name)
        {
            var newCategory = new Category { Name = name };
            await categoryCollection.InsertOneAsync(newCategory);
        }


        //Hämtar alla kategorier
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await categoryCollection.Find(FilterDefinition<Category>.Empty).ToListAsync();
        }

        //Hämtar en specifik kategori via namn
        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Name, name);
            return await categoryCollection.Find(filter).FirstOrDefaultAsync();
        }

        //Hämtar en specifik kategori
        public async Task<Category> GetCategoryByIdAsync(string categoryId)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, categoryId);
            return await categoryCollection.Find(filter).FirstOrDefaultAsync();
        }

        //Ändra namnet på en kategori
        public async Task<bool> UpdateCategoryNameAsync(string categoryId, string newName)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, categoryId);
            var update = Builders<Category>.Update.Set(c => c.Name, newName);
            return (await categoryCollection.UpdateOneAsync(filter, update)).ModifiedCount > 0;
        }

        //Radera en kategori
        public async Task DeleteCategoryAsync(string categoryId)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, categoryId);
            await categoryCollection.DeleteOneAsync(filter);
        }
    }
}
