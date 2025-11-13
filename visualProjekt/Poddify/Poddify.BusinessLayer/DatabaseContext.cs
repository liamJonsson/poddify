using MongoDB.Driver;
using Poddify.Models;

namespace Poddify.BusinessLayer
{
    public class DatabaseContext
    {
        private readonly IMongoCollection<Podcast> podcastKollektion;

        public DatabaseContext(string user, string password)
        {
            // Du kan lägga in try/catch här för att få bättre felmeddelanden vid uppstart
            var client = new MongoClient("mongodb+srv://" + user + ":" + password + "@poddify.wqdsssd.mongodb.net/?appName=Poddify");
            var _database = client.GetDatabase("PoddifyDB");
            podcastKollektion = _database.GetCollection<Podcast>("Podcasts");
        }
    }
}
