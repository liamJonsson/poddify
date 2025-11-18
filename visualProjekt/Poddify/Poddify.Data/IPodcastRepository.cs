using Poddify.Models;


namespace Poddify.DataLayer
{
    public interface IPodcastRepository
    {
        Task AddPodcastAsync(Podcast enPodcast);
        Task<List<Podcast?>> GetAllPodcastsAsync();
        Task<Podcast?> GetPodcastIdAsync(string id);
        Task<bool> UpdateNameAsync(string id, string newTitle);
        Task<bool> UpdateCategoryAsync(string id, string newCategoryId);
        Task DeletePodcastAsync(string enPodcastId);
    }
}
