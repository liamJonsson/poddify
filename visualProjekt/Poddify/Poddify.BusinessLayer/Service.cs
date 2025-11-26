using MongoDB.Driver;
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
        private DatabaseContext db;
        private PodcastClient podcastClient;
        private PodcastRepository podcastRepo;
        private CategoryRepository categoryRepo;
        private readonly IMongoClient client;
        public Service(PodcastClient podcastClient)
        {
            db = new DatabaseContext();
            this.podcastClient = podcastClient;
            podcastRepo = new PodcastRepository(db);
            categoryRepo = new CategoryRepository(db); //db för att å den att fungera
            client = db.Client;
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
        public async Task AddPodcastAsync(Podcast onePodcast) //Insert transaction
        {
            using var session = await client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var existing = await podcastRepo.GetPodcastByRssUrlAsync(onePodcast.RssUrl);

                if (existing != null)
                {
                    Console.WriteLine("Felmeddelande: Kan inte lägga till Podd");
                }

                await podcastRepo.AddPodcastAsync(onePodcast, session);

                await session.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await session.AbortTransactionAsync();
                Console.WriteLine("Transaktionen misslyckades och har avbrutits.");
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
        public async Task<bool> UpdateNameAsync(string id, string newTitle) //Update transaction
        {
            using var session = client.StartSession();
            session.StartTransaction();

            try
            {
                var result = await podcastRepo.UpdateNameAsync(id, newTitle, session);
                await session.CommitTransactionAsync();
                return result;
            }
            catch
            {
                await session.AbortTransactionAsync();
                return false;
            }
        }

        //Uppdaterar kategorin för en podcast
        public async Task<bool> UpdateCategoryAsync(string id, string newCategoryId) //Updatetransaction
        {
            using var session = db.Client.StartSession();
            session.StartTransaction();

            try
            {
                var existingCategory = await categoryRepo.GetCategoryByIdAsync(newCategoryId);
                if (existingCategory == null)
                {
                    await session.AbortTransactionAsync();
                    return false;
                }

                var result = await podcastRepo.UpdateCategoryAsync(id, newCategoryId, session);
                await session.CommitTransactionAsync();
                return result;
            }
            catch
            {
                await session.AbortTransactionAsync();
                return false;
            }
        }

        //Raderar en podcast
        public async Task DeletePodcastAsync(string enPodcastId) //Delete transaction
        {
            using var session = client.StartSession();
            session.StartTransaction();

            try
            {
                await podcastRepo.DeletePodcastAsync(enPodcastId, session);
                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
            }
        }

        //------------------- Kategorimetoder ------------------//

        //Lägger till en kategori
        public async Task<bool> AddCategoryAsync(string name) //Insert transaction
        {
            using var session = await client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var existing = await categoryRepo.GetCategoryByNameAsync(name);
                if (existing != null)
                {
                    Console.WriteLine("Felmeddelande: Kan inte lägga till kategorin, den finns redan");
                    await session.AbortTransactionAsync();
                    return true;
                }

                await categoryRepo.AddCategoryAsync(name, session);

                await session.CommitTransactionAsync();
                return false;
            }
            catch (Exception)
            {
                await session.AbortTransactionAsync();
                Console.WriteLine("Transaktionen misslyckades och har avbrutits.");
                return true;
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
        public async Task<bool> UpdateCategoryNameAsync(string categoryId, string newName) //Update transaction
        {          
            using var session = client.StartSession();
            session.StartTransaction();

            try
            {
                var existing = await categoryRepo.GetCategoryByNameAsync(newName);
                if (existing != null)
                {
                    await session.AbortTransactionAsync();
                    return false;
                }

                var updated = await categoryRepo.UpdateCategoryNameAsync(categoryId, newName, session);
                await session.CommitTransactionAsync();
                return updated;
            }
            catch
            {
                await session.AbortTransactionAsync();
                return false;
            }
        }

        //Raderar en kategori
        public async Task DeleteCategoryAsync(string categoryId) //Delete transaction
        {
            using var session = client.StartSession();
            session.StartTransaction();

            try
            {
                await categoryRepo.DeleteCategoryAsync(categoryId, session);

                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
            }
        }

     //---------------- För sortering av podcasts ----------------//

        //Hämtar alla podcasts sorterade efter kategorinamn
        public async Task<List<Podcast>> GetPodcastsSortedByCategoryNameAsync()
        {
            var podcasts = await podcastRepo.GetAllPodcastsAsync();
            var categories = await categoryRepo.GetAllCategoriesAsync();
            return podcasts.OrderBy(p => categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? "").ToList();
        }
    }
}
