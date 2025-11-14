using Poddify.Models;


namespace Poddify.DataLayer
{
    public interface IPodcastRepository
    {
        Task AddPodcast(Podcast enPodcast);
        Task<List<Podcast?>> GetAllPodcasts();
        Task<Podcast?> GetSpecificPodcast(string id);
        Task<bool> UpdateName(string id, string newTitle);
        Task<bool> UpdateCategory(string id, string newCategoryId);
        Task DeletePodcast(string enPodcastId);
    }
}
