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
            myCollection = new TabPage();
            lblInformation = new Label();
            btnDeletePodcast = new Button();
            textBox3 = new TextBox();
            tbEditName = new TextBox();
            rbtMoreInformationEpisode = new RichTextBox();
            label1 = new Label();
            lblEditCategory = new Label();
            lbEditName = new Label();
            btnEditCategory = new Button();
            btnEditName = new Button();
            btnSort = new Button();
            lblSpecificInformationEpisode = new Label();
            lblEpisodesOfPodcast = new Label();
            lblMyPodcasts = new Label();
            lbEpisodesOfAPodcast = new ListBox();
            lbMyPodcasts = new ListBox();
            lbMyCategories = new ListBox();
            lblMyCatgories = new Label();
            btnDeleteCategory = new Button();
            btnSaveCategory = new Button();
            lblEditCategoryName = new Label();
            tbEditCategoryName = new TextBox();
            lblCreateCategory = new Label();
            tbCreateCategory = new TextBox();
            btnSaveCreatedCategory = new Button();
            mainFrame = new TabPage();
            label2 = new Label();
            tbCategory = new TextBox();
            tbPodcastTitle = new TextBox();
            rbtSpecificEpisode = new RichTextBox();
            tbURL = new TextBox();
            lblGiveCategoryToPodcast = new Label();
            lblNamePodcast = new Label();
            btnSavePodcast = new Button();
            lbAllEpisodes = new ListBox();
            btnGetPodcast = new Button();
            lblURL = new Label();
            tabControl = new TabControl();
            myCollection.SuspendLayout();
            mainFrame.SuspendLayout();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // myCollection
            // 
            myCollection.Controls.Add(lblInformation);
            myCollection.Controls.Add(btnDeletePodcast);
            myCollection.Controls.Add(textBox3);
            myCollection.Controls.Add(tbEditName);
            myCollection.Controls.Add(rbtMoreInformationEpisode);
            myCollection.Controls.Add(label1);
            myCollection.Controls.Add(lblEditCategory);
            myCollection.Controls.Add(lbEditName);
            myCollection.Controls.Add(btnEditCategory);
            myCollection.Controls.Add(btnEditName);
            myCollection.Controls.Add(btnSort);
            myCollection.Controls.Add(lblSpecificInformationEpisode);
            myCollection.Controls.Add(lblEpisodesOfPodcast);
            myCollection.Controls.Add(lblMyPodcasts);
            myCollection.Controls.Add(lbEpisodesOfAPodcast);
            myCollection.Controls.Add(lbMyPodcasts);
            myCollection.Location = new Point(4, 29);
            myCollection.Name = "myCollection";
            myCollection.Padding = new Padding(3);
            myCollection.Size = new Size(1397, 550);
            myCollection.TabIndex = 1;
            myCollection.Text = "Mina poddar";
            myCollection.UseVisualStyleBackColor = true;
            myCollection.Click += myCollection_Click;
            // 
            // lblInformation
            // 
            lblInformation.AutoSize = true;
            lblInformation.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInformation.Location = new Point(249, 505);
            lblInformation.Name = "lblInformation";
            lblInformation.Size = new Size(337, 20);
            lblInformation.TabIndex = 24;
            lblInformation.Text = "Markera en rad för att redigera eller ta bort en podd";
            lblInformation.Click += lblInformation_Click;
            // 
            // btnDeletePodcast
            // 
            btnDeletePodcast.Location = new Point(273, 444);
            btnDeletePodcast.Name = "btnDeletePodcast";
            btnDeletePodcast.Size = new Size(257, 29);
            btnDeletePodcast.TabIndex = 23;
            btnDeletePodcast.Text = "Ta bort podd";
            btnDeletePodcast.UseVisualStyleBackColor = true;
            btnDeletePodcast.Click += btnDeletePodcast_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(271, 392);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(154, 27);
            textBox3.TabIndex = 15;
            // 
            // tbEditName
            // 
            tbEditName.Location = new Point(271, 326);
            tbEditName.Name = "tbEditName";
            tbEditName.Size = new Size(154, 27);
            tbEditName.TabIndex = 13;
            // 
            // rbtMoreInformationEpisode
            // 
            rbtMoreInformationEpisode.Location = new Point(867, 62);
            rbtMoreInformationEpisode.Name = "rbtMoreInformationEpisode";
            rbtMoreInformationEpisode.Size = new Size(245, 224);
            rbtMoreInformationEpisode.TabIndex = 2;
            rbtMoreInformationEpisode.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1082, 413);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 19;
            // 
            // lblEditCategory
            // 
            lblEditCategory.AutoSize = true;
            lblEditCategory.Location = new Point(271, 369);
            lblEditCategory.Name = "lblEditCategory";
            lblEditCategory.Size = new Size(190, 20);
            lblEditCategory.TabIndex = 16;
            lblEditCategory.Text = "Redigera poddens kategori";
            lblEditCategory.Click += lblEditCategory_Click;
            // 
            // lbEditName
            // 
            lbEditName.AutoSize = true;
            lbEditName.Location = new Point(271, 304);
            lbEditName.Name = "lbEditName";
            lbEditName.Size = new Size(146, 20);
            lbEditName.TabIndex = 14;
            lbEditName.Text = "Redigera poddnamn";
            // 
            // btnEditCategory
            // 
            btnEditCategory.Location = new Point(431, 392);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(99, 29);
            btnEditCategory.TabIndex = 8;
            btnEditCategory.Text = "Spara";
            btnEditCategory.UseVisualStyleBackColor = true;
            btnEditCategory.Click += btnEditCategory_Click;
            // 
            // btnEditName
            // 
            btnEditName.Location = new Point(431, 325);
            btnEditName.Name = "btnEditName";
            btnEditName.Size = new Size(99, 29);
            btnEditName.TabIndex = 7;
            btnEditName.Text = "Spara";
            btnEditName.UseVisualStyleBackColor = true;
            btnEditName.Click += btnEditName_Click;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(372, 28);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(155, 29);
            btnSort.TabIndex = 6;
            btnSort.Text = "Sortera kategori A-Ö";
            btnSort.UseVisualStyleBackColor = true;
            // 
            // lblSpecificInformationEpisode
            // 
            lblSpecificInformationEpisode.AutoSize = true;
            lblSpecificInformationEpisode.Location = new Point(867, 32);
            lblSpecificInformationEpisode.Name = "lblSpecificInformationEpisode";
            lblSpecificInformationEpisode.Size = new Size(121, 20);
            lblSpecificInformationEpisode.TabIndex = 5;
            lblSpecificInformationEpisode.Text = "Mer om avsnittet";
            // 
            // lblEpisodesOfPodcast
            // 
            lblEpisodesOfPodcast.AutoSize = true;
            lblEpisodesOfPodcast.Location = new Point(563, 32);
            lblEpisodesOfPodcast.Name = "lblEpisodesOfPodcast";
            lblEpisodesOfPodcast.Size = new Size(112, 20);
            lblEpisodesOfPodcast.TabIndex = 4;
            lblEpisodesOfPodcast.Text = "Poddens avsnitt";
            // 
            // lblMyPodcasts
            // 
            lblMyPodcasts.AutoSize = true;
            lblMyPodcasts.Location = new Point(271, 32);
            lblMyPodcasts.Name = "lblMyPodcasts";
            lblMyPodcasts.Size = new Size(95, 20);
            lblMyPodcasts.TabIndex = 3;
            lblMyPodcasts.Text = "Mina poddar";
            // 
            // lbEpisodesOfAPodcast
            // 
            lbEpisodesOfAPodcast.FormattingEnabled = true;
            lbEpisodesOfAPodcast.Location = new Point(563, 62);
            lbEpisodesOfAPodcast.Name = "lbEpisodesOfAPodcast";
            lbEpisodesOfAPodcast.Size = new Size(258, 224);
            lbEpisodesOfAPodcast.TabIndex = 1;
            lbEpisodesOfAPodcast.SelectedIndexChanged += lbEpisodesOfAPodcast_SelectedIndexChanged;
            // 
            // lbMyPodcasts
            // 
            lbMyPodcasts.FormattingEnabled = true;
            lbMyPodcasts.Location = new Point(271, 62);
            lbMyPodcasts.Name = "lbMyPodcasts";
            lbMyPodcasts.Size = new Size(257, 224);
            lbMyPodcasts.TabIndex = 0;
            lbMyPodcasts.SelectedIndexChanged += lbMyPodcasts_SelectedIndexChanged;
            // 
            // lbMyCategories
            // 
            lbMyCategories.FormattingEnabled = true;
            lbMyCategories.Location = new Point(1056, 87);
            lbMyCategories.Name = "lbMyCategories";
            lbMyCategories.Size = new Size(262, 244);
            lbMyCategories.TabIndex = 9;
            // 
            // lblMyCatgories
            // 
            lblMyCatgories.AutoSize = true;
            lblMyCatgories.Location = new Point(1056, 44);
            lblMyCatgories.Name = "lblMyCatgories";
            lblMyCatgories.Size = new Size(114, 20);
            lblMyCatgories.TabIndex = 10;
            lblMyCatgories.Text = "Mina kategorier";
            lblMyCatgories.Click += label1_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(1056, 482);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(262, 29);
            btnDeleteCategory.TabIndex = 11;
            btnDeleteCategory.Text = "Ta bort kategori";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // btnSaveCategory
            // 
            btnSaveCategory.Location = new Point(1227, 436);
            btnSaveCategory.Name = "btnSaveCategory";
            btnSaveCategory.Size = new Size(91, 29);
            btnSaveCategory.TabIndex = 12;
            btnSaveCategory.Text = "Spara";
            btnSaveCategory.UseVisualStyleBackColor = true;
            btnSaveCategory.Click += btnSaveCategory_Click;
            // 
            // lblEditCategoryName
            // 
            lblEditCategoryName.AutoSize = true;
            lblEditCategoryName.Location = new Point(1056, 413);
            lblEditCategoryName.Name = "lblEditCategoryName";
            lblEditCategoryName.Size = new Size(170, 20);
            lblEditCategoryName.TabIndex = 17;
            lblEditCategoryName.Text = "Redigera katgorinamnet";
            // 
            // tbEditCategoryName
            // 
            tbEditCategoryName.Location = new Point(1056, 436);
            tbEditCategoryName.Name = "tbEditCategoryName";
            tbEditCategoryName.Size = new Size(165, 27);
            tbEditCategoryName.TabIndex = 18;
            // 
            // lblCreateCategory
            // 
            lblCreateCategory.AutoSize = true;
            lblCreateCategory.Location = new Point(1056, 345);
            lblCreateCategory.Name = "lblCreateCategory";
            lblCreateCategory.Size = new Size(128, 20);
            lblCreateCategory.TabIndex = 20;
            lblCreateCategory.Text = "Skapa en kategori";
            // 
            // tbCreateCategory
            // 
            tbCreateCategory.Location = new Point(1056, 368);
            tbCreateCategory.Name = "tbCreateCategory";
            tbCreateCategory.Size = new Size(165, 27);
            tbCreateCategory.TabIndex = 21;
            // 
            // btnSaveCreatedCategory
            // 
            btnSaveCreatedCategory.Location = new Point(1227, 368);
            btnSaveCreatedCategory.Name = "btnSaveCreatedCategory";
            btnSaveCreatedCategory.Size = new Size(91, 29);
            btnSaveCreatedCategory.TabIndex = 22;
            btnSaveCreatedCategory.Text = "Spara";
            btnSaveCreatedCategory.UseVisualStyleBackColor = true;
            btnSaveCreatedCategory.Click += btnSaveCreatedCategory_Click;
            // 
            // mainFrame
            // 
            mainFrame.Controls.Add(label2);
            mainFrame.Controls.Add(tbCategory);
            mainFrame.Controls.Add(btnDeleteCategory);
            mainFrame.Controls.Add(btnSaveCategory);
            mainFrame.Controls.Add(tbEditCategoryName);
            mainFrame.Controls.Add(lblCreateCategory);
            mainFrame.Controls.Add(lblEditCategoryName);
            mainFrame.Controls.Add(btnSaveCreatedCategory);
            mainFrame.Controls.Add(lbMyCategories);
            mainFrame.Controls.Add(tbCreateCategory);
            mainFrame.Controls.Add(lblMyCatgories);
            mainFrame.Controls.Add(tbPodcastTitle);
            mainFrame.Controls.Add(rbtSpecificEpisode);
            mainFrame.Controls.Add(tbURL);
            mainFrame.Controls.Add(lblGiveCategoryToPodcast);
            mainFrame.Controls.Add(lblNamePodcast);
            mainFrame.Controls.Add(btnSavePodcast);
            mainFrame.Controls.Add(lbAllEpisodes);
            mainFrame.Controls.Add(btnGetPodcast);
            mainFrame.Controls.Add(lblURL);
            mainFrame.Location = new Point(4, 29);
            mainFrame.Name = "mainFrame";
            mainFrame.Padding = new Padding(3);
            mainFrame.Size = new Size(1397, 550);
            mainFrame.TabIndex = 0;
            mainFrame.Text = "Startsida";
            mainFrame.UseVisualStyleBackColor = true;
            mainFrame.Click += mainFrame_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(1032, 527);
            label2.Name = "label2";
            label2.Size = new Size(357, 20);
            label2.TabIndex = 25;
            label2.Text = "Markera en rad för att redigera eller ta bort en kategori";
            label2.Click += label2_Click;
            // 
            // tbCategory
            // 
            tbCategory.Location = new Point(197, 368);
            tbCategory.Name = "tbCategory";
            tbCategory.Size = new Size(153, 27);
            tbCategory.TabIndex = 9;
            // 
            // tbPodcastTitle
            // 
            tbPodcastTitle.Location = new Point(25, 368);
            tbPodcastTitle.Name = "tbPodcastTitle";
            tbPodcastTitle.Size = new Size(125, 27);
            tbPodcastTitle.TabIndex = 7;
            // 
            // rbtSpecificEpisode
            // 
            rbtSpecificEpisode.Location = new Point(450, 87);
            rbtSpecificEpisode.Name = "rbtSpecificEpisode";
            rbtSpecificEpisode.Size = new Size(397, 244);
            rbtSpecificEpisode.TabIndex = 4;
            rbtSpecificEpisode.Text = "";
            rbtSpecificEpisode.TextChanged += rbtSpecificEpisode_TextChanged;
            // 
            // tbURL
            // 
            tbURL.Location = new Point(25, 37);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(406, 27);
            tbURL.TabIndex = 1;
            // 
            // lblGiveCategoryToPodcast
            // 
            lblGiveCategoryToPodcast.AutoSize = true;
            lblGiveCategoryToPodcast.Location = new Point(197, 345);
            lblGiveCategoryToPodcast.Name = "lblGiveCategoryToPodcast";
            lblGiveCategoryToPodcast.Size = new Size(137, 20);
            lblGiveCategoryToPodcast.TabIndex = 8;
            lblGiveCategoryToPodcast.Text = "Tilldela en kategori";
            lblGiveCategoryToPodcast.Click += lblGiveCategoryToPodcast_Click;
            // 
            // lblNamePodcast
            // 
            lblNamePodcast.AutoSize = true;
            lblNamePodcast.Location = new Point(25, 345);
            lblNamePodcast.Name = "lblNamePodcast";
            lblNamePodcast.Size = new Size(106, 20);
            lblNamePodcast.TabIndex = 6;
            lblNamePodcast.Text = "Namnge podd";
            // 
            // btnSavePodcast
            // 
            btnSavePodcast.Location = new Point(25, 434);
            btnSavePodcast.Name = "btnSavePodcast";
            btnSavePodcast.Size = new Size(189, 29);
            btnSavePodcast.TabIndex = 5;
            btnSavePodcast.Text = "Lägg till podd i samling";
            btnSavePodcast.UseVisualStyleBackColor = true;
            btnSavePodcast.Click += btnSavePodcast_Click;
            // 
            // lbAllEpisodes
            // 
            lbAllEpisodes.FormattingEnabled = true;
            lbAllEpisodes.Location = new Point(25, 87);
            lbAllEpisodes.Name = "lbAllEpisodes";
            lbAllEpisodes.Size = new Size(406, 244);
            lbAllEpisodes.TabIndex = 3;
            lbAllEpisodes.SelectedIndexChanged += lbAllEpisodes_SelectedIndexChanged;
            // 
            // btnGetPodcast
            // 
            btnGetPodcast.Location = new Point(450, 37);
            btnGetPodcast.Name = "btnGetPodcast";
            btnGetPodcast.Size = new Size(194, 29);
            btnGetPodcast.TabIndex = 2;
            btnGetPodcast.Text = "Visa poddens avsnitt";
            btnGetPodcast.UseVisualStyleBackColor = true;
            btnGetPodcast.Click += btnGetPodcast_Click;
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Location = new Point(25, 15);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(94, 20);
            lblURL.TabIndex = 0;
            lblURL.Text = "Ange en URL";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(mainFrame);
            tabControl.Controls.Add(myCollection);
            tabControl.Location = new Point(11, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1405, 583);
            tabControl.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1428, 602);
            Controls.Add(tabControl);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            myCollection.ResumeLayout(false);
            myCollection.PerformLayout();
            mainFrame.ResumeLayout(false);
            mainFrame.PerformLayout();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage myCollection;
        private Label lblInformation;
        private Button btnDeletePodcast;
        private Button btnSaveCreatedCategory;
        private TextBox tbCreateCategory;
        private TextBox tbEditCategoryName;
        private TextBox textBox3;
        private TextBox tbEditName;
        private RichTextBox rbtMoreInformationEpisode;
        private Label lblCreateCategory;
        private Label label1;
        private Label lblEditCategoryName;
        private Label lblEditCategory;
        private Label lbEditName;
        private Button btnSaveCategory;
        private Button btnDeleteCategory;
        private Label lblMyCatgories;
        private ListBox lbMyCategories;
        private Button btnEditCategory;
        private Button btnEditName;
        private Button btnSort;
        private Label lblSpecificInformationEpisode;
        private Label lblEpisodesOfPodcast;
        private Label lblMyPodcasts;
        private ListBox lbEpisodesOfAPodcast;
        private ListBox lbMyPodcasts;
        private TabPage mainFrame;
        private TextBox tbCategory;
        private TextBox tbPodcastTitle;
        private RichTextBox rbtSpecificEpisode;
        private TextBox tbURL;
        private Label lblGiveCategoryToPodcast;
        private Label lblNamePodcast;
        private Button btnSavePodcast;
        private ListBox lbAllEpisodes;
        private Button btnGetPodcast;
        private Label lblURL;
        private TabControl tabControl;
        private Label label2;
    }
}
