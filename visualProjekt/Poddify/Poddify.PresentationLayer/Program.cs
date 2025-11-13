using MongoDB.Driver;
using Poddify.DataLayer;
using Poddify.Models;

namespace Poddify.PresentationLayer
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dbService = new DatabaseContext();
                var podcasts = dbService.GetPodcastsCollection();

                // Testa att hämta dokument
                var lista = podcasts.Find(FilterDefinition<Podcast>.Empty).ToList();

                Console.WriteLine("✅ Anslutningen till MongoDB fungerade!");
                Console.WriteLine($"Antal podcasts i databasen: {lista.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Kunde inte ansluta till databasen:");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}