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

        public Service(PodcastClient podcastClient) 
        { 
            this.podcastClient = podcastClient;
        }

        public async Task<List<Episode>> GetAllEpisodes(Podcast onePodcast)
        {
            var episodes = await podcastClient.GetPodcast(onePodcast.RssUrl);

            foreach (var episode in episodes)
            {
                episode.PodcastId = onePodcast.Id;
                //Sätter ett nytt unikt id för episoden eftersom vi inte kan garantera att id:t som genereras är unikt
                episode.Id = onePodcast.Id + "+" + episode.Id;
            }
            return episodes;
        }
    }
}
