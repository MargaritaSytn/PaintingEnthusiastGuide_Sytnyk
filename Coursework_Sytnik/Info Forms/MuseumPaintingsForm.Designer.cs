namespace Coursework_Sytnik
{
    partial class MuseumPaintingsForm
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
            dataGridViewPaintings = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPaintings).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPaintings
            // 
            dataGridViewPaintings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPaintings.Location = new Point(12, 12);
            dataGridViewPaintings.Name = "dataGridViewPaintings";
            dataGridViewPaintings.RowHeadersWidth = 51;
            dataGridViewPaintings.Size = new Size(434, 217);
            dataGridViewPaintings.TabIndex = 0;
            // 
            // MuseumPaintingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 241);
            Controls.Add(dataGridViewPaintings);
            Name = "MuseumPaintingsForm";
            Text = "Список картин музею";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPaintings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewPaintings;
    }
}