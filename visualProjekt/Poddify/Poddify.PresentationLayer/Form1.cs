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
            btnDeleteCategory.Enabled = false;
            btnSaveCategory.Enabled = false;
            btnSaveCreatedCategory.Enabled = false;

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

        //Startsida

        //RssUrl + mina kategorier

        //Hämtar podcast via URL
        private async void btnGetPodcast_Click(object sender, EventArgs e)
        {
            try
            {
                lbAllEpisodes.Items.Clear();
                rbtSpecificEpisode.Clear();

                onePodcast = await oneClient.GetPodcast(tbURL.Text);
                onePodcast.RssUrl = tbURL.Text;
                onePodcast.Id = ObjectId.GenerateNewId().ToString();

                allEpisodes = await oneService.GetAllEpisodes(onePodcast);

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

        //Sparar podcasten till min samling om kategorin finns och är giltig
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
                        MessageBox.Show("Ett fel har inträffat");
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vänligen välj en kategori för att kunna spara podden");
                }
                clearAllFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Det gick inte att spara podden");
                Console.WriteLine(ex.Message);
            }
        }

        //Fyller kategorilistan när sidan laddas
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

        //Visar information om det valda avsnittet
        private void lbAllEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Episode selectedEpisode = (Episode)lbAllEpisodes.SelectedItem;

            string cleanDescription = StripHtml(selectedEpisode.Description);

            rbtSpecificEpisode.Text = $"{selectedEpisode.PublishDate} \n \n {selectedEpisode.Title} \n \n {cleanDescription} \n \n {selectedEpisode.Link} ";
        }

        //Skapar en ny kategori
        private async void btnSaveCreatedCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string newCategoryName = tbCreateCategory.Text;

                if (string.IsNullOrWhiteSpace(newCategoryName))
                {
                    MessageBox.Show("Kategorinamn får inte vara tomt");
                    return;
                }

                //Returnerar false och lägger till kategorin om den inte redan finns

                bool alreadyExists = await oneService.AddCategoryAsync(newCategoryName);

                if (alreadyExists)
                {
                    MessageBox.Show("Kategorin finns redan i din lista");
                    return;
                }

                else
                {
                    await LoadAllCategoriesAsync();

                    tbCreateCategory.Clear();

                    btnSaveCreatedCategory.Enabled = false;

                    MessageBox.Show("Kategorin sparades!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Det gick inte att spara kategorin");
                Console.WriteLine(ex.Message);
            }
        }

        //Hämtar och visar kategorier i listan
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

        //Redigera namn på vald kategori
        private async void btnSaveCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = (string)lbMyCategories.SelectedItem;
            Category oneCategory = await oneService.GetCategoryByNameAsync(selectedCategory);

            if (oneCategory != null)
            {
                string updatedCategoryName = tbEditCategoryName.Text;

                if (!string.IsNullOrWhiteSpace(updatedCategoryName) && !updatedCategoryName.Equals(oneCategory.Name))
                {
                    try
                    {
                        bool updated = await oneService.UpdateCategoryNameAsync(oneCategory.Id, updatedCategoryName);

                        if (updated)
                        {

                            

                            await LoadAllCategoriesAsync();

                            tbEditCategoryName.Clear();

                            btnSaveCategory.Enabled = false;
                            btnDeleteCategory.Enabled = false;

                            MessageBox.Show("Kategorinamnet har uppdaterats!");
                        }
                        else
                        {
                            MessageBox.Show("En annan kategori har redan detta namn. Välj ett nytt!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kunde inte uppdatera kategorinamnet");
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vänligen ange ett giltigt kategorinamn");
                }
            }
        }

        private async void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lbMyCategories.SelectedItem == null)
            {
                MessageBox.Show("Markera kategorin du vill ändra namnet på");
                return;
            }

            var result = MessageBox.Show(
                "Vill du verkligen ta bort kategorin?",
                "Bekräfta borttagning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Hand);

            try
            {

                if (result == DialogResult.Yes)
                {
                    string selectedCategory = (string)lbMyCategories.SelectedItem;
                    Category oneCategory = await oneService.GetCategoryByNameAsync(selectedCategory);

                    await oneService.DeleteCategoryAsync(oneCategory.Id);
               
                    LoadAllCategoriesAsync();

                    btnSaveCategory.Enabled = false;
                    btnDeleteCategory.Enabled = false;

                    MessageBox.Show("Kategorin har raderats");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Något gick fel när kategorin skulle tas bort");
                Console.WriteLine(ex.Message);
            }

        }

        private void lbMyCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteCategory.Enabled = true;
            btnSaveCategory.Enabled = true;
        }

        private void tbCreateCategory_TextChanged(object sender, EventArgs e)
        {
            btnSaveCreatedCategory.Enabled = true;
        }
    }
}

