using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface IEpisodeRepository
    {
        Task<List<Episode>> GetAllEpisodes();
        Task<Episode?> GetSpecificEpisode(string id);
    }
}
