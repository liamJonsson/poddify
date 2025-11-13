using MongoDB.Driver;
using Poddify.Models;

namespace Poddify.BusinessLayer
{
    public class DatabaseContext
    {
        private readonly IMongoCollection<Podcast> podcastKollektion;

        public DatabaseContext(string connectionString = "mongodb+srv://poddUser:poddPassword@poddify.wqdsssd.mongodb.net/?appName=Poddify")
        {
            // Du kan lägga in try/catch här för att få bättre felmeddelanden vid uppstart
            var client = new MongoClient(connectionString);
            var _database = client.GetDatabase("PoddifyDB");
            podcastKollektion = _database.GetCollection<Podcast>("Podcasts");
        }
    }
}
