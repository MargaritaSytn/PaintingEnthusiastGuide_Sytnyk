namespace Coursework_Sytnik
{
    partial class MyCollectionEditForm
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
            cmbAuctionEvents = new ComboBox();
            dtpPurchaseDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            lblAuctionEvent = new Label();
            lblAvailablePaintings = new Label();
            cmbAvailablePaintings = new ComboBox();
            lblPaintingTitle = new Label();
            lblPurchasePrice = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbAuctionEvents
            // 
            cmbAuctionEvents.FormattingEnabled = true;
            cmbAuctionEvents.Location = new Point(165, 15);
            cmbAuctionEvents.Name = "cmbAuctionEvents";
            cmbAuctionEvents.Size = new Size(194, 28);
            cmbAuctionEvents.TabIndex = 0;
            // 
            // dtpPurchaseDate
            // 
            dtpPurchaseDate.Location = new Point(65, 223);
            dtpPurchaseDate.Name = "dtpPurchaseDate";
            dtpPurchaseDate.Size = new Size(250, 27);
            dtpPurchaseDate.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(70, 284);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "Зберегти ";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(211, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Відміна ";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAuctionEvent
            // 
            lblAuctionEvent.AutoSize = true;
            lblAuctionEvent.Location = new Point(16, 15);
            lblAuctionEvent.Name = "lblAuctionEvent";
            lblAuctionEvent.Size = new Size(135, 20);
            lblAuctionEvent.TabIndex = 9;
            lblAuctionEvent.Text = "Місце придбання:";
            // 
            // lblAvailablePaintings
            // 
            lblAvailablePaintings.AutoSize = true;
            lblAvailablePaintings.Location = new Point(16, 67);
            lblAvailablePaintings.Name = "lblAvailablePaintings";
            lblAvailablePaintings.Size = new Size(143, 20);
            lblAvailablePaintings.TabIndex = 10;
            lblAvailablePaintings.Text = "Придбана картина:";
            // 
            // cmbAvailablePaintings
            // 
            cmbAvailablePaintings.FormattingEnabled = true;
            cmbAvailablePaintings.Location = new Point(165, 64);
            cmbAvailablePaintings.Name = "cmbAvailablePaintings";
            cmbAvailablePaintings.Size = new Size(194, 28);
            cmbAvailablePaintings.TabIndex = 11;
            cmbAvailablePaintings.SelectedIndexChanged += cmbAvailablePaintings_SelectedIndexChanged_1;
            // 
            // lblPaintingTitle
            // 
            lblPaintingTitle.AutoSize = true;
            lblPaintingTitle.Location = new Point(16, 117);
            lblPaintingTitle.Name = "lblPaintingTitle";
            lblPaintingTitle.Size = new Size(50, 20);
            lblPaintingTitle.TabIndex = 3;
            lblPaintingTitle.Text = "label1";
            // 
            // lblPurchasePrice
            // 
            lblPurchasePrice.AutoSize = true;
            lblPurchasePrice.Location = new Point(16, 154);
            lblPurchasePrice.Name = "lblPurchasePrice";
            lblPurchasePrice.Size = new Size(50, 20);
            lblPurchasePrice.TabIndex = 4;
            lblPurchasePrice.Text = "label2";
            lblPurchasePrice.Click += lblPurchasePrice_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 198);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 12;
            label1.Text = "Дата придбання";
            // 
            // MyCollectionEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 332);
            Controls.Add(label1);
            Controls.Add(cmbAvailablePaintings);
            Controls.Add(lblAvailablePaintings);
            Controls.Add(lblAuctionEvent);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpPurchaseDate);
            Controls.Add(lblPurchasePrice);
            Controls.Add(lblPaintingTitle);
            Controls.Add(cmbAuctionEvents);
            Name = "MyCollectionEditForm";
            Text = "Form1";
            Load += MyCollectionEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAuctionEvents;
        private DateTimePicker dtpPurchaseDate;
        private Button btnSave;
        private Button btnCancel;
        private Label lblAuctionEvent;
        private Label lblAvailablePaintings;
        private ComboBox cmbAvailablePaintings;
        private Label lblPaintingTitle;
        private Label lblPurchasePrice;
        private Label label1;
    }
}