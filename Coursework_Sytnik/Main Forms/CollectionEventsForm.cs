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
    public partial class CollectionEventsForm : Form
    {
        public CollectionEventsForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializeDataGridView();
            RefreshCollectionEventsGrid();

            btnAddEvent.Click += btnAddEvent_Click;
            btnEditEvent.Click += btnEditEvent_Click;
            btnDeleteEvent.Click += btnDeleteEvent_Click;
            btnGoToArtists.Click += btnGoToArtists_Click;
            btnGoToPaintings.Click += btnGoToPaintings_Click;
            btnGoToMuseums.Click += btnGoToMuseums_Click;
        }

        public class CollectionEventDisplay
        {
            public int Id { get; set; }
            [DisplayName("Назва")]
            public string Name { get; set; }
            [DisplayName("Тип")]
            public string EventTypeDisplay { get; set; }
            [DisplayName("Дата")]
            public string EventDateDisplay { get; set; }
            [DisplayName("Картини (Ціни)")]
            public string PaintingsInfo { get; set; }
        }

        private void InitializeDataGridView()
        {
            collectionEventsDataGridView.AutoGenerateColumns = false;
            collectionEventsDataGridView.Columns.Clear();

            collectionEventsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Назва/Ім'я події" });
            collectionEventsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EventTypeDisplay", HeaderText = "Тип заходу" });
            collectionEventsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EventDateDisplay", HeaderText = "Дата проведення" });
            collectionEventsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaintingsInfo", HeaderText = "Шедеври на події (ціна)" });

            foreach (DataGridViewColumn column in collectionEventsDataGridView.Columns)
            {
                column.ReadOnly = true;
                if (column.DataPropertyName == "PaintingsInfo")
                {
                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }
            collectionEventsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        public void RefreshCollectionEventsGrid()
        {
            var allEvents = DataManager.Instance.CollectionEvents;

            var displayList = new List<CollectionEventDisplay>();
            foreach (var ce in allEvents)
            {
                var paintingsInfo = new StringBuilder();
                foreach (var pfs in ce.PaintingsForSale)
                {
                    var painting = DataManager.Instance.GetPaintingById(pfs.PaintingId);
                    if (painting != null)
                    {
                        paintingsInfo.AppendLine($"{painting.Title} ({pfs.Price:C})");
                    }
                }

                displayList.Add(new CollectionEventDisplay
                {
                    Id = ce.Id,
                    Name = ce.Name,
                    EventTypeDisplay = ce.EventTypeDisplay,
                    EventDateDisplay = ce.IsAuction && ce.EventDate.HasValue ? ce.EventDate.Value.ToShortDateString() : "N/A",
                    PaintingsInfo = paintingsInfo.ToString().Trim()
                });
            }

            var filteredList = displayList.AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtSearchEvent.Text))
            {
                string searchTerm = txtSearchEvent.Text.ToLower();

                filteredList = filteredList.Where(ev =>
                    ev.Name.ToLower().Contains(searchTerm) ||
                    ev.EventTypeDisplay.ToLower().Contains(searchTerm) ||
                    ev.EventDateDisplay.ToLower().Contains(searchTerm) ||
                    ev.PaintingsInfo.ToLower().Contains(searchTerm)
                );
            }

            collectionEventsDataGridView.DataSource = null;
            collectionEventsDataGridView.DataSource = filteredList.ToList();
            collectionEventsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }


        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            var editForm = new CollectionEventEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshCollectionEventsGrid();
            }
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (collectionEventsDataGridView.CurrentRow != null && collectionEventsDataGridView.CurrentRow.DataBoundItem is CollectionEventDisplay selectedEventDisplay)
            {
                var editForm = new CollectionEventEditForm(selectedEventDisplay.Id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshCollectionEventsGrid();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть подію для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (collectionEventsDataGridView.CurrentRow != null && collectionEventsDataGridView.CurrentRow.DataBoundItem is CollectionEventDisplay selectedEventDisplay)
            {
                var confirmResult = MessageBox.Show($"Ви впевнені, що хочете видалити подію '{selectedEventDisplay.Name}'?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    DataManager.Instance.DeleteCollectionEvent(selectedEventDisplay.Id);
                    RefreshCollectionEventsGrid();
                    MessageBox.Show("Подію успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть подію для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGoToArtists_Click(object sender, EventArgs e)
        {
            this.Hide();
            var artistsForm = new MainForm();
            artistsForm.ShowDialog();
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
            this.Hide();
            var museumsForm = new MuseumForm();
            museumsForm.ShowDialog();
            this.Show();
        }

        private void CollectionEventsForm_Load(object sender, EventArgs e)
        {
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

        private void btnApplyFilterEvent_Click(object sender, EventArgs e)
        {
            RefreshCollectionEventsGrid();
        }

        private void btnClearFilterEvent_Click(object sender, EventArgs e)
        {
            txtSearchEvent.Text = string.Empty;
            RefreshCollectionEventsGrid();
        }

        private void btnExportEventToPdf_Click(object sender, EventArgs e)
        {
            if (collectionEventsDataGridView.CurrentRow != null && collectionEventsDataGridView.CurrentRow.DataBoundItem is CollectionEventDisplay selectedEventDisplay)
            {
                var selectedEvent = DataManager.Instance.CollectionEvents
                                             .FirstOrDefault(ce => ce.Id == selectedEventDisplay.Id);

                if (selectedEvent != null)
                {
                    CollectionEventPdfGenerator.GenerateCollectionEventPdf(selectedEvent);
                }
                else
                {
                    MessageBox.Show("Не вдалося знайти дані події.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть подію для експорту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}