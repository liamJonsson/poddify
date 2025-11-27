using MongoDB.Driver;
using Poddify.Models;

namespace Poddify.DataLayer
{
    public class PodcastRepository : IPodcastRepository
    {
        private readonly IMongoCollection<Podcast> podcastCollection;

        public PodcastRepository(DatabaseContext db)
        {
            podcastCollection = db.podcastCollection;
        }

        //Lägger till i min samling (sparas i databasen)
        public async Task AddPodcastAsync(Podcast onePodcast, IClientSessionHandle session)
        {
            await podcastCollection.InsertOneAsync(session, onePodcast);
        }

        //Visar en lista över alla podcasts sparade i min samling
        public async Task<List<Podcast>> GetAllPodcastsAsync()
        {
            return await podcastCollection.Find(FilterDefinition<Podcast>.Empty).ToListAsync();
        }

        //Hämtar en specifik podcast via rss-url
        public async Task<Podcast?> GetPodcastByRssUrlAsync(string rssUrl)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.RssUrl, rssUrl);
            return await podcastCollection.Find(filter).FirstOrDefaultAsync();
        }

        //Ändra namnet på en podcast
        public async Task<bool> UpdateNameAsync(string id, string newTitle, IClientSessionHandle session)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.Id, id);
            var update = Builders<Podcast>.Update.Set(p => p.Title, newTitle);
            return (await podcastCollection.UpdateOneAsync(session, filter, update)).ModifiedCount > 0;
        }

        //Ändra kategorin på en podcast
        public async Task<bool> UpdateCategoryAsync(string id, string newCategoryId, IClientSessionHandle session)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.Id, id);
            var update = Builders<Podcast>.Update.Set(p => p.CategoryId, newCategoryId);
            return (await podcastCollection.UpdateOneAsync(session, filter, update)).ModifiedCount > 0;
        }

        //Tar bort en podcast från min samling
        public async Task DeletePodcastAsync(string enPodcastId, IClientSessionHandle session)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.Id, enPodcastId);
            await podcastCollection.DeleteOneAsync(session, filter);
        }

    }
}
