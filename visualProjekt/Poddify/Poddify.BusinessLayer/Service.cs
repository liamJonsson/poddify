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
        public async Task AddPodcastAsync(Podcast enPodcast)
        {
            string id = enPodcast.Id;
            if (podcastRepo.GetPodcastIdAsync(id) == null)
            {
                await podcastRepo.AddPodcastAsync(enPodcast);
            }
            else
            {
                throw new ArgumentException("Felmeddelande: Kan inte lägga till Podd");
            }
        }

        //Hämtar alla Podcast i vår samling
        public async Task<List<Podcast?>> GetAllPodcastsAsync()
        {
            if (podcastRepo.GetAllPodcastsAsync() != null)
            {
                return await podcastRepo.GetAllPodcastsAsync();
            }
            else
            {
                throw new ArgumentException("Felmeddelande: Finns inget i listan.");
            }
        }

        public async Task<Podcast?> GetPodcastIdAsync(Podcast onePodcast)
        {
            if (await podcastRepo.GetPodcastIdAsync(onePodcast.Id) != null)
            {
                return onePodcast;
            }
            else
            {
                throw new ArgumentException("Felmeddelande: Kan inte hitta podden");
            }
        }
    }
}
