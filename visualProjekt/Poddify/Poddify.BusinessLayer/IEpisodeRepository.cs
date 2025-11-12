using Poddify.Models;

namespace Poddify.BusinessLayer
{
    public interface IEpisodeRepository
    {
        List<Episode> GetAllEpisodes();
        Episode? GetSpecificEpisode(string id);
    }
}
