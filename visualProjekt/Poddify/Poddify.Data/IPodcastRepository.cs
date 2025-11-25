using Poddify.Models;


namespace Poddify.DataLayer
{
    public interface IPodcastRepository
    {
        Task AddPodcastAsync(Podcast onePodcast);
        Task<List<Podcast>> GetAllPodcastsAsync();
        Task<Podcast?> GetPodcastByRssUrlAsync(string rssUrl);
        Task<bool> UpdateNameAsync(string id, string newTitle);
        Task<bool> UpdateCategoryAsync(string id, string newCategoryId);
        Task DeletePodcastAsync(string enPodcastId);
    }
}
