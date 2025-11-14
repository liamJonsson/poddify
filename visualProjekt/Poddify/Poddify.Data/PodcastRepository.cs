using MongoDB.Driver;
using Poddify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poddify.DataLayer
{
    public class PodcastRepository : IPodcastRepository
    {
        private readonly IMongoCollection<Podcast> podcastCollection;

        //Lägger till i min samling (sparas i databasen)
        public async Task AddPodcast(Podcast enPodcast)
        {
            await podcastCollection.InsertOneAsync(enPodcast);
        }

        //Visar en lista över alla podcasts sparade i min samling
        public async Task<List<Podcast>> GetAllPodcasts()
            {
                return await podcastCollection.Find(FilterDefinition<Podcast>.Empty).ToListAsync();
            }

        //Hämtar en specifik podcast
        public async Task<Podcast?> GetSpecificPodcast(string id)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.Id, id);
            return await podcastCollection.Find(filter).FirstOrDefaultAsync();
        }

        //Ändra namnet på en podcast
        public async Task<bool> UpdateName(Podcast enPodcast)
        {
        }



    }
}
