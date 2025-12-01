using MongoDB.Driver;
using Poddify.Models;

namespace Poddify.DataLayer
{
    public class DatabaseContext
    {
        public IMongoClient Client { get; }

        internal readonly IMongoCollection<Podcast> podcastCollection;
        internal readonly IMongoCollection<Category> categoryCollection;

        public DatabaseContext()
        {
            Client = new MongoClient("mongodb+srv://poddUser:poddPassword@poddify.wqdsssd.mongodb.net/?appName=Poddify");
            var _database = Client.GetDatabase("Opponering");
            podcastCollection = _database.GetCollection<Podcast>("Podcasts");
            categoryCollection = _database.GetCollection<Category>("Categories");
        }
    }
}
