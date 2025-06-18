namespace Coursework_Sytnik
{
    partial class PaintingForm
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
            paintingsDataGridView = new DataGridView();
            btnGoToArtists = new Button();
            btnGoToMuseums = new Button();
            btnAddPainting = new Button();
            btnEditPainting = new Button();
            btnDeletePainting = new Button();
            btnGoToPaintings = new Button();
            btnGoToCollectionEvents = new Button();
            button1 = new Button();
            btnClearFilterPainting = new Button();
            btnApplyFilterPainting = new Button();
            label1 = new Label();
            txtSearchPainting = new TextBox();
            btnExportPaintingToPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)paintingsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // paintingsDataGridView
            // 
            paintingsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            paintingsDataGridView.Location = new Point(12, 102);
            paintingsDataGridView.Name = "paintingsDataGridView";
            paintingsDataGridView.RowHeadersWidth = 51;
            paintingsDataGridView.Size = new Size(540, 336);
            paintingsDataGridView.TabIndex = 0;
            // 
            // btnGoToArtists
            // 
            btnGoToArtists.Location = new Point(12, 12);
            btnGoToArtists.Name = "btnGoToArtists";
            btnGoToArtists.Size = new Size(105, 29);
            btnGoToArtists.TabIndex = 1;
            btnGoToArtists.Text = "Художники";
            btnGoToArtists.UseVisualStyleBackColor = true;
            btnGoToArtists.Click += btnGoToArtists_Click_1;
            // 
            // btnGoToMuseums
            // 
            btnGoToMuseums.Location = new Point(221, 12);
            btnGoToMuseums.Name = "btnGoToMuseums";
            btnGoToMuseums.Size = new Size(184, 29);
            btnGoToMuseums.TabIndex = 2;
            btnGoToMuseums.Text = "Музеї та колекціонери ";
            btnGoToMuseums.UseVisualStyleBackColor = true;
            // 
            // btnAddPainting
            // 
            btnAddPainting.Location = new Point(610, 117);
            btnAddPainting.Name = "btnAddPainting";
            btnAddPainting.Size = new Size(152, 29);
            btnAddPainting.TabIndex = 3;
            btnAddPainting.Text = "Додати картину ";
            btnAddPainting.UseVisualStyleBackColor = true;
            // 
            // btnEditPainting
            // 
            btnEditPainting.Location = new Point(604, 151);
            btnEditPainting.Name = "btnEditPainting";
            btnEditPainting.Size = new Size(164, 29);
            btnEditPainting.TabIndex = 4;
            btnEditPainting.Text = "Редагувати картину ";
            btnEditPainting.UseVisualStyleBackColor = true;
            // 
            // btnDeletePainting
            // 
            btnDeletePainting.Location = new Point(610, 187);
            btnDeletePainting.Name = "btnDeletePainting";
            btnDeletePainting.Size = new Size(148, 29);
            btnDeletePainting.TabIndex = 5;
            btnDeletePainting.Text = "Видалити картину ";
            btnDeletePainting.UseVisualStyleBackColor = true;
            // 
            // btnGoToPaintings
            // 
            btnGoToPaintings.Location = new Point(123, 12);
            btnGoToPaintings.Name = "btnGoToPaintings";
            btnGoToPaintings.Size = new Size(92, 29);
            btnGoToPaintings.TabIndex = 6;
            btnGoToPaintings.Text = "Картини";
            btnGoToPaintings.UseVisualStyleBackColor = true;
            btnGoToPaintings.Click += btnGoToPaintings_Click_1;
            // 
            // btnGoToCollectionEvents
            // 
            btnGoToCollectionEvents.Location = new Point(411, 12);
            btnGoToCollectionEvents.Name = "btnGoToCollectionEvents";
            btnGoToCollectionEvents.Size = new Size(245, 29);
            btnGoToCollectionEvents.TabIndex = 8;
            btnGoToCollectionEvents.Text = "Аукціони та комісійні магазини ";
            btnGoToCollectionEvents.UseVisualStyleBackColor = true;
            btnGoToCollectionEvents.Click += btnGoToCollectionEvents_Click;
            // 
            // button1
            // 
            button1.Location = new Point(662, 12);
            button1.Name = "button1";
            button1.Size = new Size(131, 29);
            button1.TabIndex = 9;
            button1.Text = "Моя колекція ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnClearFilterPainting
            // 
            btnClearFilterPainting.Location = new Point(420, 58);
            btnClearFilterPainting.Name = "btnClearFilterPainting";
            btnClearFilterPainting.Size = new Size(132, 29);
            btnClearFilterPainting.TabIndex = 16;
            btnClearFilterPainting.Text = "Скинути пошук";
            btnClearFilterPainting.UseVisualStyleBackColor = true;
            btnClearFilterPainting.Click += btnClearFilterPainting_Click;
            // 
            // btnApplyFilterPainting
            // 
            btnApplyFilterPainting.Location = new Point(320, 58);
            btnApplyFilterPainting.Name = "btnApplyFilterPainting";
            btnApplyFilterPainting.Size = new Size(94, 29);
            btnApplyFilterPainting.TabIndex = 15;
            btnApplyFilterPainting.Text = "Пошук";
            btnApplyFilterPainting.UseVisualStyleBackColor = true;
            btnApplyFilterPainting.Click += btnApplyFilterPainting_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 63);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 14;
            label1.Text = "Пошук:";
            // 
            // txtSearchPainting
            // 
            txtSearchPainting.Location = new Point(75, 60);
            txtSearchPainting.Name = "txtSearchPainting";
            txtSearchPainting.Size = new Size(239, 27);
            txtSearchPainting.TabIndex = 13;
            txtSearchPainting.TextChanged += txtSearchPainting_TextChanged;
            // 
            // btnExportPaintingToPdf
            // 
            btnExportPaintingToPdf.Location = new Point(610, 344);
            btnExportPaintingToPdf.Name = "btnExportPaintingToPdf";
            btnExportPaintingToPdf.Size = new Size(152, 29);
            btnExportPaintingToPdf.TabIndex = 17;
            btnExportPaintingToPdf.Text = "Перетворити в PDF";
            btnExportPaintingToPdf.UseVisualStyleBackColor = true;
            btnExportPaintingToPdf.Click += btnExportPaintingToPdf_Click;
            // 
            // PaintingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportPaintingToPdf);
            Controls.Add(btnClearFilterPainting);
            Controls.Add(btnApplyFilterPainting);
            Controls.Add(label1);
            Controls.Add(txtSearchPainting);
            Controls.Add(button1);
            Controls.Add(btnGoToCollectionEvents);
            Controls.Add(btnGoToPaintings);
            Controls.Add(btnDeletePainting);
            Controls.Add(btnEditPainting);
            Controls.Add(btnAddPainting);
            Controls.Add(btnGoToMuseums);
            Controls.Add(btnGoToArtists);
            Controls.Add(paintingsDataGridView);
            Name = "PaintingForm";
            Text = "Картини";
            Load += PaintingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)paintingsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView paintingsDataGridView;
        private Button btnGoToArtists;
        private Button btnGoToMuseums;
        private Button btnAddPainting;
        private Button btnEditPainting;
        private Button btnDeletePainting;
        private Button btnGoToPaintings;
        private Button btnGoToCollectionEvents;
        private Button button1;
        private Button btnClearFilterPainting;
        private Button btnApplyFilterPainting;
        private Label label1;
        private TextBox txtSearchPainting;
        private Button btnExportPaintingToPdf;
    }
}