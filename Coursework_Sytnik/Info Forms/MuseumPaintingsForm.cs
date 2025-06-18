using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coursework_Sytnik.Classes;

namespace Coursework_Sytnik
{
    public partial class MuseumPaintingsForm : Form
    {
        private int museumId;

        public MuseumPaintingsForm(int museumId)
        {
            InitializeComponent();
            this.museumId = museumId;
            this.StartPosition = FormStartPosition.CenterScreen;
            Load += MuseumPaintingsForm_Load;
        }

        private void MuseumPaintingsForm_Load(object sender, EventArgs e)
        {
            var museum = DataManager.Instance.GetMuseumById(museumId);
            if (museum == null)
            {
                MessageBox.Show("Музей не знайдено.");
                return;
            }

            var paintings = museum.PaintingIds
                .Select(id => DataManager.Instance.GetPaintingById(id))
                .Where(p => p != null)
                .Select(p => new
                {
                    Назва = p.Title,
                    Художник = p.ArtistId.HasValue
                        ? DataManager.Instance.GetArtistById(p.ArtistId.Value)?.FullName ?? "Невідомо"
                        : "Невідомо",
                    Рік = p.CreationYear,
                    Жанр = p.Genre
                })
                .ToList();

            paintingsDataGridView.DataSource = paintings;
            this.Text = $"Картини в музеї \"{museum.Name}\"";

            paintingsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            paintingsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            paintingsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}