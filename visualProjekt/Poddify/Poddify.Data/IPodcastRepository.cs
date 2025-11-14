using Poddify.Models;


namespace Poddify.DataLayer
{
    public interface IPodcastRepository
    {
        async Task AddPodcast(Podcast enPodcast);
        List<Podcast> GetAllPodcasts();
        Podcast? GetSpecificPodcast(string id);
        bool UpdateName(Podcast enPodcast);
        bool UpdateCategory(Category enCategory);
        bool DeletePodcast(Podcast enPodcast);
    }
}
