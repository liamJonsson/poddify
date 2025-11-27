using System.ServiceModel.Syndication;
using System.Xml;
using Poddify.Models;

namespace Poddify.DataLayer
{
    public class PodcastClient
    {
        private readonly HttpClient oneHttpClient;

        public PodcastClient(HttpClient oneHttpClient)
        {
            this.oneHttpClient = oneHttpClient;
        }

        //Hämtar poddar från ett rss-feed

        public async Task<Podcast> GetPodcast(string rssUrl)
        {
            using Stream rssStream = await this.oneHttpClient.GetStreamAsync(rssUrl);
            using XmlReader myXmlReader = XmlReader.Create(rssStream);

            SyndicationFeed rssFeed = SyndicationFeed.Load(myXmlReader);

            List<Episode> episodes = new List<Episode>();

            foreach (SyndicationItem item in rssFeed.Items)
            {
                episodes.Add(new Episode
                {
                    Title = item.Title.Text,
                    Description = item.Summary.Text,
                    PublishDate = item.PublishDate.DateTime,
                    Link = item.Links.First().Uri.ToString()
                });
            }

            Podcast onePodcast = new Podcast
            {
                Title = rssFeed.Title?.Text,
                RssUrl = rssUrl,
                Episodes = episodes
            };

            return onePodcast;
        }
    }
}
