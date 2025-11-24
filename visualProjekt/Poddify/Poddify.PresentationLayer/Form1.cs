using MongoDB.Bson;
using Poddify.BusinessLayer;
using Poddify.DataLayer;
using Poddify.Models;
using System;
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

            tbPodcastTitle.Enabled = false;
            tbCategory.Enabled = false;
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

                tbPodcastTitle.Enabled = true;
                tbCategory.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Din sökväg gav ingen träff");
                Console.WriteLine(ex.Message);


            }


        }

        private async void btnSavePodcast_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPodcastTitle.Text != "")
                {
                    onePodcast.Title = tbPodcastTitle.Text;
                }

                if (tbCategory.Text != "")
                {
                    try
                    {
                        var existingCategory = await oneService.GetCategoryByNameAsync(tbCategory.Text);
                        Console.WriteLine(existingCategory);

                        if (existingCategory != null)
                        {
                            onePodcast.CategoryId = existingCategory.Id;
                            await oneService.AddPodcastAsync(onePodcast);
                            MessageBox.Show("Podden sparades!");
                            tbURL.Clear();
                            lbAllEpisodes.Items.Clear();
                            tbPodcastTitle.Clear();
                            tbCategory.Clear();
                            rbtSpecificEpisode.Clear();
                        }

                        else
                        {
                            MessageBox.Show("Podden kunde inte sparas eftersom kategorin inte finns i din lista och kunde inte tilldelas");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Fel i kategorikontrollen: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Vänligen välj en kategori för att kunna spara podden");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Det gick inte att spara podden");
                Console.WriteLine(ex.Message);
            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadAllCategoriesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid inläsning av kategorier: " + ex.Message);
            }
        }

        private void lblInformation_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbAllEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Episode selectedEpisode = (Episode)lbAllEpisodes.SelectedItem;

            rbtSpecificEpisode.Text = $"{selectedEpisode.Title} \n {selectedEpisode.Description} \n {selectedEpisode.PublishDate}";
        }

        private async void btnSaveCreatedCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string newCategory = tbCreateCategory.Text;

                if(string.IsNullOrWhiteSpace(newCategory))
                {
                    MessageBox.Show("Kategorinamn får inte vara tomt");
                    return;
                }

                bool alreadyExists = await oneService.AddCategoryAsync(newCategory);

                if (alreadyExists)
                {
                    MessageBox.Show("Kategorin finns redan i din lista");
                    return;
                }
                await LoadAllCategoriesAsync();
                MessageBox.Show("Kategorin sparades!");
                tbCreateCategory.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Det gick inte att spara kategorin");
                Console.WriteLine(ex.Message);
            }

        }

        private async Task LoadAllCategoriesAsync()
        {
            lbMyCategories.Items.Clear();
            var categories = await oneService.GetAllCategoriesAsync();
            foreach (Category oneCategory in categories)
            {
                lbMyCategories.Items.Add(oneCategory.Name);
            }

        }
    }
}
