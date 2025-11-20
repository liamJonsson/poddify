using Poddify.DataLayer;
using Poddify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poddify.BusinessLayer
{
    public class Service
    {
        private PodcastClient podcastClient;
        private PodcastRepository podcastRepo;
        private CategoryRepository categoryRepo;

        public Service(PodcastClient podcastClient)
        {
            this.podcastClient = podcastClient;
        }

        public async Task<List<Episode>> GetAllEpisodes(Podcast onePodcast)
        {
            var podcast = await podcastClient.GetPodcast(onePodcast.RssUrl);

            var episodes = podcast.Episodes;

            foreach (var episode in episodes)
            {
                episode.PodcastId = onePodcast.Id;
                //Sätter ett nytt unikt id för episoden eftersom vi inte kan garantera att id:t som genereras är unikt
                episode.Id = onePodcast.Id + "+" + episode.Id;
            }
            return episodes;
        }

        //Lägger till en podcast i min samling
        public async Task AddPodcastAsync(Podcast onePodcast)
        {
            var existing = await podcastRepo.GetPodcastIdAsync(onePodcast.Id);
            if (existing == null)
            {
                await podcastRepo.AddPodcastAsync(onePodcast);
            }
            else
            {
                throw new ArgumentException("Felmeddelande: Kan inte lägga till Podd");
            }
        }

        //Hämtar alla Podcast i vår samling
        public async Task<List<Podcast>> GetAllPodcastsAsync()
        {
            return await podcastRepo.GetAllPodcastsAsync();
        }

        public async Task<Podcast> GetPodcastIdAsync(string id)
        {
            return await podcastRepo.GetPodcastIdAsync(id);
        }

        public async Task<bool> UpdateNameAsync(string id, string newTitle)
        {
            return await UpdateNameAsync(id, newTitle);
        }

        public async Task<bool> UpdateCategoryAsync(string id, string newCategoryId)
        {
            var existing = categoryRepo.GetCategoryIdAsync(newCategoryId);
            if(existing != null)
            {
                return await podcastRepo.UpdateCategoryAsync(id, newCategoryId);
            }
            return false;
        }

        public async Task DeletePodcastAsync(string enPodcastId)
        {
            await podcastRepo.DeletePodcastAsync(enPodcastId);
        }
    }
}
