namespace Coursework_Sytnik
{
    partial class ArtistBiographyForm
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
            lblArtistName = new Label();
            rtbBiography = new RichTextBox();
            SuspendLayout();
            // 
            // lblArtistName
            // 
            lblArtistName.AutoSize = true;
            lblArtistName.Location = new Point(12, 9);
            lblArtistName.Name = "lblArtistName";
            lblArtistName.Size = new Size(50, 20);
            lblArtistName.TabIndex = 0;
            lblArtistName.Text = "label1";
            // 
            // rtbBiography
            // 
            rtbBiography.Location = new Point(12, 32);
            rtbBiography.Name = "rtbBiography";
            rtbBiography.ReadOnly = true;
            rtbBiography.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbBiography.Size = new Size(342, 235);
            rtbBiography.TabIndex = 1;
            rtbBiography.Text = "";
            // 
            // ArtistBiographyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 279);
            Controls.Add(rtbBiography);
            Controls.Add(lblArtistName);
            Name = "ArtistBiographyForm";
            Text = "Біографія";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblArtistName;
        private RichTextBox rtbBiography;
    }
}