namespace Poddify.PresentationLayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            mainFrame = new TabPage();
            textBox2 = new TextBox();
            lblGiveCategoryToPodcast = new Label();
            tbPodcastTitle = new TextBox();
            lblNamePodcast = new Label();
            btnSavePodcast = new Button();
            rbtSpecificEpisode = new RichTextBox();
            lbAllEpisodes = new ListBox();
            btnGetPodcast = new Button();
            tbURL = new TextBox();
            lblURL = new Label();
            myCollection = new TabPage();
            lblInformation = new Label();
            btnDeletePodcast = new Button();
            btnSaveCreatedCategory = new Button();
            tbCreateCategory = new TextBox();
            lblCreateCategory = new Label();
            label1 = new Label();
            tbEditCategoryName = new TextBox();
            lblEditCategoryName = new Label();
            lblEditCategory = new Label();
            textBox3 = new TextBox();
            lbEditName = new Label();
            tbEditName = new TextBox();
            btnSaveCategory = new Button();
            btnDeleteCategory = new Button();
            lblMyCatgories = new Label();
            lbMyCategories = new ListBox();
            btnEditCategory = new Button();
            btnEditName = new Button();
            btnSort = new Button();
            lblSpecificInformationEpisode = new Label();
            lblEpisodesOfPodcast = new Label();
            lblMyPodcasts = new Label();
            rbtMoreInformationEpisode = new RichTextBox();
            lbEpisodesOfAPodcast = new ListBox();
            lbMyPodcasts = new ListBox();
            tabControl.SuspendLayout();
            mainFrame.SuspendLayout();
            myCollection.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(mainFrame);
            tabControl.Controls.Add(myCollection);
            tabControl.Location = new Point(10, 9);
            tabControl.Margin = new Padding(3, 2, 3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1192, 422);
            tabControl.TabIndex = 0;
            // 
            // mainFrame
            // 
            mainFrame.Controls.Add(textBox2);
            mainFrame.Controls.Add(lblGiveCategoryToPodcast);
            mainFrame.Controls.Add(tbPodcastTitle);
            mainFrame.Controls.Add(lblNamePodcast);
            mainFrame.Controls.Add(btnSavePodcast);
            mainFrame.Controls.Add(rbtSpecificEpisode);
            mainFrame.Controls.Add(lbAllEpisodes);
            mainFrame.Controls.Add(btnGetPodcast);
            mainFrame.Controls.Add(tbURL);
            mainFrame.Controls.Add(lblURL);
            mainFrame.Location = new Point(4, 24);
            mainFrame.Margin = new Padding(3, 2, 3, 2);
            mainFrame.Name = "mainFrame";
            mainFrame.Padding = new Padding(3, 2, 3, 2);
            mainFrame.Size = new Size(1184, 394);
            mainFrame.TabIndex = 0;
            mainFrame.Text = "Startsida";
            mainFrame.UseVisualStyleBackColor = true;
            mainFrame.Click += mainFrame_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(172, 276);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(134, 23);
            textBox2.TabIndex = 9;
            // 
            // lblGiveCategoryToPodcast
            // 
            lblGiveCategoryToPodcast.AutoSize = true;
            lblGiveCategoryToPodcast.Location = new Point(172, 259);
            lblGiveCategoryToPodcast.Name = "lblGiveCategoryToPodcast";
            lblGiveCategoryToPodcast.Size = new Size(107, 15);
            lblGiveCategoryToPodcast.TabIndex = 8;
            lblGiveCategoryToPodcast.Text = "Tilldela en kategori";
            lblGiveCategoryToPodcast.Click += lblGiveCategoryToPodcast_Click;
            // 
            // tbPodcastTitle
            // 
            tbPodcastTitle.Location = new Point(22, 276);
            tbPodcastTitle.Margin = new Padding(3, 2, 3, 2);
            tbPodcastTitle.Name = "tbPodcastTitle";
            tbPodcastTitle.Size = new Size(110, 23);
            tbPodcastTitle.TabIndex = 7;
            // 
            // lblNamePodcast
            // 
            lblNamePodcast.AutoSize = true;
            lblNamePodcast.Location = new Point(22, 259);
            lblNamePodcast.Name = "lblNamePodcast";
            lblNamePodcast.Size = new Size(84, 15);
            lblNamePodcast.TabIndex = 6;
            lblNamePodcast.Text = "Namnge podd";
            // 
            // btnSavePodcast
            // 
            btnSavePodcast.Location = new Point(576, 274);
            btnSavePodcast.Margin = new Padding(3, 2, 3, 2);
            btnSavePodcast.Name = "btnSavePodcast";
            btnSavePodcast.Size = new Size(165, 22);
            btnSavePodcast.TabIndex = 5;
            btnSavePodcast.Text = "Lägg till podd i samling";
            btnSavePodcast.UseVisualStyleBackColor = true;
            btnSavePodcast.Click += btnSavePodcast_Click;
            // 
            // rbtSpecificEpisode
            // 
            rbtSpecificEpisode.Location = new Point(394, 65);
            rbtSpecificEpisode.Margin = new Padding(3, 2, 3, 2);
            rbtSpecificEpisode.Name = "rbtSpecificEpisode";
            rbtSpecificEpisode.Size = new Size(348, 184);
            rbtSpecificEpisode.TabIndex = 4;
            rbtSpecificEpisode.Text = "";
            rbtSpecificEpisode.TextChanged += rbtSpecificEpisode_TextChanged;
            // 
            // lbAllEpisodes
            // 
            lbAllEpisodes.FormattingEnabled = true;
            lbAllEpisodes.Location = new Point(22, 65);
            lbAllEpisodes.Margin = new Padding(3, 2, 3, 2);
            lbAllEpisodes.Name = "lbAllEpisodes";
            lbAllEpisodes.Size = new Size(356, 184);
            lbAllEpisodes.TabIndex = 3;
            // 
            // btnGetPodcast
            // 
            btnGetPodcast.Location = new Point(394, 28);
            btnGetPodcast.Margin = new Padding(3, 2, 3, 2);
            btnGetPodcast.Name = "btnGetPodcast";
            btnGetPodcast.Size = new Size(170, 22);
            btnGetPodcast.TabIndex = 2;
            btnGetPodcast.Text = "Visa poddens avsnitt";
            btnGetPodcast.UseVisualStyleBackColor = true;
            btnGetPodcast.Click += btnGetPodcast_Click;
            // 
            // tbURL
            // 
            tbURL.Location = new Point(22, 28);
            tbURL.Margin = new Padding(3, 2, 3, 2);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(356, 23);
            tbURL.TabIndex = 1;
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Location = new Point(22, 11);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(75, 15);
            lblURL.TabIndex = 0;
            lblURL.Text = "Ange en URL";
            // 
            // myCollection
            // 
            myCollection.Controls.Add(lblInformation);
            myCollection.Controls.Add(btnDeletePodcast);
            myCollection.Controls.Add(btnSaveCreatedCategory);
            myCollection.Controls.Add(tbCreateCategory);
            myCollection.Controls.Add(lblCreateCategory);
            myCollection.Controls.Add(label1);
            myCollection.Controls.Add(tbEditCategoryName);
            myCollection.Controls.Add(lblEditCategoryName);
            myCollection.Controls.Add(lblEditCategory);
            myCollection.Controls.Add(textBox3);
            myCollection.Controls.Add(lbEditName);
            myCollection.Controls.Add(tbEditName);
            myCollection.Controls.Add(btnSaveCategory);
            myCollection.Controls.Add(btnDeleteCategory);
            myCollection.Controls.Add(lblMyCatgories);
            myCollection.Controls.Add(lbMyCategories);
            myCollection.Controls.Add(btnEditCategory);
            myCollection.Controls.Add(btnEditName);
            myCollection.Controls.Add(btnSort);
            myCollection.Controls.Add(lblSpecificInformationEpisode);
            myCollection.Controls.Add(lblEpisodesOfPodcast);
            myCollection.Controls.Add(lblMyPodcasts);
            myCollection.Controls.Add(rbtMoreInformationEpisode);
            myCollection.Controls.Add(lbEpisodesOfAPodcast);
            myCollection.Controls.Add(lbMyPodcasts);
            myCollection.Location = new Point(4, 24);
            myCollection.Margin = new Padding(3, 2, 3, 2);
            myCollection.Name = "myCollection";
            myCollection.Padding = new Padding(3, 2, 3, 2);
            myCollection.Size = new Size(1184, 394);
            myCollection.TabIndex = 1;
            myCollection.Text = "Mina poddar";
            myCollection.UseVisualStyleBackColor = true;
            myCollection.Click += myCollection_Click;
            // 
            // lblInformation
            // 
            lblInformation.AutoSize = true;
            lblInformation.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInformation.Location = new Point(474, 379);
            lblInformation.Name = "lblInformation";
            lblInformation.Size = new Size(303, 15);
            lblInformation.TabIndex = 24;
            lblInformation.Text = "Markera en rad i en lista för att redigera eller ta bort den";
            // 
            // btnDeletePodcast
            // 
            btnDeletePodcast.Location = new Point(27, 326);
            btnDeletePodcast.Margin = new Padding(3, 2, 3, 2);
            btnDeletePodcast.Name = "btnDeletePodcast";
            btnDeletePodcast.Size = new Size(225, 22);
            btnDeletePodcast.TabIndex = 23;
            btnDeletePodcast.Text = "Ta bort podd";
            btnDeletePodcast.UseVisualStyleBackColor = true;
            // 
            // btnSaveCreatedCategory
            // 
            btnSaveCreatedCategory.Location = new Point(1079, 238);
            btnSaveCreatedCategory.Margin = new Padding(3, 2, 3, 2);
            btnSaveCreatedCategory.Name = "btnSaveCreatedCategory";
            btnSaveCreatedCategory.Size = new Size(80, 22);
            btnSaveCreatedCategory.TabIndex = 22;
            btnSaveCreatedCategory.Text = "Spara";
            btnSaveCreatedCategory.UseVisualStyleBackColor = true;
            // 
            // tbCreateCategory
            // 
            tbCreateCategory.Location = new Point(948, 238);
            tbCreateCategory.Margin = new Padding(3, 2, 3, 2);
            tbCreateCategory.Name = "tbCreateCategory";
            tbCreateCategory.Size = new Size(126, 23);
            tbCreateCategory.TabIndex = 21;
            // 
            // lblCreateCategory
            // 
            lblCreateCategory.AutoSize = true;
            lblCreateCategory.Location = new Point(948, 221);
            lblCreateCategory.Name = "lblCreateCategory";
            lblCreateCategory.Size = new Size(100, 15);
            lblCreateCategory.TabIndex = 20;
            lblCreateCategory.Text = "Skapa en kategori";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(947, 310);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 19;
            // 
            // tbEditCategoryName
            // 
            tbEditCategoryName.Location = new Point(948, 288);
            tbEditCategoryName.Margin = new Padding(3, 2, 3, 2);
            tbEditCategoryName.Name = "tbEditCategoryName";
            tbEditCategoryName.Size = new Size(126, 23);
            tbEditCategoryName.TabIndex = 18;
            // 
            // lblEditCategoryName
            // 
            lblEditCategoryName.AutoSize = true;
            lblEditCategoryName.Location = new Point(948, 271);
            lblEditCategoryName.Name = "lblEditCategoryName";
            lblEditCategoryName.Size = new Size(134, 15);
            lblEditCategoryName.TabIndex = 17;
            lblEditCategoryName.Text = "Redigera katgorinamnet";
            // 
            // lblEditCategory
            // 
            lblEditCategory.AutoSize = true;
            lblEditCategory.Location = new Point(25, 270);
            lblEditCategory.Name = "lblEditCategory";
            lblEditCategory.Size = new Size(148, 15);
            lblEditCategory.TabIndex = 16;
            lblEditCategory.Text = "Redigera poddens kategori";
            lblEditCategory.Click += lblEditCategory_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(25, 287);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(135, 23);
            textBox3.TabIndex = 15;
            // 
            // lbEditName
            // 
            lbEditName.AutoSize = true;
            lbEditName.Location = new Point(25, 221);
            lbEditName.Name = "lbEditName";
            lbEditName.Size = new Size(115, 15);
            lbEditName.TabIndex = 14;
            lbEditName.Text = "Redigera poddnamn";
            // 
            // tbEditName
            // 
            tbEditName.Location = new Point(25, 238);
            tbEditName.Margin = new Padding(3, 2, 3, 2);
            tbEditName.Name = "tbEditName";
            tbEditName.Size = new Size(135, 23);
            tbEditName.TabIndex = 13;
            // 
            // btnSaveCategory
            // 
            btnSaveCategory.Location = new Point(1079, 286);
            btnSaveCategory.Margin = new Padding(3, 2, 3, 2);
            btnSaveCategory.Name = "btnSaveCategory";
            btnSaveCategory.Size = new Size(80, 22);
            btnSaveCategory.TabIndex = 12;
            btnSaveCategory.Text = "Spara";
            btnSaveCategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(948, 326);
            btnDeleteCategory.Margin = new Padding(3, 2, 3, 2);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(211, 22);
            btnDeleteCategory.TabIndex = 11;
            btnDeleteCategory.Text = "Ta bort kategori";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // lblMyCatgories
            // 
            lblMyCatgories.AutoSize = true;
            lblMyCatgories.Location = new Point(948, 17);
            lblMyCatgories.Name = "lblMyCatgories";
            lblMyCatgories.Size = new Size(90, 15);
            lblMyCatgories.TabIndex = 10;
            lblMyCatgories.Text = "Mina kategorier";
            lblMyCatgories.Click += label1_Click;
            // 
            // lbMyCategories
            // 
            lbMyCategories.FormattingEnabled = true;
            lbMyCategories.Location = new Point(948, 40);
            lbMyCategories.Margin = new Padding(3, 2, 3, 2);
            lbMyCategories.Name = "lbMyCategories";
            lbMyCategories.Size = new Size(211, 169);
            lbMyCategories.TabIndex = 9;
            // 
            // btnEditCategory
            // 
            btnEditCategory.Location = new Point(165, 287);
            btnEditCategory.Margin = new Padding(3, 2, 3, 2);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(87, 22);
            btnEditCategory.TabIndex = 8;
            btnEditCategory.Text = "Spara";
            btnEditCategory.UseVisualStyleBackColor = true;
            // 
            // btnEditName
            // 
            btnEditName.Location = new Point(165, 237);
            btnEditName.Margin = new Padding(3, 2, 3, 2);
            btnEditName.Name = "btnEditName";
            btnEditName.Size = new Size(87, 22);
            btnEditName.TabIndex = 7;
            btnEditName.Text = "Spara";
            btnEditName.UseVisualStyleBackColor = true;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(114, 14);
            btnSort.Margin = new Padding(3, 2, 3, 2);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(136, 22);
            btnSort.TabIndex = 6;
            btnSort.Text = "Sortera kategori A-Ö";
            btnSort.UseVisualStyleBackColor = true;
            // 
            // lblSpecificInformationEpisode
            // 
            lblSpecificInformationEpisode.AutoSize = true;
            lblSpecificInformationEpisode.Location = new Point(547, 17);
            lblSpecificInformationEpisode.Name = "lblSpecificInformationEpisode";
            lblSpecificInformationEpisode.Size = new Size(97, 15);
            lblSpecificInformationEpisode.TabIndex = 5;
            lblSpecificInformationEpisode.Text = "Mer om avsnittet";
            // 
            // lblEpisodesOfPodcast
            // 
            lblEpisodesOfPodcast.AutoSize = true;
            lblEpisodesOfPodcast.Location = new Point(281, 17);
            lblEpisodesOfPodcast.Name = "lblEpisodesOfPodcast";
            lblEpisodesOfPodcast.Size = new Size(91, 15);
            lblEpisodesOfPodcast.TabIndex = 4;
            lblEpisodesOfPodcast.Text = "Poddens avsnitt";
            // 
            // lblMyPodcasts
            // 
            lblMyPodcasts.AutoSize = true;
            lblMyPodcasts.Location = new Point(25, 17);
            lblMyPodcasts.Name = "lblMyPodcasts";
            lblMyPodcasts.Size = new Size(75, 15);
            lblMyPodcasts.TabIndex = 3;
            lblMyPodcasts.Text = "Mina poddar";
            // 
            // rbtMoreInformationEpisode
            // 
            rbtMoreInformationEpisode.Location = new Point(547, 40);
            rbtMoreInformationEpisode.Margin = new Padding(3, 2, 3, 2);
            rbtMoreInformationEpisode.Name = "rbtMoreInformationEpisode";
            rbtMoreInformationEpisode.Size = new Size(215, 169);
            rbtMoreInformationEpisode.TabIndex = 2;
            rbtMoreInformationEpisode.Text = "";
            // 
            // lbEpisodesOfAPodcast
            // 
            lbEpisodesOfAPodcast.FormattingEnabled = true;
            lbEpisodesOfAPodcast.Location = new Point(281, 40);
            lbEpisodesOfAPodcast.Margin = new Padding(3, 2, 3, 2);
            lbEpisodesOfAPodcast.Name = "lbEpisodesOfAPodcast";
            lbEpisodesOfAPodcast.Size = new Size(226, 169);
            lbEpisodesOfAPodcast.TabIndex = 1;
            // 
            // lbMyPodcasts
            // 
            lbMyPodcasts.FormattingEnabled = true;
            lbMyPodcasts.Location = new Point(25, 40);
            lbMyPodcasts.Margin = new Padding(3, 2, 3, 2);
            lbMyPodcasts.Name = "lbMyPodcasts";
            lbMyPodcasts.Size = new Size(225, 169);
            lbMyPodcasts.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 431);
            Controls.Add(tabControl);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            tabControl.ResumeLayout(false);
            mainFrame.ResumeLayout(false);
            mainFrame.PerformLayout();
            myCollection.ResumeLayout(false);
            myCollection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage mainFrame;
        private TabPage myCollection;
        private Label lblURL;
        private RichTextBox rbtSpecificEpisode;
        private ListBox lbAllEpisodes;
        private Button btnGetPodcast;
        private TextBox tbURL;
        private Label lblNamePodcast;
        private Button button1;
        private TextBox textBox2;
        private Label lblGiveCategoryToPodcast;
        private TextBox tbPodcastTitle;
        private ListBox lbEpisodesOfAPodcast;
        private ListBox lbMyPodcasts;
        private RichTextBox rbtMoreInformationEpisode;
        private Label lblSpecificInformationEpisode;
        private Label lblEpisodesOfPodcast;
        private Label lblMyPodcasts;
        private Button btnSort;
        private Button btnEditCategory;
        private Button btnEditName;
        private Label lblMyCatgories;
        private ListBox lbMyCategories;
        private Button btnDeleteCategory;
        private Button btnSaveCategory;
        private Label lbEditName;
        private TextBox tbEditName;
        private Label lblEditCategoryName;
        private Label lblEditCategory;
        private TextBox textBox3;
        private Label label1;
        private TextBox tbEditCategoryName;
        private Button btnDeletePodcast;
        private Button btnSaveCreatedCategory;
        private TextBox tbCreateCategory;
        private Label lblCreateCategory;
        private Label lblInformation;
        private Button btnSavePodcast;
    }
}
