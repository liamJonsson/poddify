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
        public Form1(Service oneService)
        {
            this.oneService = oneService;
            InitializeComponent();
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
                var onePodcast = new Podcast();
                onePodcast.RssUrl = tbURL.Text;

                allEpisodes = await oneService.GetAllEpisodes(onePodcast);

                lbAllEpisodes.Items.Clear();
                rbtSpecificEpisode.Clear();

                foreach(Episode oneEpisode in allEpisodes)
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
    }
}
