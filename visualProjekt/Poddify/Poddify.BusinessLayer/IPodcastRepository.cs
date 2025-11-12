using Poddify.Models;


namespace Poddify.BusinessLayer
{
    public interface IPodcastRepository
    {
        void AddPodcast(Podcast enPodcast);
        List<Podcast> GetAllPodcasts();
        Podcast? GetSpecificPodcast(string id);
        bool UpdateName(Podcast enPodcast);
        bool UpdateCategory(Category enCategory);
        bool DeletePodcast(Podcast enPodcast);
    }
}
