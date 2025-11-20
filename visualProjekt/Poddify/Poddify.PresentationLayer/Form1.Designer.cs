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
            myCollection = new TabPage();
            lblURL = new Label();
            tbURL = new TextBox();
            btnGetPodcast = new Button();
            lbAllEpisodes = new ListBox();
            rbtSpecificEpisode = new RichTextBox();
            button1 = new Button();
            lblNamePodcast = new Label();
            textBox1 = new TextBox();
            lblGiveCategoryToPodcast = new Label();
            textBox2 = new TextBox();
            lbMyPodcasts = new ListBox();
            lbEpisodesOfAPodcast = new ListBox();
            rbtMoreInformationEpisode = new RichTextBox();
            lblMyPodcasts = new Label();
            lblEpisodesOfPodcast = new Label();
            lblSpecificInformationEpisode = new Label();
            btnSort = new Button();
            btnEditName = new Button();
            btnEditCategory = new Button();
            lbMyCategories = new ListBox();
            lblMyCatgories = new Label();
            btnDeleteCategory = new Button();
            button2 = new Button();
            tabControl.SuspendLayout();
            mainFrame.SuspendLayout();
            myCollection.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(mainFrame);
            tabControl.Controls.Add(myCollection);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1362, 463);
            tabControl.TabIndex = 0;
            // 
            // mainFrame
            // 
            mainFrame.Controls.Add(textBox2);
            mainFrame.Controls.Add(lblGiveCategoryToPodcast);
            mainFrame.Controls.Add(textBox1);
            mainFrame.Controls.Add(lblNamePodcast);
            mainFrame.Controls.Add(button1);
            mainFrame.Controls.Add(rbtSpecificEpisode);
            mainFrame.Controls.Add(lbAllEpisodes);
            mainFrame.Controls.Add(btnGetPodcast);
            mainFrame.Controls.Add(tbURL);
            mainFrame.Controls.Add(lblURL);
            mainFrame.Location = new Point(4, 29);
            mainFrame.Name = "mainFrame";
            mainFrame.Padding = new Padding(3);
            mainFrame.Size = new Size(1354, 430);
            mainFrame.TabIndex = 0;
            mainFrame.Text = "Startsida";
            mainFrame.UseVisualStyleBackColor = true;
            mainFrame.Click += mainFrame_Click;
            // 
            // myCollection
            // 
            myCollection.Controls.Add(button2);
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
            myCollection.Location = new Point(4, 29);
            myCollection.Name = "myCollection";
            myCollection.Padding = new Padding(3);
            myCollection.Size = new Size(1354, 430);
            myCollection.TabIndex = 1;
            myCollection.Text = "Mina poddar";
            myCollection.UseVisualStyleBackColor = true;
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
            // tbURL
            // 
            tbURL.Location = new Point(25, 38);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(406, 27);
            tbURL.TabIndex = 1;
            // 
            // btnGetPodcast
            // 
            btnGetPodcast.Location = new Point(450, 38);
            btnGetPodcast.Name = "btnGetPodcast";
            btnGetPodcast.Size = new Size(194, 29);
            btnGetPodcast.TabIndex = 2;
            btnGetPodcast.Text = "Visa poddens avsnitt";
            btnGetPodcast.UseVisualStyleBackColor = true;
            // 
            // lbAllEpisodes
            // 
            lbAllEpisodes.FormattingEnabled = true;
            lbAllEpisodes.Location = new Point(25, 87);
            lbAllEpisodes.Name = "lbAllEpisodes";
            lbAllEpisodes.Size = new Size(406, 244);
            lbAllEpisodes.TabIndex = 3;
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
            // button1
            // 
            button1.Location = new Point(658, 366);
            button1.Name = "button1";
            button1.Size = new Size(189, 29);
            button1.TabIndex = 5;
            button1.Text = "Lägg till podd i samling";
            button1.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            textBox1.Location = new Point(25, 368);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 7;
            // 
            // lblGiveCategoryToPodcast
            // 
            lblGiveCategoryToPodcast.AutoSize = true;
            lblGiveCategoryToPodcast.Location = new Point(221, 345);
            lblGiveCategoryToPodcast.Name = "lblGiveCategoryToPodcast";
            lblGiveCategoryToPodcast.Size = new Size(137, 20);
            lblGiveCategoryToPodcast.TabIndex = 8;
            lblGiveCategoryToPodcast.Text = "Tilldela en kategori";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(221, 368);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(153, 27);
            textBox2.TabIndex = 9;
            // 
            // lbMyPodcasts
            // 
            lbMyPodcasts.FormattingEnabled = true;
            lbMyPodcasts.Location = new Point(27, 77);
            lbMyPodcasts.Name = "lbMyPodcasts";
            lbMyPodcasts.Size = new Size(257, 224);
            lbMyPodcasts.TabIndex = 0;
            // 
            // lbEpisodesOfAPodcast
            // 
            lbEpisodesOfAPodcast.FormattingEnabled = true;
            lbEpisodesOfAPodcast.Location = new Point(319, 77);
            lbEpisodesOfAPodcast.Name = "lbEpisodesOfAPodcast";
            lbEpisodesOfAPodcast.Size = new Size(258, 224);
            lbEpisodesOfAPodcast.TabIndex = 1;
            // 
            // rbtMoreInformationEpisode
            // 
            rbtMoreInformationEpisode.Location = new Point(623, 77);
            rbtMoreInformationEpisode.Name = "rbtMoreInformationEpisode";
            rbtMoreInformationEpisode.Size = new Size(245, 224);
            rbtMoreInformationEpisode.TabIndex = 2;
            rbtMoreInformationEpisode.Text = "";
            // 
            // lblMyPodcasts
            // 
            lblMyPodcasts.AutoSize = true;
            lblMyPodcasts.Location = new Point(27, 46);
            lblMyPodcasts.Name = "lblMyPodcasts";
            lblMyPodcasts.Size = new Size(95, 20);
            lblMyPodcasts.TabIndex = 3;
            lblMyPodcasts.Text = "Mina poddar";
            // 
            // lblEpisodesOfPodcast
            // 
            lblEpisodesOfPodcast.AutoSize = true;
            lblEpisodesOfPodcast.Location = new Point(319, 46);
            lblEpisodesOfPodcast.Name = "lblEpisodesOfPodcast";
            lblEpisodesOfPodcast.Size = new Size(112, 20);
            lblEpisodesOfPodcast.TabIndex = 4;
            lblEpisodesOfPodcast.Text = "Poddens avsnitt";
            // 
            // lblSpecificInformationEpisode
            // 
            lblSpecificInformationEpisode.AutoSize = true;
            lblSpecificInformationEpisode.Location = new Point(623, 46);
            lblSpecificInformationEpisode.Name = "lblSpecificInformationEpisode";
            lblSpecificInformationEpisode.Size = new Size(121, 20);
            lblSpecificInformationEpisode.TabIndex = 5;
            lblSpecificInformationEpisode.Text = "Mer om avsnittet";
            // 
            // btnSort
            // 
            btnSort.Location = new Point(128, 42);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(156, 29);
            btnSort.TabIndex = 6;
            btnSort.Text = "Sortera kategori A-Ö";
            btnSort.UseVisualStyleBackColor = true;
            // 
            // btnEditName
            // 
            btnEditName.Location = new Point(27, 323);
            btnEditName.Name = "btnEditName";
            btnEditName.Size = new Size(175, 29);
            btnEditName.TabIndex = 7;
            btnEditName.Text = "Redigera namn";
            btnEditName.UseVisualStyleBackColor = true;
            // 
            // btnEditCategory
            // 
            btnEditCategory.Location = new Point(27, 369);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(174, 29);
            btnEditCategory.TabIndex = 8;
            btnEditCategory.Text = "Redigera kategori";
            btnEditCategory.UseVisualStyleBackColor = true;
            // 
            // lbMyCategories
            // 
            lbMyCategories.FormattingEnabled = true;
            lbMyCategories.Location = new Point(1082, 77);
            lbMyCategories.Name = "lbMyCategories";
            lbMyCategories.Size = new Size(241, 224);
            lbMyCategories.TabIndex = 9;
            // 
            // lblMyCatgories
            // 
            lblMyCatgories.AutoSize = true;
            lblMyCatgories.Location = new Point(1082, 46);
            lblMyCatgories.Name = "lblMyCatgories";
            lblMyCatgories.Size = new Size(114, 20);
            lblMyCatgories.TabIndex = 10;
            lblMyCatgories.Text = "Mina kategorier";
            lblMyCatgories.Click += label1_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(1192, 369);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(131, 29);
            btnDeleteCategory.TabIndex = 11;
            btnDeleteCategory.Text = "Radera kategori";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1192, 323);
            button2.Name = "button2";
            button2.Size = new Size(131, 29);
            button2.TabIndex = 12;
            button2.Text = "Ändra namn";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 499);
            Controls.Add(tabControl);
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
        private TextBox textBox1;
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
        private Button button2;
    }
}
