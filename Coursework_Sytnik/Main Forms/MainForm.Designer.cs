namespace Coursework_Sytnik
{
    partial class MainForm
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
            btnGoToPaintings = new Button();
            btnGoToMuseums = new Button();
            artistsDataGridView = new DataGridView();
            btnAddArtist = new Button();
            btnEditArtist = new Button();
            btnDeleteArtist = new Button();
            btnGoToArtists = new Button();
            btnGoToCollectionEvents = new Button();
            btnToMyCollection = new Button();
            txtSearchArtist = new TextBox();
            label1 = new Label();
            btnApplyFilter = new Button();
            btnResetFilter = new Button();
            btnViewBiography = new Button();
            BtnExportArtistToPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)artistsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnGoToPaintings
            // 
            btnGoToPaintings.Location = new Point(118, 12);
            btnGoToPaintings.Name = "btnGoToPaintings";
            btnGoToPaintings.Size = new Size(94, 29);
            btnGoToPaintings.TabIndex = 0;
            btnGoToPaintings.Text = "Картини";
            btnGoToPaintings.UseVisualStyleBackColor = true;
            // 
            // btnGoToMuseums
            // 
            btnGoToMuseums.Location = new Point(218, 12);
            btnGoToMuseums.Name = "btnGoToMuseums";
            btnGoToMuseums.Size = new Size(142, 29);
            btnGoToMuseums.TabIndex = 1;
            btnGoToMuseums.Text = "Музеї та колекції ";
            btnGoToMuseums.UseVisualStyleBackColor = true;
            // 
            // artistsDataGridView
            // 
            artistsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            artistsDataGridView.Location = new Point(12, 102);
            artistsDataGridView.Name = "artistsDataGridView";
            artistsDataGridView.RowHeadersWidth = 51;
            artistsDataGridView.Size = new Size(540, 336);
            artistsDataGridView.TabIndex = 2;
            artistsDataGridView.CellContentClick += artistsDataGridView_CellContentClick;
            // 
            // btnAddArtist
            // 
            btnAddArtist.Location = new Point(611, 102);
            btnAddArtist.Name = "btnAddArtist";
            btnAddArtist.Size = new Size(151, 29);
            btnAddArtist.TabIndex = 3;
            btnAddArtist.Text = "Додати художника";
            btnAddArtist.UseVisualStyleBackColor = true;
            // 
            // btnEditArtist
            // 
            btnEditArtist.Location = new Point(588, 137);
            btnEditArtist.Name = "btnEditArtist";
            btnEditArtist.Size = new Size(187, 29);
            btnEditArtist.TabIndex = 4;
            btnEditArtist.Text = "Редагувати художника";
            btnEditArtist.UseVisualStyleBackColor = true;
            // 
            // btnDeleteArtist
            // 
            btnDeleteArtist.Location = new Point(602, 174);
            btnDeleteArtist.Name = "btnDeleteArtist";
            btnDeleteArtist.Size = new Size(170, 29);
            btnDeleteArtist.TabIndex = 5;
            btnDeleteArtist.Text = "Видалити художника";
            btnDeleteArtist.UseVisualStyleBackColor = true;
            // 
            // btnGoToArtists
            // 
            btnGoToArtists.Location = new Point(12, 12);
            btnGoToArtists.Name = "btnGoToArtists";
            btnGoToArtists.Size = new Size(100, 29);
            btnGoToArtists.TabIndex = 6;
            btnGoToArtists.Text = "Художники";
            btnGoToArtists.UseVisualStyleBackColor = true;
            btnGoToArtists.Click += btnGoToArtists_Click;
            // 
            // btnGoToCollectionEvents
            // 
            btnGoToCollectionEvents.Location = new Point(366, 12);
            btnGoToCollectionEvents.Name = "btnGoToCollectionEvents";
            btnGoToCollectionEvents.Size = new Size(245, 29);
            btnGoToCollectionEvents.TabIndex = 7;
            btnGoToCollectionEvents.Text = "Аукціони та комісійні магазини ";
            btnGoToCollectionEvents.UseVisualStyleBackColor = true;
            btnGoToCollectionEvents.Click += btnGoToCollectionEvents_Click;
            // 
            // btnToMyCollection
            // 
            btnToMyCollection.Location = new Point(617, 12);
            btnToMyCollection.Name = "btnToMyCollection";
            btnToMyCollection.Size = new Size(131, 29);
            btnToMyCollection.TabIndex = 8;
            btnToMyCollection.Text = "Моя колекція ";
            btnToMyCollection.UseVisualStyleBackColor = true;
            btnToMyCollection.Click += btnToMyCollection_Click;
            // 
            // txtSearchArtist
            // 
            txtSearchArtist.Location = new Point(85, 57);
            txtSearchArtist.Name = "txtSearchArtist";
            txtSearchArtist.Size = new Size(239, 27);
            txtSearchArtist.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 60);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 10;
            label1.Text = "Пошук:";
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(330, 55);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(104, 29);
            btnApplyFilter.TabIndex = 11;
            btnApplyFilter.Text = "Фільтрувати ";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(440, 55);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(171, 29);
            btnResetFilter.TabIndex = 12;
            btnResetFilter.Text = "Скинути фільтрацію ";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnViewBiography
            // 
            btnViewBiography.Location = new Point(589, 240);
            btnViewBiography.Name = "btnViewBiography";
            btnViewBiography.Size = new Size(186, 29);
            btnViewBiography.TabIndex = 13;
            btnViewBiography.Text = "Подивитися біографію";
            btnViewBiography.UseVisualStyleBackColor = true;
            btnViewBiography.Click += btnViewBiography_Click;
            // 
            // BtnExportArtistToPdf
            // 
            BtnExportArtistToPdf.Location = new Point(589, 352);
            BtnExportArtistToPdf.Name = "BtnExportArtistToPdf";
            BtnExportArtistToPdf.Size = new Size(186, 29);
            BtnExportArtistToPdf.TabIndex = 14;
            BtnExportArtistToPdf.Text = "Перетворити в PDF";
            BtnExportArtistToPdf.UseVisualStyleBackColor = true;
            BtnExportArtistToPdf.Click += BtnExportArtistToPdf_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnExportArtistToPdf);
            Controls.Add(btnViewBiography);
            Controls.Add(btnResetFilter);
            Controls.Add(btnApplyFilter);
            Controls.Add(label1);
            Controls.Add(txtSearchArtist);
            Controls.Add(btnToMyCollection);
            Controls.Add(btnGoToCollectionEvents);
            Controls.Add(btnGoToArtists);
            Controls.Add(btnDeleteArtist);
            Controls.Add(btnEditArtist);
            Controls.Add(btnAddArtist);
            Controls.Add(artistsDataGridView);
            Controls.Add(btnGoToMuseums);
            Controls.Add(btnGoToPaintings);
            Name = "MainForm";
            Text = "Художники";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)artistsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGoToPaintings;
        private Button btnGoToMuseums;
        private DataGridView artistsDataGridView;
        private Button btnAddArtist;
        private Button btnEditArtist;
        private Button btnDeleteArtist;
        private Button btnGoToArtists;
        private Button btnGoToCollectionEvents;
        private Button btnToMyCollection;
        private TextBox txtSearchArtist;
        private Label label1;
        private Button btnApplyFilter;
        private Button btnResetFilter;
        private Button btnViewBiography;
        private Button BtnExportArtistToPdf;
    }
}
