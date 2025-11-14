using MongoDB.Driver;
using Poddify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poddify.DataLayer
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly IMongoCollection<Episode> episodeCollection;

        //Visar en lista över alla avsnitt sparade i min samling
        public async Task<List<Episode>> GetAllEpisodes()
        {
            return await episodeCollection.Find(FilterDefinition<Episode>.Empty).ToListAsync();
        }

        //Hämtar ett specifik avsnitt
        public async Task<Episode?> GetSpecificEpisode(string id)
        {
            var filter = Builders<Episode>.Filter.Eq(p => p.Id, id);
            return await episodeCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}