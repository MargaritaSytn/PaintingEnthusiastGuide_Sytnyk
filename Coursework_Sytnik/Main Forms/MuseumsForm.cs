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
using System.Globalization;

namespace Coursework_Sytnik
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public partial class MuseumForm : Form
    {
        public MuseumForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializeDataGridView();
            RefreshMuseumsGrid();
            btnGoToPaintings.Click += btnGoToPaintings_Click;
            btnGoToArtists.Click += btnGoToArtists_Click;
            btnAddMuseum.Click += btnAddMuseum_Click;
            btnEditMuseum.Click += btnEditMuseum_Click;
            btnDeleteMuseum.Click += btnDeleteMuseum_Click;
        }

        public class MuseumDisplay
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public double CoordinateX { get; set; }
            public double CoordinateY { get; set; }
            public string PaintingsCount { get; set; }
        }

        private void InitializeDataGridView()
        {
            museumsDataGridView.AutoGenerateColumns = false;

            museumsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Назва" });
            museumsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Адреса" });
            museumsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "City", HeaderText = "Місто" });
            museumsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Country", HeaderText = "Країна" });
            museumsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaintingsCount", HeaderText = "Кількість картин" });

            foreach (DataGridViewColumn column in museumsDataGridView.Columns)
            {
                column.ReadOnly = true;
            }
        }

        public void RefreshMuseumsGrid()
        {
            var allMuseums = DataManager.Instance.Museums;

            var displayList = allMuseums.Select(m => new MuseumDisplay
            {
                Id = m.Id,
                Name = m.Name,
                Address = m.Address,
                City = m.City,
                Country = m.Country,
                CoordinateX = m.CoordinateX,
                CoordinateY = m.CoordinateY,
                PaintingsCount = $"{m.PaintingIds.Count} картин"
            }).ToList();

            var filteredList = displayList.AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtSearchMuseum.Text))
            {
                string searchTerm = txtSearchMuseum.Text.ToLower();

                filteredList = filteredList.Where(m =>
                    m.Name.ToLower().Contains(searchTerm) ||
                    m.Address.ToLower().Contains(searchTerm) ||
                    m.City.ToLower().Contains(searchTerm) ||
                    m.Country.ToLower().Contains(searchTerm) ||
                    m.PaintingsCount.ToLower().Contains(searchTerm)
                );
            }

            museumsDataGridView.DataSource = null;
            museumsDataGridView.DataSource = filteredList.ToList();
        }

        private void btnAddMuseum_Click(object sender, EventArgs e)
        {
            var editForm = new MuseumEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshMuseumsGrid();
                RefreshPaintingsGridInOpenedForm();
            }
        }

        private void btnEditMuseum_Click(object sender, EventArgs e)
        {
            if (museumsDataGridView.CurrentRow != null && museumsDataGridView.CurrentRow.DataBoundItem is MuseumDisplay selectedMuseumDisplay)
            {
                var editForm = new MuseumEditForm(selectedMuseumDisplay.Id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshMuseumsGrid();
                    RefreshPaintingsGridInOpenedForm();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть музей для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteMuseum_Click(object sender, EventArgs e)
        {
            if (museumsDataGridView.CurrentRow != null && museumsDataGridView.CurrentRow.DataBoundItem is MuseumDisplay selectedMuseumDisplay)
            {
                var confirmResult = MessageBox.Show($"Ви впевнені, що хочете видалити музей '{selectedMuseumDisplay.Name}'? Усі пов'язані картини буде відв'язано.", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    DataManager.Instance.DeleteMuseum(selectedMuseumDisplay.Id);
                    RefreshMuseumsGrid();
                    MessageBox.Show("Музей успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть музей для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RefreshPaintingsGridInOpenedForm()
        {
            var paintingsForm = Application.OpenForms.OfType<PaintingForm>().FirstOrDefault();
            if (paintingsForm != null)
            {
                paintingsForm.RefreshPaintingsGrid();
            }
        }
        private void MuseumsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGoToArtists_Click_1(object sender, EventArgs e)
        {

        }
        private void btnGoToArtists_Click(object sender, EventArgs e)
        {
            this.Hide();
            var goToArtists = new MainForm();
            goToArtists.ShowDialog();
            this.Show();
        }
        private void btnGoToPaintings_Click(object sender, EventArgs e)
        {
            this.Hide();
            var paintingsForm = new PaintingForm();
            paintingsForm.ShowDialog();
            this.Show();
        }

        private void btnGoToMuseums_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void btnGoToCollectionEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            var collectionEventsForm = new CollectionEventsForm();
            collectionEventsForm.ShowDialog();
            this.Show();
        }

        private void btnToMyCollection_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myCollectionForm = new MyCollectionForm();
            myCollectionForm.ShowDialog();
            this.Show();
        }

        private void btnApplyFilterMuseum_Click(object sender, EventArgs e)
        {
            RefreshMuseumsGrid();
        }

        private void btnClearFilterMuseum_Click(object sender, EventArgs e)
        {
            txtSearchMuseum.Text = string.Empty;
            RefreshMuseumsGrid();
        }



        private void btnShowOnMap_Click_1(object sender, EventArgs e)
        {
            if (museumsDataGridView.CurrentRow != null && museumsDataGridView.CurrentRow.DataBoundItem is MuseumDisplay selectedMuseum)
            {
                string lat = selectedMuseum.CoordinateX.ToString(CultureInfo.InvariantCulture);
                string lng = selectedMuseum.CoordinateY.ToString(CultureInfo.InvariantCulture);

                string url = $"https://www.google.com/maps/search/?api=1&query={lat},{lng}";

                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не вдалося відкрити браузер: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть музей для відображення на карті.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShowMuseumPaintings_Click(object sender, EventArgs e)
        {
            if (museumsDataGridView.CurrentRow != null && museumsDataGridView.CurrentRow.DataBoundItem is MuseumDisplay selectedMuseum)
            {
                var paintingsForm = new MuseumPaintingsForm(selectedMuseum.Id);
                paintingsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть музей.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportMuseumToPdf_Click(object sender, EventArgs e)
        {
            if (museumsDataGridView.CurrentRow != null && museumsDataGridView.CurrentRow.DataBoundItem is MuseumDisplay selectedMuseumDisplay)
            {
                var selectedMuseum = DataManager.Instance.Museums
                                             .FirstOrDefault(m => m.Id == selectedMuseumDisplay.Id);

                if (selectedMuseum != null)
                {
                    MuseumPdfGenerator.GenerateMuseumPdf(selectedMuseum);
                }
                else
                {
                    MessageBox.Show("Не вдалося знайти дані музею.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть музей для експорту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}