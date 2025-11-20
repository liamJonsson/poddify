using Poddify.Models;

namespace Poddify.DataLayer
{
    public interface IEpisodeRepository
    {
        //Task<List<Episode>> GetAllEpisodesAsync();
        Task<Episode> GetEpisodeByIdAsync(string id);
    }
}
