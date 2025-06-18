namespace Coursework_Sytnik
{
    partial class ArtistEditForm
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
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            yearsOfLifeTextBox = new TextBox();
            countryTextBox = new TextBox();
            biographyTextBox = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            newStyleTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(134, 24);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(152, 27);
            firstNameTextBox.TabIndex = 0;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(134, 67);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(152, 27);
            lastNameTextBox.TabIndex = 1;
            // 
            // yearsOfLifeTextBox
            // 
            yearsOfLifeTextBox.Location = new Point(134, 113);
            yearsOfLifeTextBox.Name = "yearsOfLifeTextBox";
            yearsOfLifeTextBox.Size = new Size(152, 27);
            yearsOfLifeTextBox.TabIndex = 2;
            // 
            // countryTextBox
            // 
            countryTextBox.Location = new Point(134, 157);
            countryTextBox.Name = "countryTextBox";
            countryTextBox.Size = new Size(152, 27);
            countryTextBox.TabIndex = 3;
            // 
            // biographyTextBox
            // 
            biographyTextBox.Location = new Point(134, 192);
            biographyTextBox.Multiline = true;
            biographyTextBox.Name = "biographyTextBox";
            biographyTextBox.ScrollBars = ScrollBars.Vertical;
            biographyTextBox.Size = new Size(278, 104);
            biographyTextBox.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(84, 409);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Зберегти ";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(280, 409);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Закрити";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // newStyleTextBox
            // 
            newStyleTextBox.Location = new Point(134, 313);
            newStyleTextBox.Name = "newStyleTextBox";
            newStyleTextBox.Size = new Size(230, 27);
            newStyleTextBox.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 27);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 11;
            label1.Text = "Ім'я:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 67);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 12;
            label2.Text = "Прізвище:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 116);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 13;
            label3.Text = "Роки життя:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 160);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 14;
            label4.Text = "Країна:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 204);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 15;
            label5.Text = "Біографія:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 316);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 16;
            label6.Text = "Стилі:";
            // 
            // ArtistEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(newStyleTextBox);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(biographyTextBox);
            Controls.Add(countryTextBox);
            Controls.Add(yearsOfLifeTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Name = "ArtistEditForm";
            Text = "Form1";
            Load += ArtistEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox yearsOfLifeTextBox;
        private TextBox countryTextBox;
        private TextBox biographyTextBox;
        private Button btnSave;
        private Button btnCancel;
        private TextBox newStyleTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}