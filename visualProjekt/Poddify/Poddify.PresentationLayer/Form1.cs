using MongoDB.Bson;
using Poddify.BusinessLayer;
using Poddify.DataLayer;
using Poddify.Models;
using System.Threading.Tasks;

namespace Poddify.PresentationLayer
{
    public partial class Form1 : Form
    {
        private Service oneService;
        private List<Episode> allEpisodes;
        private PodcastClient oneClient;
        private Podcast onePodcast;

        public Form1()
        {
            InitializeComponent();
            oneClient = new PodcastClient(new HttpClient());
            oneService = new Service(oneClient);
            onePodcast = new Podcast();
        }

        private void mainFrame_Click(object sender, EventArgs e)
        {

        }

        private void rbtSpecificEpisode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void myCollection_Click(object sender, EventArgs e)
        {

        }

        private void lblEditCategory_Click(object sender, EventArgs e)
        {

        }

        private void lblGiveCategoryToPodcast_Click(object sender, EventArgs e)
        {

        }


        //----------------------------------------Börjar härifrån-----------------------------------//
        private async void btnGetPodcast_Click(object sender, EventArgs e)
        {
            try
            {
                onePodcast = await oneClient.GetPodcast(tbURL.Text);
                onePodcast.RssUrl = tbURL.Text;
                onePodcast.Id = ObjectId.GenerateNewId().ToString();
                
                allEpisodes = await oneService.GetAllEpisodes(onePodcast);

                lbAllEpisodes.Items.Clear();
                rbtSpecificEpisode.Clear();

                foreach (Episode oneEpisode in allEpisodes)
                {
                    lbAllEpisodes.Items.Add(oneEpisode);
                }

                lbAllEpisodes.DisplayMember = "Title";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Din sökväg gav ingen träff");
            }
        }

        private async void btnSavePodcast_Click(object sender, EventArgs e)
        {
            try
            {
                await oneService.AddPodcastAsync(onePodcast);
                MessageBox.Show("Podden sparades!");
            }
            catch
            {
                MessageBox.Show("Det gick inte att spara podden");
            }
        }
    }
}
