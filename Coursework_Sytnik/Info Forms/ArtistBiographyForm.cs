using Coursework_Sytnik.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Sytnik
{
    public partial class ArtistBiographyForm: Form
    {
        public ArtistBiographyForm(Artist artist)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            lblArtistName.Text = artist.FullName;
            rtbBiography.Text = artist.Biography;
        }
    }
}
