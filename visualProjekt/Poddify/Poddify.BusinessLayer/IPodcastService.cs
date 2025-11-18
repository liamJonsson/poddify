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
        Task AddPodcastAsync(Podcast enPodcast);
        Task<List<Podcast?>> GetAllPodcastsAsync();
        Task<Podcast?> GetPodcastIdAsync(string id);
        Task<bool> UpdateNameAsync(string id, string newTitle);
        Task<bool> UpdateCategoryAsync(string id, string newCategoryId);
        Task DeletePodcastAsync(string enPodcastId);
    }
}
