namespace Coursework_Sytnik
{
    partial class MuseumEditForm
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
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            numericUpDownX = new NumericUpDown();
            numericUpDownY = new NumericUpDown();
            selectedPaintingsListBox = new ListBox();
            availablePaintingsListBox = new ListBox();
            btnAddSelectedPainting = new Button();
            btnRemoveSelectedPainting = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            label4 = new Label();
            label3 = new Label();
            Адреса = new Label();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 15);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(140, 55);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 1;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(140, 101);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(125, 27);
            txtCity.TabIndex = 2;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(140, 141);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(125, 27);
            txtCountry.TabIndex = 3;
            // 
            // numericUpDownX
            // 
            numericUpDownX.Location = new Point(180, 190);
            numericUpDownX.Name = "numericUpDownX";
            numericUpDownX.Size = new Size(150, 27);
            numericUpDownX.TabIndex = 4;
            // 
            // numericUpDownY
            // 
            numericUpDownY.Location = new Point(180, 239);
            numericUpDownY.Name = "numericUpDownY";
            numericUpDownY.Size = new Size(150, 27);
            numericUpDownY.TabIndex = 5;
            // 
            // selectedPaintingsListBox
            // 
            selectedPaintingsListBox.FormattingEnabled = true;
            selectedPaintingsListBox.Location = new Point(23, 311);
            selectedPaintingsListBox.Name = "selectedPaintingsListBox";
            selectedPaintingsListBox.Size = new Size(150, 104);
            selectedPaintingsListBox.TabIndex = 6;
            // 
            // availablePaintingsListBox
            // 
            availablePaintingsListBox.FormattingEnabled = true;
            availablePaintingsListBox.Location = new Point(198, 311);
            availablePaintingsListBox.Name = "availablePaintingsListBox";
            availablePaintingsListBox.Size = new Size(150, 104);
            availablePaintingsListBox.TabIndex = 7;
            // 
            // btnAddSelectedPainting
            // 
            btnAddSelectedPainting.Location = new Point(23, 434);
            btnAddSelectedPainting.Name = "btnAddSelectedPainting";
            btnAddSelectedPainting.Size = new Size(150, 29);
            btnAddSelectedPainting.TabIndex = 8;
            btnAddSelectedPainting.Text = "Додати картину";
            btnAddSelectedPainting.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSelectedPainting
            // 
            btnRemoveSelectedPainting.Location = new Point(198, 434);
            btnRemoveSelectedPainting.Name = "btnRemoveSelectedPainting";
            btnRemoveSelectedPainting.Size = new Size(150, 29);
            btnRemoveSelectedPainting.TabIndex = 9;
            btnRemoveSelectedPainting.Text = "Видалити картину";
            btnRemoveSelectedPainting.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(68, 521);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(198, 521);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Відміна";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 141);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 19;
            label4.Text = "Країна:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 101);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 18;
            label3.Text = "Місто:";
            label3.Click += label3_Click;
            // 
            // Адреса
            // 
            Адреса.AutoSize = true;
            Адреса.Location = new Point(24, 62);
            Адреса.Name = "Адреса";
            Адреса.Size = new Size(62, 20);
            Адреса.TabIndex = 17;
            Адреса.Text = "Адреса:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 22);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 16;
            label1.Text = "Назва:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 213);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 20;
            label2.Text = "Координати:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(153, 192);
            label5.Name = "label5";
            label5.Size = new Size(21, 20);
            label5.TabIndex = 21;
            label5.Text = "X:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(153, 241);
            label6.Name = "label6";
            label6.Size = new Size(20, 20);
            label6.TabIndex = 22;
            label6.Text = "Y:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 288);
            label7.Name = "label7";
            label7.Size = new Size(123, 20);
            label7.TabIndex = 23;
            label7.Text = "Обрані картини:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(198, 288);
            label8.Name = "label8";
            label8.Size = new Size(134, 20);
            label8.TabIndex = 24;
            label8.Text = "Доступні картини:";
            // 
            // MuseumEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 572);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Адреса);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnRemoveSelectedPainting);
            Controls.Add(btnAddSelectedPainting);
            Controls.Add(availablePaintingsListBox);
            Controls.Add(selectedPaintingsListBox);
            Controls.Add(numericUpDownY);
            Controls.Add(numericUpDownX);
            Controls.Add(txtCountry);
            Controls.Add(txtCity);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Name = "MuseumEditForm";
            Text = "Form3";
            Load += MuseumEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtCity;
        private TextBox txtCountry;
        private NumericUpDown numericUpDownX;
        private NumericUpDown numericUpDownY;
        private ListBox selectedPaintingsListBox;
        private ListBox availablePaintingsListBox;
        private Button btnAddSelectedPainting;
        private Button btnRemoveSelectedPainting;
        private Button btnSave;
        private Button btnCancel;
        private Label label4;
        private Label label3;
        private Label Адреса;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}