namespace Coursework_Sytnik
{
    partial class PaintingEditForm
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
            txtTitle = new TextBox();
            txtGenre = new TextBox();
            numericUpDownYear = new NumericUpDown();
            cmbArtists = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            label4 = new Label();
            label3 = new Label();
            Адреса = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownYear).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(239, 16);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(125, 27);
            txtTitle.TabIndex = 0;
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(239, 59);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(125, 27);
            txtGenre.TabIndex = 1;
            // 
            // numericUpDownYear
            // 
            numericUpDownYear.Location = new Point(239, 96);
            numericUpDownYear.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownYear.Name = "numericUpDownYear";
            numericUpDownYear.Size = new Size(150, 27);
            numericUpDownYear.TabIndex = 2;
            // 
            // cmbArtists
            // 
            cmbArtists.FormattingEnabled = true;
            cmbArtists.Location = new Point(239, 135);
            cmbArtists.Name = "cmbArtists";
            cmbArtists.Size = new Size(151, 28);
            cmbArtists.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(92, 216);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(230, 216);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Відмінити";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 24;
            label4.Text = "Художник:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 98);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 23;
            label3.Text = "Рік створення:";
            // 
            // Адреса
            // 
            Адреса.AutoSize = true;
            Адреса.Location = new Point(12, 59);
            Адреса.Name = "Адреса";
            Адреса.Size = new Size(51, 20);
            Адреса.TabIndex = 22;
            Адреса.Text = "Жанр:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 21;
            label1.Text = "Назва:";
            // 
            // PaintingEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 265);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Адреса);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbArtists);
            Controls.Add(numericUpDownYear);
            Controls.Add(txtGenre);
            Controls.Add(txtTitle);
            Name = "PaintingEditForm";
            Text = "Form2";
            Load += PaintingEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtGenre;
        private NumericUpDown numericUpDownYear;
        private ComboBox cmbArtists;
        private Button btnSave;
        private Button btnCancel;
        private Label label4;
        private Label label3;
        private Label Адреса;
        private Label label1;
    }
}