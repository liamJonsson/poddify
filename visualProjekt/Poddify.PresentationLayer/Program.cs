using System;
using System.Linq;
using MongoDB.Driver;
using Poddify.BusinessLayer;
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

                // Hämta alla dokument (synkront)
                var lista = podcasts.Find(FilterDefinition<Podcast>.Empty).ToList();

                Console.WriteLine("✅ Anslutningen till MongoDB fungerade!");
                Console.WriteLine($"Antal podcasts i databasen: {lista.Count}");
                foreach (var p in lista)
                {
                    Console.WriteLine($"- {p.Id} | {p.Name} | {p.RssUrl}");
                }
            }
            catch (MongoAuthenticationException ex)
            {
                Console.WriteLine("❌ Autentiseringsfel: " + ex.Message);
                Console.WriteLine(ex.ToString());
            }
            catch (MongoConfigurationException ex)
            {
                Console.WriteLine("❌ Konfigurationsfel: " + ex.Message);
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Annat fel: " + ex.Message);
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Tryck Enter för att avsluta...");
            Console.ReadLine();
        }
    }
}