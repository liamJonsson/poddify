using MongoDB.Driver;
using Poddify.Models;
using System;

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

        // Publik metod som Program förväntar sig
        public IMongoCollection<Podcast> GetPodcastsCollection()
        {
            return podcastKollektion;
        }

        // Alternativt: expose property
        // public IMongoCollection<Podcast> Podcasts => podcastKollektion;
    }
}
