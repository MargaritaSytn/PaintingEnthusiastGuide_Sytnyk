namespace Coursework_Sytnik
{
    partial class MyCollectionForm
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
            dataGridViewMyCollection = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnToMyCollection = new Button();
            btnGoToCollectionEvents = new Button();
            btnGoToMuseums = new Button();
            btnGoToPaintings = new Button();
            btnGoToArtists = new Button();
            btnClearFilterMyCollection = new Button();
            btnApplyFilterMyCollection = new Button();
            label1 = new Label();
            txtSearchMyCollection = new TextBox();
            btnGenerateReceipt = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMyCollection).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMyCollection
            // 
            dataGridViewMyCollection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMyCollection.Location = new Point(12, 102);
            dataGridViewMyCollection.Name = "dataGridViewMyCollection";
            dataGridViewMyCollection.RowHeadersWidth = 51;
            dataGridViewMyCollection.Size = new Size(540, 336);
            dataGridViewMyCollection.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(573, 101);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(208, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Придбати картину ";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(561, 136);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(229, 29);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редагувати придбану картину";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(566, 171);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(222, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Видалити придбану картину ";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnToMyCollection
            // 
            btnToMyCollection.Location = new Point(617, 12);
            btnToMyCollection.Name = "btnToMyCollection";
            btnToMyCollection.Size = new Size(131, 29);
            btnToMyCollection.TabIndex = 17;
            btnToMyCollection.Text = "Моя колекція ";
            btnToMyCollection.UseVisualStyleBackColor = true;
            btnToMyCollection.Click += btnToMyCollection_Click;
            // 
            // btnGoToCollectionEvents
            // 
            btnGoToCollectionEvents.Location = new Point(366, 12);
            btnGoToCollectionEvents.Name = "btnGoToCollectionEvents";
            btnGoToCollectionEvents.Size = new Size(245, 29);
            btnGoToCollectionEvents.TabIndex = 16;
            btnGoToCollectionEvents.Text = "Аукціони та комісійні магазини ";
            btnGoToCollectionEvents.UseVisualStyleBackColor = true;
            btnGoToCollectionEvents.Click += btnGoToCollectionEvents_Click;
            // 
            // btnGoToMuseums
            // 
            btnGoToMuseums.Location = new Point(219, 12);
            btnGoToMuseums.Name = "btnGoToMuseums";
            btnGoToMuseums.Size = new Size(141, 29);
            btnGoToMuseums.TabIndex = 15;
            btnGoToMuseums.Text = "Музеї та колекції ";
            btnGoToMuseums.UseVisualStyleBackColor = true;
            btnGoToMuseums.Click += btnGoToMuseums_Click;
            // 
            // btnGoToPaintings
            // 
            btnGoToPaintings.Location = new Point(119, 12);
            btnGoToPaintings.Name = "btnGoToPaintings";
            btnGoToPaintings.Size = new Size(94, 29);
            btnGoToPaintings.TabIndex = 14;
            btnGoToPaintings.Text = "Картини";
            btnGoToPaintings.UseVisualStyleBackColor = true;
            btnGoToPaintings.Click += btnGoToPaintings_Click;
            // 
            // btnGoToArtists
            // 
            btnGoToArtists.Location = new Point(11, 12);
            btnGoToArtists.Name = "btnGoToArtists";
            btnGoToArtists.Size = new Size(102, 29);
            btnGoToArtists.TabIndex = 13;
            btnGoToArtists.Text = "Художники ";
            btnGoToArtists.UseVisualStyleBackColor = true;
            btnGoToArtists.Click += btnGoToArtists_Click;
            // 
            // btnClearFilterMyCollection
            // 
            btnClearFilterMyCollection.Location = new Point(431, 56);
            btnClearFilterMyCollection.Name = "btnClearFilterMyCollection";
            btnClearFilterMyCollection.Size = new Size(171, 29);
            btnClearFilterMyCollection.TabIndex = 21;
            btnClearFilterMyCollection.Text = "Скинути фільтрацію ";
            btnClearFilterMyCollection.UseVisualStyleBackColor = true;
            btnClearFilterMyCollection.Click += btnClearFilterMyCollection_Click;
            // 
            // btnApplyFilterMyCollection
            // 
            btnApplyFilterMyCollection.Location = new Point(321, 56);
            btnApplyFilterMyCollection.Name = "btnApplyFilterMyCollection";
            btnApplyFilterMyCollection.Size = new Size(104, 29);
            btnApplyFilterMyCollection.TabIndex = 20;
            btnApplyFilterMyCollection.Text = "Фільтрувати ";
            btnApplyFilterMyCollection.UseVisualStyleBackColor = true;
            btnApplyFilterMyCollection.Click += btnApplyFilterMyCollection_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 19;
            label1.Text = "Пошук:";
            // 
            // txtSearchMyCollection
            // 
            txtSearchMyCollection.Location = new Point(76, 58);
            txtSearchMyCollection.Name = "txtSearchMyCollection";
            txtSearchMyCollection.Size = new Size(239, 27);
            txtSearchMyCollection.TabIndex = 18;
            // 
            // btnGenerateReceipt
            // 
            btnGenerateReceipt.Location = new Point(588, 337);
            btnGenerateReceipt.Name = "btnGenerateReceipt";
            btnGenerateReceipt.Size = new Size(182, 29);
            btnGenerateReceipt.TabIndex = 22;
            btnGenerateReceipt.Text = "Перетворити в PDF";
            btnGenerateReceipt.UseVisualStyleBackColor = true;
            btnGenerateReceipt.Click += btnGenerateReceipt_Click;
            // 
            // MyCollectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGenerateReceipt);
            Controls.Add(btnClearFilterMyCollection);
            Controls.Add(btnApplyFilterMyCollection);
            Controls.Add(label1);
            Controls.Add(txtSearchMyCollection);
            Controls.Add(btnToMyCollection);
            Controls.Add(btnGoToCollectionEvents);
            Controls.Add(btnGoToMuseums);
            Controls.Add(btnGoToPaintings);
            Controls.Add(btnGoToArtists);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewMyCollection);
            Name = "MyCollectionForm";
            Text = "Моя колекція ";
            Load += MyCollectionForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMyCollection).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewMyCollection;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnToMyCollection;
        private Button btnGoToCollectionEvents;
        private Button btnGoToMuseums;
        private Button btnGoToPaintings;
        private Button btnGoToArtists;
        private Button btnClearFilterMyCollection;
        private Button btnApplyFilterMyCollection;
        private Label label1;
        private TextBox txtSearchMyCollection;
        private Button btnGenerateReceipt;
    }
}