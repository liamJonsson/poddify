using MongoDB.Driver;
using Poddify.Models;


namespace Poddify.DataLayer
{
    public interface IPodcastRepository
    {
        Task AddPodcastAsync(Podcast onePodcast, IClientSessionHandle session);
        Task<List<Podcast>> GetAllPodcastsAsync();
        Task<Podcast?> GetPodcastByRssUrlAsync(string rssUrl);
        Task<bool> UpdateNameAsync(string id, string newTitle, IClientSessionHandle session);
        Task<bool> UpdateCategoryAsync(string id, string newCategoryId, IClientSessionHandle session);
        Task DeletePodcastAsync(string enPodcastId, IClientSessionHandle session);
    }
}
