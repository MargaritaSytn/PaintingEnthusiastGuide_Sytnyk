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
    public partial class MyCollectionForm : Form
    {
        public MyCollectionForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.Load += MyCollectionForm_Load;
            this.btnAdd.Click += btnAdd_Click;
            this.btnDelete.Click += btnDelete_Click;
            InitializeMyCollectionDataGridView();
        }
        private void InitializeMyCollectionDataGridView()
        {
            dataGridViewMyCollection.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewMyCollection.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewMyCollection.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void MyCollectionForm_Load(object sender, EventArgs e)
        {
            RefreshMyCollectionGrid();
        }

        public void RefreshMyCollectionGrid()
        {
            var allItems = DataManager.Instance.MyCollection;

            var myCollectionData = allItems
                .Select(mci => new
                {
                    mci.Id,
                    PaintingTitle = DataManager.Instance.GetPaintingById(mci.PaintingId)?.Title ?? "Невідомо",
                    ArtistName = DataManager.Instance.GetArtistById(DataManager.Instance.GetPaintingById(mci.PaintingId)?.ArtistId ?? 0)?.FullName ?? "Невідомо",
                    mci.PurchasePrice,
                    mci.PurchaseDate,
                    mci.SourceEventName
                })
                .ToList();

            if (!string.IsNullOrWhiteSpace(txtSearchMyCollection.Text))
            {
                string searchTerm = txtSearchMyCollection.Text.ToLower();

                myCollectionData = myCollectionData
                    .Where(item =>
                        item.PaintingTitle.ToLower().Contains(searchTerm) ||
                        item.ArtistName.ToLower().Contains(searchTerm) ||
                        item.PurchaseDate.ToShortDateString().ToLower().Contains(searchTerm) ||
                        item.SourceEventName.ToLower().Contains(searchTerm))
                    .ToList();
            }

            dataGridViewMyCollection.DataSource = null;
            dataGridViewMyCollection.DataSource = myCollectionData;

            if (dataGridViewMyCollection.Columns.Contains("Id"))
                dataGridViewMyCollection.Columns["Id"].Visible = false;

            if (dataGridViewMyCollection.Columns.Contains("PaintingTitle"))
            {
                dataGridViewMyCollection.Columns["PaintingTitle"].HeaderText = "Назва картини";
                dataGridViewMyCollection.Columns["PaintingTitle"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }

            if (dataGridViewMyCollection.Columns.Contains("ArtistName"))
            {
                dataGridViewMyCollection.Columns["ArtistName"].HeaderText = "Художник";
                dataGridViewMyCollection.Columns["ArtistName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            if (dataGridViewMyCollection.Columns.Contains("PurchasePrice"))
            {
                dataGridViewMyCollection.Columns["PurchasePrice"].HeaderText = "Ціна покупки";
                dataGridViewMyCollection.Columns["PurchasePrice"].DefaultCellStyle.Format = "C";
            }

            if (dataGridViewMyCollection.Columns.Contains("PurchaseDate"))
            {
                dataGridViewMyCollection.Columns["PurchaseDate"].HeaderText = "Дата покупки";
                dataGridViewMyCollection.Columns["PurchaseDate"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            if (dataGridViewMyCollection.Columns.Contains("SourceEventName"))
            {
                dataGridViewMyCollection.Columns["SourceEventName"].HeaderText = "Джерело (Аукціон/Подія)";
                dataGridViewMyCollection.Columns["SourceEventName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dataGridViewMyCollection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new MyCollectionEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshMyCollectionGrid();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyCollection.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що хочете видалити цю картину з колекції?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int itemId = (int)dataGridViewMyCollection.SelectedRows[0].Cells["Id"].Value;
                    DataManager.Instance.DeleteMyCollectionItem(itemId);
                    RefreshMyCollectionGrid();
                    MessageBox.Show("Картину успішно видалено з колекції.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MyCollectionForm_Load_1(object sender, EventArgs e)
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
            this.Hide();
            var museumsForm = new MuseumForm();
            museumsForm.ShowDialog();
            this.Show();
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
            this.Show();
            this.Activate();
        }

        private void btnApplyFilterMyCollection_Click(object sender, EventArgs e)
        {
            RefreshMyCollectionGrid();
        }

        private void btnClearFilterMyCollection_Click(object sender, EventArgs e)
        {
            txtSearchMyCollection.Text = string.Empty;
            RefreshMyCollectionGrid();
        }

        private void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyCollection.SelectedRows.Count > 0)
            {
                int itemId = (int)dataGridViewMyCollection.SelectedRows[0].Cells["Id"].Value;

                var selectedCollectionItem = DataManager.Instance.MyCollection
                                                             .FirstOrDefault(mci => mci.Id == itemId);

                if (selectedCollectionItem != null)
                {
                    MyCollectionReceiptGenerator.GenerateReceiptPdf(selectedCollectionItem);
                }
                else
                {
                    MessageBox.Show("Не вдалося знайти дані вибраної картини в колекції.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину у своїй колекції для створення чека.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewMyCollection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}