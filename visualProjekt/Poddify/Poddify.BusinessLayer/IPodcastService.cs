using Poddify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poddify.BusinessLayer
{
    public interface IPodcastService
    {
        Task AddPodcast(Podcast enPodcast);
        Task<List<Podcast?>> GetAllPodcasts();
        Task<Podcast?> GetSpecificPodcast(string id);
        Task<bool> UpdateName(string id, string newTitle);
        Task<bool> UpdateCategory(string id, string newCategoryId);
        Task DeletePodcast(string enPodcastId);
    }
}
