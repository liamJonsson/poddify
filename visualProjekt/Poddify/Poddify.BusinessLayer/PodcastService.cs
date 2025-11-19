using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poddify.DataLayer;
using Poddify.Models;

namespace Poddify.BusinessLayer
{
    public class PodcastService : IPodcastService
    {
        private readonly IPodcastRepository<Podcast> podcastRepo;

        public PodcastService(IPodcastRepository<Podcast> podcastRepo)
        {
            this.podcastRepo = podcastRepo;
        }
            //Lägger till Podcast i vår samling om den inte redan finns
        public async Task AddPodcastAsync(Podcast enPodcast)
        {
            string id = enPodcast.Id;
            if(podcastRepo.GetPodcastIdAsync(id) == null)
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
            if(podcastRepo.GetAllPodcastsAsync == null)
            {
                throw new ArgumentException("Felmeddelande: Finns inget i listan.");
            }
            else
            {
               return await podcastRepo.GetAllPodcastsAsync;               
            }
        }

        //public async Task<Podcast?> GetPodcastIdAsync(string id)


        //Uppdaterar namnet på en Podcast
        public async Task<bool> UpdateNameAsync(string id, string newTitle)
        {

            if (podcastRepo.GetPodcastIdAsync(id) == null)
            {
                throw new ArgumentException("Felmeddelande: id finns inte.");
            }
            else
            {
                return await podcastRepo.UpdateNameAsync(id, newTitle);               
            }
        }

        public async Task<bool> UpdateCategoryAsync(string id, string newCategoryId)
        {
            Podcast onePodcast = podcastRepo.GetPodcastIdAsync(id);
            if (onePodcast == null)
            {
                throw new ArgumentException("Felmeddelande: id finns inte.");
            }
            else
            {                  
             return await podcastRepo.UpdateCategoryAsync(id, newCategoryId);
            }
        }

        //Ta bort en podcast ur min samling
        public async Task DeletePodcastAsync(string enPodcastId)
        {
            Podcast onePodcast = podcastRepo.GetPodcastIdAsync(enPodcastId);
            if (onePodcast == null)
            {
                throw new ArgumentException("Felmeddelande: id finns inte.");
            }
            else
            {
                if (/*De klickar ja*/)
                {
                    await podcastRepo.DeletePodcastAsync(enPodcastId);
                }
                else
                {
                    //Användare trycker nej och fönstret stängs
                }
            }
        }
    }
}
