namespace Coursework_Sytnik
{
    partial class CollectionEventsForm
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
            collectionEventsDataGridView = new DataGridView();
            btnAddEvent = new Button();
            btnEditEvent = new Button();
            btnDeleteEvent = new Button();
            btnGoToArtists = new Button();
            btnGoToMuseums = new Button();
            btnGoToPaintings = new Button();
            btnGoToCollectionEvents = new Button();
            btnToMyCollection = new Button();
            btnClearFilterEvent = new Button();
            btnApplyFilterEvent = new Button();
            label1 = new Label();
            txtSearchEvent = new TextBox();
            btnExportEventToPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)collectionEventsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // collectionEventsDataGridView
            // 
            collectionEventsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            collectionEventsDataGridView.Location = new Point(12, 102);
            collectionEventsDataGridView.Name = "collectionEventsDataGridView";
            collectionEventsDataGridView.RowHeadersWidth = 51;
            collectionEventsDataGridView.Size = new Size(540, 336);
            collectionEventsDataGridView.TabIndex = 0;
            // 
            // btnAddEvent
            // 
            btnAddEvent.Location = new Point(626, 102);
            btnAddEvent.Name = "btnAddEvent";
            btnAddEvent.Size = new Size(123, 29);
            btnAddEvent.TabIndex = 1;
            btnAddEvent.Text = "Додати подію ";
            btnAddEvent.UseVisualStyleBackColor = true;
            // 
            // btnEditEvent
            // 
            btnEditEvent.Location = new Point(613, 137);
            btnEditEvent.Name = "btnEditEvent";
            btnEditEvent.Size = new Size(145, 29);
            btnEditEvent.TabIndex = 2;
            btnEditEvent.Text = "Редагувати подію ";
            btnEditEvent.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEvent
            // 
            btnDeleteEvent.Location = new Point(617, 172);
            btnDeleteEvent.Name = "btnDeleteEvent";
            btnDeleteEvent.Size = new Size(141, 29);
            btnDeleteEvent.TabIndex = 3;
            btnDeleteEvent.Text = "Видалити подію";
            btnDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // btnGoToArtists
            // 
            btnGoToArtists.Location = new Point(13, 12);
            btnGoToArtists.Name = "btnGoToArtists";
            btnGoToArtists.Size = new Size(100, 29);
            btnGoToArtists.TabIndex = 9;
            btnGoToArtists.Text = "Художники";
            btnGoToArtists.UseVisualStyleBackColor = true;
            // 
            // btnGoToMuseums
            // 
            btnGoToMuseums.Location = new Point(219, 12);
            btnGoToMuseums.Name = "btnGoToMuseums";
            btnGoToMuseums.Size = new Size(142, 29);
            btnGoToMuseums.TabIndex = 8;
            btnGoToMuseums.Text = "Музеї та колекції ";
            btnGoToMuseums.UseVisualStyleBackColor = true;
            // 
            // btnGoToPaintings
            // 
            btnGoToPaintings.Location = new Point(119, 12);
            btnGoToPaintings.Name = "btnGoToPaintings";
            btnGoToPaintings.Size = new Size(94, 29);
            btnGoToPaintings.TabIndex = 7;
            btnGoToPaintings.Text = "Картини";
            btnGoToPaintings.UseVisualStyleBackColor = true;
            // 
            // btnGoToCollectionEvents
            // 
            btnGoToCollectionEvents.Location = new Point(367, 12);
            btnGoToCollectionEvents.Name = "btnGoToCollectionEvents";
            btnGoToCollectionEvents.Size = new Size(245, 29);
            btnGoToCollectionEvents.TabIndex = 10;
            btnGoToCollectionEvents.Text = "Аукціони та комісійні магазини ";
            btnGoToCollectionEvents.UseVisualStyleBackColor = true;
            btnGoToCollectionEvents.Click += btnGoToCollectionEvents_Click;
            // 
            // btnToMyCollection
            // 
            btnToMyCollection.Location = new Point(618, 12);
            btnToMyCollection.Name = "btnToMyCollection";
            btnToMyCollection.Size = new Size(131, 29);
            btnToMyCollection.TabIndex = 11;
            btnToMyCollection.Text = "Моя колекція ";
            btnToMyCollection.UseVisualStyleBackColor = true;
            btnToMyCollection.Click += btnToMyCollection_Click;
            // 
            // btnClearFilterEvent
            // 
            btnClearFilterEvent.Location = new Point(431, 57);
            btnClearFilterEvent.Name = "btnClearFilterEvent";
            btnClearFilterEvent.Size = new Size(171, 29);
            btnClearFilterEvent.TabIndex = 16;
            btnClearFilterEvent.Text = "Скинути фільтрацію ";
            btnClearFilterEvent.UseVisualStyleBackColor = true;
            btnClearFilterEvent.Click += btnClearFilterEvent_Click;
            // 
            // btnApplyFilterEvent
            // 
            btnApplyFilterEvent.Location = new Point(321, 57);
            btnApplyFilterEvent.Name = "btnApplyFilterEvent";
            btnApplyFilterEvent.Size = new Size(104, 29);
            btnApplyFilterEvent.TabIndex = 15;
            btnApplyFilterEvent.Text = "Фільтрувати ";
            btnApplyFilterEvent.UseVisualStyleBackColor = true;
            btnApplyFilterEvent.Click += btnApplyFilterEvent_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 14;
            label1.Text = "Пошук:";
            // 
            // txtSearchEvent
            // 
            txtSearchEvent.Location = new Point(76, 59);
            txtSearchEvent.Name = "txtSearchEvent";
            txtSearchEvent.Size = new Size(239, 27);
            txtSearchEvent.TabIndex = 13;
            // 
            // btnExportEventToPdf
            // 
            btnExportEventToPdf.Location = new Point(605, 318);
            btnExportEventToPdf.Name = "btnExportEventToPdf";
            btnExportEventToPdf.Size = new Size(156, 29);
            btnExportEventToPdf.TabIndex = 17;
            btnExportEventToPdf.Text = "Перетворити в PDF";
            btnExportEventToPdf.UseVisualStyleBackColor = true;
            btnExportEventToPdf.Click += btnExportEventToPdf_Click;
            // 
            // CollectionEventsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportEventToPdf);
            Controls.Add(btnClearFilterEvent);
            Controls.Add(btnApplyFilterEvent);
            Controls.Add(label1);
            Controls.Add(txtSearchEvent);
            Controls.Add(btnToMyCollection);
            Controls.Add(btnGoToCollectionEvents);
            Controls.Add(btnGoToArtists);
            Controls.Add(btnGoToMuseums);
            Controls.Add(btnGoToPaintings);
            Controls.Add(btnDeleteEvent);
            Controls.Add(btnEditEvent);
            Controls.Add(btnAddEvent);
            Controls.Add(collectionEventsDataGridView);
            Name = "CollectionEventsForm";
            Text = "Аукціони та комісійні магазини ";
            Load += CollectionEventsForm_Load;
            ((System.ComponentModel.ISupportInitialize)collectionEventsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView collectionEventsDataGridView;
        private Button btnAddEvent;
        private Button btnEditEvent;
        private Button btnDeleteEvent;
        private Button btnGoToArtists;
        private Button btnGoToMuseums;
        private Button btnGoToPaintings;
        private Button btnGoToCollectionEvents;
        private Button btnToMyCollection;
        private Button btnClearFilterEvent;
        private Button btnApplyFilterEvent;
        private Label label1;
        private TextBox txtSearchEvent;
        private Button btnExportEventToPdf;
    }
}