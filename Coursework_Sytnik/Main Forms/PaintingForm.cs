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
    public partial class PaintingForm : Form
    {
        public PaintingForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializeDataGridView();
            RefreshPaintingsGrid();

            btnGoToArtists.Click += btnGoToArtists_Click;
            btnGoToMuseums.Click += btnGoToMuseums_Click;
            btnEditPainting.Click += btnEditPainting_Click;
            btnDeletePainting.Click += btnDeletePainting_Click;
        }

        public class PaintingDisplay
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int CreationYear { get; set; }
            public string Genre { get; set; }
            public string ArtistName { get; set; }
            public string MuseumName { get; set; }
            public List<string> ArtistStyles { get; set; }

        }

        private void InitializeDataGridView()
        {
            paintingsDataGridView.AutoGenerateColumns = false;
            paintingsDataGridView.Columns.Clear();

            paintingsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Назва" });
            paintingsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CreationYear", HeaderText = "Рік створення" });
            paintingsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Genre", HeaderText = "Жанр" });
            paintingsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ArtistName", HeaderText = "Художник" });
            paintingsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MuseumName", HeaderText = "Музей" });

            foreach (DataGridViewColumn column in paintingsDataGridView.Columns)
            {
                column.ReadOnly = true;
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            paintingsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            paintingsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void RefreshPaintingsGrid()
        {
            var rawDisplayList = new List<PaintingDisplay>();
            foreach (var p in DataManager.Instance.Paintings)
            {
                Artist artist = null;
                if (p.ArtistId.HasValue)
                {
                    artist = DataManager.Instance.GetArtistById(p.ArtistId.Value);
                }

                var museum = p.MuseumId.HasValue ? DataManager.Instance.GetMuseumById(p.MuseumId.Value) : null;

                rawDisplayList.Add(new PaintingDisplay
                {
                    Id = p.Id,
                    Title = p.Title,
                    CreationYear = p.CreationYear,
                    Genre = p.Genre,
                    ArtistName = artist != null ? $"{artist.FirstName} {artist.LastName}" : "Невідомий",
                    MuseumName = museum != null ? museum.Name : "Не в музеї",
                    ArtistStyles = artist?.Styles ?? new List<string>()
                });
            }

            var filteredDisplayList = rawDisplayList.AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtSearchPainting.Text))
            {
                string searchTerm = txtSearchPainting.Text.ToLower();

                filteredDisplayList = filteredDisplayList.Where(pDisplay =>
                    pDisplay.Title.ToLower().Contains(searchTerm) ||
                    pDisplay.Genre.ToLower().Contains(searchTerm) ||
                    pDisplay.CreationYear.ToString().Contains(searchTerm) ||
                    pDisplay.ArtistName.ToLower().Contains(searchTerm) ||
                    pDisplay.MuseumName.ToLower().Contains(searchTerm) ||
                    (pDisplay.ArtistStyles != null && pDisplay.ArtistStyles.Any(s => s.ToLower().Contains(searchTerm)))
                );
            }

            paintingsDataGridView.DataSource = null;
            paintingsDataGridView.DataSource = filteredDisplayList.ToList();
        }

        private void btnEditPainting_Click(object sender, EventArgs e)
        {
            if (paintingsDataGridView.CurrentRow != null && paintingsDataGridView.CurrentRow.DataBoundItem is PaintingDisplay selectedPaintingDisplay)
            {
                var editForm = new PaintingEditForm(selectedPaintingDisplay.Id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPaintingsGrid();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeletePainting_Click(object sender, EventArgs e)
        {
            if (paintingsDataGridView.CurrentRow != null && paintingsDataGridView.CurrentRow.DataBoundItem is PaintingDisplay selectedPaintingDisplay)
            {
                var confirmResult = MessageBox.Show($"Ви впевнені, що хочете видалити картину '{selectedPaintingDisplay.Title}'?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    DataManager.Instance.DeletePainting(selectedPaintingDisplay.Id);
                    RefreshPaintingsGrid();
                    MessageBox.Show("Картину успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PaintingsForm_Load(object sender, EventArgs e)
        {
        }

        private void btnGoToArtists_Click(object sender, EventArgs e)
        {
            this.Hide();
            var goToArtists = new MainForm();
            goToArtists.ShowDialog();
            this.Show();
        }



        private void btnGoToMuseums_Click(object sender, EventArgs e)
        {
            this.Hide();
            var goToMuseums = new MuseumForm();
            goToMuseums.ShowDialog();
            this.Show();
        }

        private void btnGoToArtists_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGoToCollectionEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            var collectionEventsForm = new CollectionEventsForm();
            collectionEventsForm.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myCollectionForm = new MyCollectionForm();
            myCollectionForm.ShowDialog();
            this.Show();
        }

        private void btnApplyFilterPainting_Click(object sender, EventArgs e)
        {
            RefreshPaintingsGrid();
        }

        private void btnClearFilterPainting_Click(object sender, EventArgs e)
        {
            txtSearchPainting.Text = string.Empty;
            RefreshPaintingsGrid();
        }

        private void txtSearchPainting_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGoToPaintings_Click_1(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void btnExportPaintingToPdf_Click(object sender, EventArgs e)
        {
            if (paintingsDataGridView.CurrentRow != null && paintingsDataGridView.CurrentRow.DataBoundItem is PaintingDisplay selectedPaintingDisplay)
            {
                var selectedPainting = DataManager.Instance.Paintings
                                             .FirstOrDefault(p => p.Id == selectedPaintingDisplay.Id);

                if (selectedPainting != null)
                {
                    PaintingPdfGenerator.GeneratePaintingPdf(selectedPainting);
                }
                else
                {
                    MessageBox.Show("Не вдалося знайти дані картини.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину для експорту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddPainting_Click_1(object sender, EventArgs e)
        {
            var editForm = new PaintingEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshPaintingsGrid();
            }
        }

        private void paintingsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}