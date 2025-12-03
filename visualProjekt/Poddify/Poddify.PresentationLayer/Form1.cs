using MongoDB.Bson;
using MongoDB.Driver;
using Poddify.BusinessLayer;
using Poddify.DataLayer;
using Poddify.Models;
using System.Text.RegularExpressions;

namespace Poddify.PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly Service oneService;
        private readonly PodcastClient oneClient;
        private readonly DatabaseContext db;
        private List<Episode> allEpisodes;
        private List<Podcast> allPodcasts;
        private List<Category> allCategories;
        private Podcast onePodcast;
        

        public Form1()
        {
            InitializeComponent();
            //Instansierar nödvändiga fält för Serviceklassen
            oneClient = new PodcastClient(new HttpClient());
            db = new DatabaseContext();
            IPodcastRepository podcastRepo = new PodcastRepository(db);
            ICategoryRepository categoryRepo = new CategoryRepository(db);

            oneService = new Service(oneClient, podcastRepo, categoryRepo, db.Client);
            onePodcast = new Podcast();
            disableAllFields();
            LoadAllCategoriesAsync();
            LoadAllCategoriesComboBoxAsync();
        }

        private void disableAllFields()
        {
            btnDeletePodcast.Enabled = false;
            tbPodcastTitle.Enabled = false;
            tbCategory.Enabled = false;
            btnDeleteCategory.Enabled = false;
            btnSaveCategory.Enabled = false;
            btnSaveCreatedCategory.Enabled = false;
            btnGetPodcast.Enabled = false;
            btnSavePodcast.Enabled = false;
            tbEditName.Enabled = false;
            tbEditPodcastCategory.Enabled = false;
            tbEditCategoryName.Enabled = false;
            btnEditName.Enabled = false;
            btnEditCategory.Enabled = false;
            btnDeletePodcast.Enabled = false;
        }

        //---------------------------------------Startsida-------------------------------------//

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
                btnSavePodcast.Enabled = true;
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

                            if (await oneService.GetPodcastByRssUrlAsync(tbURL.Text) == null)
                            {
                                await oneService.AddPodcastAsync(onePodcast);

                                tbURL.Clear();
                                lbAllEpisodes.Items.Clear();
                                tbPodcastTitle.Clear();
                                tbCategory.Clear();
                                rbtSpecificEpisode.Clear();
                                btnGetPodcast.Enabled = false;
                                btnSavePodcast.Enabled = false;
                                tbPodcastTitle.Enabled = false;
                                tbCategory.Enabled = false;

                                MessageBox.Show("Podden sparades!");
                            }
                            else
                            {
                                MessageBox.Show("Det går inte att lägga till podden då den redan finns i din samling");
                            }
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
                await showAllPodcastsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Det gick inte att spara podden");
                Console.WriteLine(ex.Message);
            }
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
                    btnSaveCreatedCategory.Enabled = false;
                    MessageBox.Show("Kategorinamn får inte vara tomt");
                    return;
                }

                //Returnerar false och lägger till kategorin om den inte redan finns

                bool alreadyExists = await oneService.AddCategoryAsync(newCategoryName);

                if (alreadyExists)
                {
                    btnSaveCreatedCategory.Enabled = false;
                    MessageBox.Show("Kategorin finns redan i din lista");
                    return;
                }
                else
                {
                    await LoadAllCategoriesAsync();
                    await LoadAllCategoriesComboBoxAsync();
                    tbCreateCategory.Clear();
                    btnSaveCreatedCategory.Enabled = false;
                    MessageBox.Show("Kategorin sparades!");
                }
            }
            catch (Exception ex)
            {
                btnSaveCreatedCategory.Enabled = false;
                MessageBox.Show("Det gick inte att spara kategorin");
                Console.WriteLine(ex.Message);
            }
        }

        //Hämtar och visar kategorier i listan
        private async Task LoadAllCategoriesAsync()
        {
            try
            {
                lbMyCategories.Items.Clear();
                allCategories = await oneService.GetAllCategoriesAsync();
                foreach (Category oneCategory in allCategories)
                {
                    lbMyCategories.Items.Add(oneCategory.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid inläsning av kategorier: " + ex.Message);
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
                            clearAllFields();
                            await LoadAllCategoriesAsync();
                            await LoadAllCategoriesComboBoxAsync();                           

                            tbEditCategoryName.Clear();

                            btnSaveCreatedCategory.Enabled = false;
                            btnSaveCategory.Enabled = false;
                            btnDeleteCategory.Enabled = false;
                            tbEditCategoryName.Enabled = false;

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

                    clearAllFields();
                    await LoadAllCategoriesAsync();
                    await LoadAllCategoriesComboBoxAsync();

                    btnSaveCreatedCategory.Enabled = false;
                    btnSaveCategory.Enabled = false;
                    btnDeleteCategory.Enabled = false;
                    tbEditCategoryName.Enabled = false;

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
            tbEditCategoryName.Enabled = true;
        }

        private void tbCreateCategory_TextChanged(object sender, EventArgs e)
        {
            btnSaveCreatedCategory.Enabled = true;
        }

        private void tbURL_TextChanged(object sender, EventArgs e)
        {
            btnGetPodcast.Enabled = true;
        }

        //---------------------------------------Mina poddar-------------------------------------//

        //Visar alla podcasts i min samling
        private async Task showAllPodcastsAsync()
        {
            try
            {
                allPodcasts = await oneService.GetAllPodcastsAsync();
                allCategories = await oneService.GetAllCategoriesAsync();

                foreach (Podcast onePodcast in allPodcasts)
                {
                    string categoryId = onePodcast.CategoryId;
                    string categoryName = "*Okategoriserad*";

                    foreach (Category oneCategory in allCategories)
                    {
                        if (oneCategory.Id == categoryId)
                        {
                            categoryName = oneCategory.Name;
                            break;
                        }
                    }
                    lbMyPodcasts.Items.Add($"{onePodcast.Title} - {categoryName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Något gick fel när poddarna skulle visas");
            }
        }

        //Fyller filter-comboboxen med alla kategorier
        private async Task LoadAllCategoriesComboBoxAsync()
        {
            try
            {
                cbFilter.Items.Clear();
                cbFilter.Items.Add("Filtrera kategorier");
                allCategories = await oneService.GetAllCategoriesAsync();
                foreach (Category oneCategory in allCategories)
                {
                    cbFilter.Items.Add(oneCategory.Name);
                }
                cbFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid inläsning av kategorier: " + ex.Message);
            }
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
            tbEditPodcastCategory.Clear();
        }

        //Visar alla avsnitt för den valda podden i min samling
        private async void lbMyPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = lbMyPodcasts.SelectedIndex;
                Podcast selectedPodcast = allPodcasts[idx];

                allEpisodes = selectedPodcast.Episodes;

                rbtMoreInformationEpisode.Clear();
                lbEpisodesOfAPodcast.Items.Clear();

                foreach (Episode oneEpisode in allEpisodes)
                {
                    lbEpisodesOfAPodcast.Items.Add(oneEpisode);
                }

                lbEpisodesOfAPodcast.DisplayMember = "Title";

                btnDeletePodcast.Enabled = true;
                tbEditName.Enabled = true;
                tbEditPodcastCategory.Enabled = true;
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
            try
            {
                allPodcasts = await oneService.GetAllPodcastsAsync();

                foreach (Podcast onePodcast in allPodcasts)
                {
                    if (onePodcast.Title.Equals(tbEditName.Text))
                    {
                        MessageBox.Show("En podd med detta namn finns redan i din samling. Vänligen välj ett annat namn.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Något gick fel när poddens namn skulle redigeras");
                Console.WriteLine(ex.Message);
            }

            int idx = lbMyPodcasts.SelectedIndex;
            Podcast selectedPodcast = allPodcasts[idx];

            if (!tbEditName.Text.Equals(selectedPodcast.Title) && !string.IsNullOrWhiteSpace(tbEditName.Text))
            {
                try
                {
                    bool updated = await oneService.UpdateNameAsync(selectedPodcast.Id, tbEditName.Text);

                    if (updated)
                    {
                        clearAllFields();
                        await showAllPodcastsAsync();
                        tbEditName.Enabled = false;
                        tbEditPodcastCategory.Enabled = false;
                        btnEditName.Enabled = false;
                        btnEditCategory.Enabled = false;
                        btnDeletePodcast.Enabled = false;
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

        //Redigera kategori på vald podd
        private async void btnEditCategory_Click(object sender, EventArgs e)
        {
            int idx = lbMyPodcasts.SelectedIndex;
            Podcast selectedPodcast = allPodcasts[idx];

            string selectedPodcastId = selectedPodcast.Id;

            Category currentCategory = await oneService.GetCategoryByIdAsync(selectedPodcast.CategoryId);
            string currentCategoryName = "*Okategoriserad*";

            if (currentCategory != null)
            {
                currentCategoryName = currentCategory.Name;
            }

            Category newCategory = await oneService.GetCategoryByNameAsync(tbEditPodcastCategory.Text);

            if (newCategory != null)
            {
                string newCategoryId = newCategory.Id;
                string newCategoryName = newCategory.Name;

                if (!currentCategoryName.Equals(newCategoryName) && !string.IsNullOrWhiteSpace(tbEditPodcastCategory.Text))
                {
                    try
                    {
                        bool updated = await oneService.UpdateCategoryAsync(selectedPodcastId, newCategoryId);

                        if (updated)
                        {
                            clearAllFields();
                            await showAllPodcastsAsync();
                            tbEditName.Enabled = false;
                            tbEditPodcastCategory.Enabled = false;
                            btnEditName.Enabled = false;
                            btnEditCategory.Enabled = false;
                            btnDeletePodcast.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Tyvärr så uppdaterades inte kategorin!");
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
                    MessageBox.Show("Du måste välja en ny kategori!");
                }
            }
            else
            {
                MessageBox.Show("Det finns ingen kategori med detta namn!");
            }
        }

        //Raderar vald podd
        private async void btnDeletePodcast_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Vill du ta bort podden?",
            "Bekräfta borttagning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Hand);

            try
            {
                if (result == DialogResult.Yes)
                {
                    int idx = lbMyPodcasts.SelectedIndex;
                    Podcast selectedPodcast = allPodcasts[idx];

                    await oneService.DeletePodcastAsync(selectedPodcast.Id);
                }
                clearAllFields();
                await showAllPodcastsAsync();
                tbEditName.Enabled = false;
                tbEditPodcastCategory.Enabled = false;
                btnDeletePodcast.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Något gick fel när podden skulle tas bort");
                Console.WriteLine(ex.Message);
            }
        }

        private async void btnSort_Click(object sender, EventArgs e)
        {
            clearAllFields();
            List<Podcast> sortedPodcasts = await oneService.GetPodcastsSortedByCategoryNameAsync();

            foreach (Podcast oneSortedPodcast in sortedPodcasts)
            {
                string categoryId = oneSortedPodcast.CategoryId;
                string categoryName = "*Okategoriserad*";

                foreach (Category oneCategory in allCategories)
                {
                    if (oneCategory.Id == categoryId)
                    {
                        categoryName = oneCategory.Name;
                        break;
                    }
                }

                lbMyPodcasts.Items.Add($"{oneSortedPodcast.Title} - {categoryName}");
            }
        }

        private void tbEditName_TextChanged(object sender, EventArgs e)
        {
            btnEditName.Enabled = true;
        }

        private void tbEditPodcastCategory_TextChanged(object sender, EventArgs e)
        {
            btnEditCategory.Enabled = true;
        }

        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbFilter.SelectedIndex;
            clearAllFields();

            if (idx == 0)
            {
                await showAllPodcastsAsync();
            }
            else
            {
                Category selectedCategory = allCategories[idx - 1];
                foreach (Podcast onePodcast in allPodcasts)
                {
                    if (onePodcast.CategoryId == selectedCategory.Id)
                    {
                        lbMyPodcasts.Items.Add($"{onePodcast.Title} - {selectedCategory.Name}");
                    }
                }
            }

        }
    }
}

