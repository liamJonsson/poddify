using Poddify.BusinessLayer;
using Poddify.DataLayer;

namespace Poddify.PresentationLayer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            

            var dbLisa = new DatabaseContext("poddLisa", "poddLisaPassword");

            var dbLiam = new DatabaseContext("poddUser", "poddPassword");

            var dbMeja = new DatabaseContext("poddMeja", "poddMejaPassword");

            var dbIftin = new DatabaseContext("poddIftin", "poddIftinPassword");

            HttpClient http = new HttpClient();
            var client = new PodcastClient(http);
            var service = new Service(client);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(service));
        }
    }
}