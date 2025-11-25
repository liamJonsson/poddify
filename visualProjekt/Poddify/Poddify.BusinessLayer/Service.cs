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
        private DatabaseContext db = new DatabaseContext();
        private PodcastClient podcastClient;
        private PodcastRepository podcastRepo;
        private CategoryRepository categoryRepo;
        public Service(PodcastClient podcastClient)
        {
            this.podcastClient = podcastClient;
            podcastRepo = new PodcastRepository(db);
            categoryRepo = new CategoryRepository(db); //db för att å den att fungera
        }

        //------------------- Rssflöde ------------------//

        //Hämtar alla episoder från en podcast via dess rss-url
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

        //------------------- Podcastmetoder ------------------//

        //Lägger till en podcast i min samling
        public async Task AddPodcastAsync(Podcast onePodcast)
        {
            /*Podcast existing = await podcastRepo.GetPodcastByIdAsync(onePodcast.Id);*/

            Podcast existing = await podcastRepo.GetPodcastByRssUrlAsync(onePodcast.RssUrl);

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

        public async Task<Podcast?> GetPodcastByRssUrlAsync(string rssUrl)
        {
            return await podcastRepo.GetPodcastByRssUrlAsync(rssUrl);
        }

        //Uppdaterar namnet på en podcast
        public async Task<bool> UpdateNameAsync(string id, string newTitle)
        {
            return await podcastRepo.UpdateNameAsync(id, newTitle);
        }

        //Uppdaterar kategorin för en podcast
        public async Task<bool> UpdateCategoryAsync(string id, string newCategoryId)
        {
            var existing = categoryRepo.GetCategoryByIdAsync(newCategoryId);
            if (existing != null)
            {
                return await podcastRepo.UpdateCategoryAsync(id, newCategoryId);
            }
            return false;
        }

        //Raderar en podcast
        public async Task DeletePodcastAsync(string enPodcastId)
        {
            await podcastRepo.DeletePodcastAsync(enPodcastId);
        }

        //------------------- Kategorimetoder ------------------//

        //Lägger till en kategori
        public async Task<bool> AddCategoryAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return true;
            }
            else
            {
                var existing = await categoryRepo.GetCategoryByNameAsync(name);

                if(existing != null)
                {
                    return true;
                }
                else
                {
                    await categoryRepo.AddCategoryAsync(name);
                    return false;
                }
            }
        }

        //Hämtar alla kategorier
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await categoryRepo.GetAllCategoriesAsync();
        }

        //Hämtar en specifik kategori via namn
        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await categoryRepo.GetCategoryByNameAsync(name);
        }

        //Hämtar en specifik kategori via id
        public async Task<Category> GetCategoryByIdAsync(string categoryId)
        {
            return await categoryRepo.GetCategoryByIdAsync(categoryId);
        }

        //Uppdaterar namnet på en kategori
        public async Task<bool> UpdateCategoryNameAsync(string categoryId, string newName)
        {
            var existing = await categoryRepo.GetCategoryByNameAsync(newName);

            if (existing == null)
            {
                await categoryRepo.UpdateCategoryNameAsync(categoryId, newName);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Raderar en kategori
        public async Task DeleteCategoryAsync(string categoryId)
        {
            await categoryRepo.DeleteCategoryAsync(categoryId);
        }
    }
}
