namespace Coursework_Sytnik
{
    partial class CollectionEventEditForm
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
            txtEventName = new TextBox();
            rbAuction = new RadioButton();
            rbCommissionShop = new RadioButton();
            groupBox1 = new GroupBox();
            dtpEventDate = new DateTimePicker();
            btnAddPaintingToEvent = new Button();
            btnRemovePaintingFromEvent = new Button();
            availablePaintingsListBox = new ListBox();
            paintingsInEventListBox = new ListBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            btnEditPaintingPrice = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtEventName
            // 
            txtEventName.Location = new Point(129, 25);
            txtEventName.Name = "txtEventName";
            txtEventName.Size = new Size(181, 27);
            txtEventName.TabIndex = 0;
            // 
            // rbAuction
            // 
            rbAuction.AutoSize = true;
            rbAuction.Location = new Point(6, 26);
            rbAuction.Name = "rbAuction";
            rbAuction.Size = new Size(85, 24);
            rbAuction.TabIndex = 1;
            rbAuction.TabStop = true;
            rbAuction.Text = "Аукціон";
            rbAuction.UseVisualStyleBackColor = true;
            // 
            // rbCommissionShop
            // 
            rbCommissionShop.AutoSize = true;
            rbCommissionShop.Location = new Point(129, 26);
            rbCommissionShop.Name = "rbCommissionShop";
            rbCommissionShop.Size = new Size(167, 24);
            rbCommissionShop.TabIndex = 2;
            rbCommissionShop.TabStop = true;
            rbCommissionShop.Text = "Комісійні магазини";
            rbCommissionShop.UseVisualStyleBackColor = true;
            rbCommissionShop.CheckedChanged += rbCommissionShop_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbAuction);
            groupBox1.Controls.Add(rbCommissionShop);
            groupBox1.Location = new Point(43, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 71);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Аукціон чи комерційний магазин ";
            // 
            // dtpEventDate
            // 
            dtpEventDate.Location = new Point(183, 174);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(250, 27);
            dtpEventDate.TabIndex = 4;
            // 
            // btnAddPaintingToEvent
            // 
            btnAddPaintingToEvent.Location = new Point(34, 338);
            btnAddPaintingToEvent.Name = "btnAddPaintingToEvent";
            btnAddPaintingToEvent.Size = new Size(195, 29);
            btnAddPaintingToEvent.TabIndex = 6;
            btnAddPaintingToEvent.Text = "Додати картини до події ";
            btnAddPaintingToEvent.UseVisualStyleBackColor = true;
            // 
            // btnRemovePaintingFromEvent
            // 
            btnRemovePaintingFromEvent.Location = new Point(241, 338);
            btnRemovePaintingFromEvent.Name = "btnRemovePaintingFromEvent";
            btnRemovePaintingFromEvent.Size = new Size(198, 29);
            btnRemovePaintingFromEvent.TabIndex = 7;
            btnRemovePaintingFromEvent.Text = "Видалити картину з події";
            btnRemovePaintingFromEvent.UseVisualStyleBackColor = true;
            // 
            // availablePaintingsListBox
            // 
            availablePaintingsListBox.FormattingEnabled = true;
            availablePaintingsListBox.HorizontalScrollbar = true;
            availablePaintingsListBox.Location = new Point(101, 217);
            availablePaintingsListBox.Name = "availablePaintingsListBox";
            availablePaintingsListBox.Size = new Size(267, 104);
            availablePaintingsListBox.TabIndex = 5;
            // 
            // paintingsInEventListBox
            // 
            paintingsInEventListBox.FormattingEnabled = true;
            paintingsInEventListBox.HorizontalScrollbar = true;
            paintingsInEventListBox.Location = new Point(101, 386);
            paintingsInEventListBox.Name = "paintingsInEventListBox";
            paintingsInEventListBox.Size = new Size(267, 104);
            paintingsInEventListBox.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(115, 556);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 9;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(252, 556);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Закрити";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 28);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 11;
            label1.Text = "Назва:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 174);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 12;
            label2.Text = "Дата проведення:";
            // 
            // btnEditPaintingPrice
            // 
            btnEditPaintingPrice.Location = new Point(129, 496);
            btnEditPaintingPrice.Name = "btnEditPaintingPrice";
            btnEditPaintingPrice.Size = new Size(203, 29);
            btnEditPaintingPrice.TabIndex = 13;
            btnEditPaintingPrice.Text = "Редактувати ціну картини";
            btnEditPaintingPrice.UseVisualStyleBackColor = true;
            btnEditPaintingPrice.Click += btnEditPaintingPrice_Click;
            // 
            // CollectionEventEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 606);
            Controls.Add(btnEditPaintingPrice);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(paintingsInEventListBox);
            Controls.Add(btnRemovePaintingFromEvent);
            Controls.Add(btnAddPaintingToEvent);
            Controls.Add(availablePaintingsListBox);
            Controls.Add(dtpEventDate);
            Controls.Add(groupBox1);
            Controls.Add(txtEventName);
            Name = "CollectionEventEditForm";
            Text = "Form1";
            Load += CollectionEventEditForm_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEventName;
        private RadioButton rbAuction;
        private RadioButton rbCommissionShop;
        private GroupBox groupBox1;
        private DateTimePicker dtpEventDate;
        private Button btnAddPaintingToEvent;
        private Button btnRemovePaintingFromEvent;
        private ListBox availablePaintingsListBox;
        private ListBox paintingsInEventListBox;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Button btnEditPaintingPrice;
    }
}