using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface IEpisodeRepository
    {
        List<Episode> GetAllEpisodes();
        Episode? GetSpecificEpisode(string id);
    }
}
