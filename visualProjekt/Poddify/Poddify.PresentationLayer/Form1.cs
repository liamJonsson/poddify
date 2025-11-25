using MongoDB.Bson;
using Poddify.BusinessLayer;
using Poddify.DataLayer;
using Poddify.Models;
using System;
using System.Text.RegularExpressions;
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

            btnDeletePodcast.Enabled = false;
            tbPodcastTitle.Enabled = false;
            tbCategory.Enabled = false;

            showAllPodcasts();
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
                showAllPodcasts();

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

        //---------------------------------------Mina poddar-------------------------------------//

        //Visar alla podcasts i min samling
        private async void showAllPodcasts()
        {
            List<Podcast> allPodcasts = await oneService.GetAllPodcastsAsync();

            foreach (Podcast onePodcast in allPodcasts)
            {
                lbMyPodcasts.Items.Add(onePodcast);
            }
            lbMyPodcasts.DisplayMember = "Title";
        }

        // Ta bort HTML-taggar från en sträng
        private string StripHtml(string input)
        {
            input = input.Split("<hr")[0];
            return Regex.Replace(input, "<.*?>", "").Trim();
        }

        //Rensar listor och textboxar
        private void clearAllFields()
        {
            lbMyPodcasts.Items.Clear();
            lbEpisodesOfAPodcast.Items.Clear();
            rbtMoreInformationEpisode.Clear();
            tbEditName.Clear();
            tbEditCategoryName.Clear();
            showAllPodcasts();
        }

        //Visar alla avsnitt för den valda podden i min samling
        private async void lbMyPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Podcast selectedPodcast = (Podcast)lbMyPodcasts.SelectedItem;

                allEpisodes = await oneService.GetAllEpisodes(selectedPodcast);

                rbtMoreInformationEpisode.Clear();
                lbEpisodesOfAPodcast.Items.Clear();

                foreach (Episode oneEpisode in allEpisodes)
                {
                    lbEpisodesOfAPodcast.Items.Add(oneEpisode);
                }

                lbEpisodesOfAPodcast.DisplayMember = "Title";
                btnDeletePodcast.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Något gick fel när poddens avsnitt skulle visas");
                Console.WriteLine(ex.Message);
            }
        }

        //Visar mer information om det valda avsnittet
        private async void lbEpisodesOfAPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            Episode selectedEpisode = (Episode)lbEpisodesOfAPodcast.SelectedItem;

            string cleanDescription = StripHtml(selectedEpisode.Description);

            rbtMoreInformationEpisode.Text =
            $"{selectedEpisode.PublishDate} \n \n {selectedEpisode.Title} \n \n {cleanDescription} \n {selectedEpisode.Link}";
        }

        //Redigera namn på vald podd
        private async void btnEditName_Click(object sender, EventArgs e)
        {
            Podcast selectedPodcast = (Podcast)lbMyPodcasts.SelectedItem;

            if (selectedPodcast != null)
            {
                if (!tbEditName.Text.Equals(selectedPodcast.Title) && !string.IsNullOrWhiteSpace(tbEditName.Text))
                {
                    try
                    {
                        bool updated = await oneService.UpdateNameAsync(selectedPodcast.Id, tbEditName.Text);

                        if (updated)
                        {
                            clearAllFields();
                        }
                        else
                        {
                            MessageBox.Show("Tyvärr så uppdaterades inte namnet. Försök igen!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Något gick fel när poddens namn skulle redigeras");
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vänligen ange ett nytt namn");
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en podd att redigera");
            }
        }

        //Redigera kategori på vald podd
        private async void btnEditCategory_Click(object sender, EventArgs e)
        {
            Podcast selectedPodcast = (Podcast)lbMyPodcasts.SelectedItem;

            if (tbEditCategoryName.Text != "" && tbEditCategoryName.Text != selectedPodcast.CategoryId)
            {
                try
                {
                    bool updated = await oneService.UpdateCategoryAsync(selectedPodcast.Id, tbEditCategoryName.Text);

                    if (updated)
                    {
                        clearAllFields();
                    }
                    else
                    {
                        MessageBox.Show("Tyvärr så uppdaterades inte kategorin. Försök igen!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Något gick fel när poddens kategori skulle redigeras");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vänligen ange en ny kategori");
            }
        }

        //Raderar vald podd
        private async void btnDeletePodcast_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Vill du ta bort podden?",       // text
            "Bekräfta borttagning",          // titel
            MessageBoxButtons.YesNo,         // knappar
            MessageBoxIcon.Hand);            // ikon (valfritt)

            try
            {
                if (result == DialogResult.Yes)
                {
                    Podcast selectedPodcast = (Podcast)lbMyPodcasts.SelectedItem;
                    await oneService.DeletePodcastAsync(selectedPodcast.Id);
                }
                clearAllFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Något gick fel när podden skulle tas bort");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
