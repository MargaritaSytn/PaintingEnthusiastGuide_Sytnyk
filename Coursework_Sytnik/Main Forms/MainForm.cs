using Coursework_Sytnik.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Coursework_Sytnik
{
    public partial class MainForm : Form
    {
        private List<Artist> _allArtists;
        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            btnGoToPaintings.Click += btnGoToPaintings_Click;
            btnGoToMuseums.Click += btnGoToMuseums_Click;
            btnAddArtist.Click += btnAddArtist_Click;
            btnEditArtist.Click += btnEditArtist_Click;
            btnDeleteArtist.Click += btnDeleteArtist_Click;


            RefreshArtistsGrid();
        }
        private void ApplyFilterAndSort()
        {
            string filterText = txtSearchArtist.Text.Trim().ToLower();

            IEnumerable<Artist> filteredArtists = _allArtists;

            if (!string.IsNullOrWhiteSpace(filterText))
            {
                filteredArtists = _allArtists.Where(a =>
                    (a.FirstName != null && a.FirstName.ToLower().Contains(filterText)) ||
                    (a.LastName != null && a.LastName.ToLower().Contains(filterText)) ||
                    (a.Country != null && a.Country.ToLower().Contains(filterText)) ||
                    (a.YearsOfLife != null && a.YearsOfLife.ToLower().Contains(filterText)) ||
                    (a.StylesDisplay != null && a.StylesDisplay.ToLower().Contains(filterText))
                ).ToList();
            }

            artistsDataGridView.DataSource = null;
            artistsDataGridView.DataSource = filteredArtists.ToList();

            HideColumn("Id");
            HideColumn("FullName");
            HideColumn("Biography");
            HideColumn("Styles");

            SetColumnHeader("FirstName", "Ім'я", 0);
            SetColumnHeader("LastName", "Прізвище", 1);
            SetColumnHeader("YearsOfLife", "Роки життя", 2);
            SetColumnHeader("Country", "Країна", 3);

            if (artistsDataGridView.Columns.Contains("StylesDisplay"))
            {
                var col = artistsDataGridView.Columns["StylesDisplay"];
                col.HeaderText = "Стилі";
                col.DisplayIndex = 4;
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            artistsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            artistsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void RefreshArtistsGrid()
        {
            _allArtists = DataManager.Instance.Artists.ToList();
            artistsDataGridView.DataSource = null;
            artistsDataGridView.DataSource = DataManager.Instance.Artists.ToList();

            HideColumn("Id");
            HideColumn("FullName");
            HideColumn("Biography");
            HideColumn("Styles");

            SetColumnHeader("FirstName", "Ім'я", 0);
            SetColumnHeader("LastName", "Прізвище", 1);
            SetColumnHeader("YearsOfLife", "Роки життя", 2);
            SetColumnHeader("Country", "Країна", 3);

            if (artistsDataGridView.Columns.Contains("StylesDisplay"))
            {
                var col = artistsDataGridView.Columns["StylesDisplay"];
                col.HeaderText = "Стилі";
                col.DisplayIndex = 4;
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            artistsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            artistsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void HideColumn(string columnName)
        {
            if (artistsDataGridView.Columns.Contains(columnName))
                artistsDataGridView.Columns[columnName].Visible = false;
        }

        private void SetColumnHeader(string columnName, string headerText, int displayIndex)
        {
            if (artistsDataGridView.Columns.Contains(columnName))
            {
                var column = artistsDataGridView.Columns[columnName];
                column.HeaderText = headerText;
                column.DisplayIndex = displayIndex;
            }
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            using var editForm = new ArtistEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
                RefreshArtistsGrid();
        }

        private void btnEditArtist_Click(object sender, EventArgs e)
        {
            if (artistsDataGridView.CurrentRow?.DataBoundItem is Artist selectedArtist)
            {
                using var editForm = new ArtistEditForm(selectedArtist.Id);
                if (editForm.ShowDialog() == DialogResult.OK)
                    RefreshArtistsGrid();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть художника для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteArtist_Click(object sender, EventArgs e)
        {
            if (artistsDataGridView.CurrentRow?.DataBoundItem is Artist selectedArtist)
            {
                var confirmResult = MessageBox.Show(
                    $"Ви впевнені, що хочете видалити художника {selectedArtist.FirstName} {selectedArtist.LastName}? Всі пов'язані картини буде відв'язано.",
                    "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    DataManager.Instance.DeleteArtist(selectedArtist.Id);
                    RefreshArtistsGrid();
                    MessageBox.Show("Художника успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть художника для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGoToPaintings_Click(object sender, EventArgs e)
        {
            Hide();
            using var paintingsForm = new PaintingForm();
            paintingsForm.ShowDialog();
            Show();
        }

        private void btnGoToMuseums_Click(object sender, EventArgs e)
        {
            Hide();
            using var museumsForm = new MuseumForm();
            museumsForm.ShowDialog();
            Show();
        }

        private void btnGoToCollectionEvents_Click(object sender, EventArgs e)
        {
            Hide();
            using var collectionEventsForm = new CollectionEventsForm();
            collectionEventsForm.ShowDialog();
            Show();
        }

        private void btnToMyCollection_Click(object sender, EventArgs e)
        {
            Hide();
            using var myCollectionForm = new MyCollectionForm();
            myCollectionForm.ShowDialog();
            Show();
        }

        private void btnGoToArtists_Click(object sender, EventArgs e)
        {
            Show();
            Activate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();

        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearchArtist.Text = "";
            RefreshArtistsGrid();

        }

        private void btnViewBiography_Click(object sender, EventArgs e)
        {
            if (artistsDataGridView.CurrentRow != null &&
                artistsDataGridView.CurrentRow.DataBoundItem is Artist selectedArtist)
            {
                var bioForm = new ArtistBiographyForm(selectedArtist);
                bioForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть художника.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void artistsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnExportArtistToPdf_Click_1(object sender, EventArgs e)
        {
            if (artistsDataGridView.CurrentRow != null && artistsDataGridView.CurrentRow.DataBoundItem is Artist selectedArtist)
            {
                ArtistPdfGenerator.GenerateArtistPdf(selectedArtist);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть художника для експорту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}