using MongoDB.Driver;
using Poddify.Models;

namespace Poddify.DataLayer
{
    public class DatabaseContext
    {
        internal readonly IMongoCollection<Podcast> podcastCollection;
        private readonly IMongoCollection<Category> categoryCollection;


        public DatabaseContext()
        {
            // Du kan lägga in try/catch här för att få bättre felmeddelanden vid uppstart
            var client = new MongoClient("mongodb+srv://poddUser:poddPassword@poddify.wqdsssd.mongodb.net/?appName=Poddify");
            var _database = client.GetDatabase("PoddifyDB");
            podcastCollection = _database.GetCollection<Podcast>("Podcasts");
            categoryCollection = _database.GetCollection<Category>("Categories");
        }
    }
}
