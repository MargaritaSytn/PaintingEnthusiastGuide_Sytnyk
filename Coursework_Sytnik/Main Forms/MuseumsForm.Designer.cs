namespace Coursework_Sytnik
{
    partial class MuseumForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            museumsDataGridView = new DataGridView();
            btnGoToArtists = new Button();
            btnGoToPaintings = new Button();
            btnAddMuseum = new Button();
            btnEditMuseum = new Button();
            btnDeleteMuseum = new Button();
            btnGoToMuseums = new Button();
            btnGoToCollectionEvents = new Button();
            btnToMyCollection = new Button();
            btnClearFilterMuseum = new Button();
            btnApplyFilterMuseum = new Button();
            label1 = new Label();
            txtSearchMuseum = new TextBox();
            btnShowOnMap = new Button();
            btnShowMuseumPaintings = new Button();
            btnExportMuseumToPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)museumsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // museumsDataGridView
            // 
            museumsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            museumsDataGridView.Location = new Point(12, 102);
            museumsDataGridView.Name = "museumsDataGridView";
            museumsDataGridView.RowHeadersWidth = 51;
            museumsDataGridView.Size = new Size(540, 336);
            museumsDataGridView.TabIndex = 0;
            // 
            // btnGoToArtists
            // 
            btnGoToArtists.Location = new Point(12, 12);
            btnGoToArtists.Name = "btnGoToArtists";
            btnGoToArtists.Size = new Size(102, 29);
            btnGoToArtists.TabIndex = 1;
            btnGoToArtists.Text = "Художники ";
            btnGoToArtists.UseVisualStyleBackColor = true;
            btnGoToArtists.Click += btnGoToArtists_Click_1;
            // 
            // btnGoToPaintings
            // 
            btnGoToPaintings.Location = new Point(120, 12);
            btnGoToPaintings.Name = "btnGoToPaintings";
            btnGoToPaintings.Size = new Size(94, 29);
            btnGoToPaintings.TabIndex = 2;
            btnGoToPaintings.Text = "Картини";
            btnGoToPaintings.UseVisualStyleBackColor = true;
            // 
            // btnAddMuseum
            // 
            btnAddMuseum.Location = new Point(616, 102);
            btnAddMuseum.Name = "btnAddMuseum";
            btnAddMuseum.Size = new Size(130, 29);
            btnAddMuseum.TabIndex = 3;
            btnAddMuseum.Text = "Додати музей";
            btnAddMuseum.UseVisualStyleBackColor = true;
            // 
            // btnEditMuseum
            // 
            btnEditMuseum.Location = new Point(609, 137);
            btnEditMuseum.Name = "btnEditMuseum";
            btnEditMuseum.Size = new Size(144, 29);
            btnEditMuseum.TabIndex = 4;
            btnEditMuseum.Text = "Редагувати музей";
            btnEditMuseum.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMuseum
            // 
            btnDeleteMuseum.Location = new Point(619, 172);
            btnDeleteMuseum.Name = "btnDeleteMuseum";
            btnDeleteMuseum.Size = new Size(130, 29);
            btnDeleteMuseum.TabIndex = 5;
            btnDeleteMuseum.Text = "Видалити музей";
            btnDeleteMuseum.UseVisualStyleBackColor = true;
            // 
            // btnGoToMuseums
            // 
            btnGoToMuseums.Location = new Point(220, 12);
            btnGoToMuseums.Name = "btnGoToMuseums";
            btnGoToMuseums.Size = new Size(141, 29);
            btnGoToMuseums.TabIndex = 6;
            btnGoToMuseums.Text = "Музеї та колекції ";
            btnGoToMuseums.UseVisualStyleBackColor = true;
            // 
            // btnGoToCollectionEvents
            // 
            btnGoToCollectionEvents.Location = new Point(367, 12);
            btnGoToCollectionEvents.Name = "btnGoToCollectionEvents";
            btnGoToCollectionEvents.Size = new Size(245, 29);
            btnGoToCollectionEvents.TabIndex = 11;
            btnGoToCollectionEvents.Text = "Аукціони та комісійні магазини ";
            btnGoToCollectionEvents.UseVisualStyleBackColor = true;
            btnGoToCollectionEvents.Click += btnGoToCollectionEvents_Click;
            // 
            // btnToMyCollection
            // 
            btnToMyCollection.Location = new Point(618, 12);
            btnToMyCollection.Name = "btnToMyCollection";
            btnToMyCollection.Size = new Size(131, 29);
            btnToMyCollection.TabIndex = 12;
            btnToMyCollection.Text = "Моя колекція ";
            btnToMyCollection.UseVisualStyleBackColor = true;
            btnToMyCollection.Click += btnToMyCollection_Click;
            // 
            // btnClearFilterMuseum
            // 
            btnClearFilterMuseum.Location = new Point(420, 56);
            btnClearFilterMuseum.Name = "btnClearFilterMuseum";
            btnClearFilterMuseum.Size = new Size(132, 29);
            btnClearFilterMuseum.TabIndex = 20;
            btnClearFilterMuseum.Text = "Скинути пошук";
            btnClearFilterMuseum.UseVisualStyleBackColor = true;
            btnClearFilterMuseum.Click += btnClearFilterMuseum_Click;
            // 
            // btnApplyFilterMuseum
            // 
            btnApplyFilterMuseum.Location = new Point(320, 56);
            btnApplyFilterMuseum.Name = "btnApplyFilterMuseum";
            btnApplyFilterMuseum.Size = new Size(94, 29);
            btnApplyFilterMuseum.TabIndex = 19;
            btnApplyFilterMuseum.Text = "Пошук";
            btnApplyFilterMuseum.UseVisualStyleBackColor = true;
            btnApplyFilterMuseum.Click += btnApplyFilterMuseum_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 61);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 18;
            label1.Text = "Пошук:";
            // 
            // txtSearchMuseum
            // 
            txtSearchMuseum.Location = new Point(75, 58);
            txtSearchMuseum.Name = "txtSearchMuseum";
            txtSearchMuseum.Size = new Size(239, 27);
            txtSearchMuseum.TabIndex = 17;
            // 
            // btnShowOnMap
            // 
            btnShowOnMap.Location = new Point(609, 238);
            btnShowOnMap.Name = "btnShowOnMap";
            btnShowOnMap.Size = new Size(155, 29);
            btnShowOnMap.TabIndex = 21;
            btnShowOnMap.Text = "Показати на карті ";
            btnShowOnMap.UseVisualStyleBackColor = true;
            btnShowOnMap.Click += btnShowOnMap_Click_1;
            // 
            // btnShowMuseumPaintings
            // 
            btnShowMuseumPaintings.Location = new Point(597, 273);
            btnShowMuseumPaintings.Name = "btnShowMuseumPaintings";
            btnShowMuseumPaintings.Size = new Size(179, 29);
            btnShowMuseumPaintings.TabIndex = 22;
            btnShowMuseumPaintings.Text = "Список картин музею";
            btnShowMuseumPaintings.UseVisualStyleBackColor = true;
            btnShowMuseumPaintings.Click += btnShowMuseumPaintings_Click;
            // 
            // btnExportMuseumToPdf
            // 
            btnExportMuseumToPdf.Location = new Point(609, 366);
            btnExportMuseumToPdf.Name = "btnExportMuseumToPdf";
            btnExportMuseumToPdf.Size = new Size(155, 29);
            btnExportMuseumToPdf.TabIndex = 23;
            btnExportMuseumToPdf.Text = "Перетворити в PDF";
            btnExportMuseumToPdf.UseVisualStyleBackColor = true;
            btnExportMuseumToPdf.Click += btnExportMuseumToPdf_Click;
            // 
            // MuseumForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportMuseumToPdf);
            Controls.Add(btnShowMuseumPaintings);
            Controls.Add(btnShowOnMap);
            Controls.Add(btnClearFilterMuseum);
            Controls.Add(btnApplyFilterMuseum);
            Controls.Add(label1);
            Controls.Add(txtSearchMuseum);
            Controls.Add(btnToMyCollection);
            Controls.Add(btnGoToCollectionEvents);
            Controls.Add(btnGoToMuseums);
            Controls.Add(btnDeleteMuseum);
            Controls.Add(btnEditMuseum);
            Controls.Add(btnAddMuseum);
            Controls.Add(btnGoToPaintings);
            Controls.Add(btnGoToArtists);
            Controls.Add(museumsDataGridView);
            Name = "MuseumForm";
            Text = "Музеї та колекціонери ";
            Load += MuseumsForm_Load;
            ((System.ComponentModel.ISupportInitialize)museumsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView museumsDataGridView;
        private Button btnGoToArtists;
        private Button btnGoToPaintings;
        private Button btnAddMuseum;
        private Button btnEditMuseum;
        private Button btnDeleteMuseum;
        private Button btnGoToMuseums;
        private Button btnGoToCollectionEvents;
        private Button btnToMyCollection;
        private Button btnClearFilterMuseum;
        private Button btnApplyFilterMuseum;
        private Label label1;
        private TextBox txtSearchMuseum;
        private Button btnShowOnMap;
        private Button btnShowMuseumPaintings;
        private Button btnExportMuseumToPdf;
    }
}