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
using Microsoft.VisualBasic;

namespace Coursework_Sytnik
{
    public partial class MyCollectionEditForm : Form
    {
        private MyCollectionPainting _currentCollectionItem;
        private bool _isNewItem;

        public class PaintingForAuctionDisplay
        {
            public int PaintingId { get; set; }
            public string PaintingTitle { get; set; }
            public decimal Price { get; set; }
            public string SourceEventName { get; set; }
            public string DisplayText => $"{PaintingTitle} (Ціна: {Price:C})";

            public override string ToString()
            {
                return $"{PaintingTitle} (Ціна: {Price:C})";
            }
        }

        public MyCollectionEditForm()
        {
            InitializeComponent();
            _isNewItem = true;
            _currentCollectionItem = new MyCollectionPainting();
            this.Text = "Додати картину в колекцію";
            InitializeForm();
        }

        public MyCollectionEditForm(int itemId)
        {
            InitializeComponent();
            _isNewItem = false;
            _currentCollectionItem = DataManager.Instance.GetMyCollectionItemById(itemId);
            this.Text = "Редагувати картину в колекції";

            if (_currentCollectionItem == null)
            {
                MessageBox.Show("Елемент колекції не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            InitializeForm();
        }

        private void InitializeForm()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            this.StartPosition = FormStartPosition.CenterScreen;

            dtpPurchaseDate.Visible = true;
            dtpPurchaseDate.Enabled = true;

            btnSave.Enabled = false;

            if (_isNewItem)
            {
                this.Text = "Додати картину в колекцію";

                lblAuctionEvent.Visible = true;
                cmbAuctionEvents.Visible = true;
                lblAvailablePaintings.Visible = true;
                cmbAvailablePaintings.Visible = true;
                lblPaintingTitle.Visible = true;
                lblPurchasePrice.Visible = true;

                lblPaintingTitle.Text = "Назва: (Оберіть картину)";
                lblPurchasePrice.Text = "Ціна покупки: (Оберіть картину)"; 

                PopulateAuctionComboBox();

                cmbAuctionEvents.SelectedIndexChanged += cmbAuctionEvents_SelectedIndexChanged;
                cmbAvailablePaintings.SelectedIndexChanged += cmbAvailablePaintings_SelectedIndexChanged;
            }
            else 
            {
                this.Text = "Редагувати картину в колекції";

                lblAuctionEvent.Visible = false;
                cmbAuctionEvents.Visible = false;
                lblAvailablePaintings.Visible = false;
                cmbAvailablePaintings.Visible = false;

                lblPaintingTitle.Visible = true;
                lblPurchasePrice.Visible = true;

                var painting = DataManager.Instance.GetPaintingById(_currentCollectionItem.PaintingId);
                lblPaintingTitle.Text = $"Назва: {painting?.Title ?? "Невідомо"}";
                lblPurchasePrice.Text = $"Ціна покупки: {_currentCollectionItem.PurchasePrice:C}";
                dtpPurchaseDate.Value = _currentCollectionItem.PurchaseDate; 

                btnSave.Enabled = true; 
            }
        }

        private void PopulateAuctionComboBox()
        {
            var availableEvents = DataManager.Instance.CollectionEvents
                                                    .Where(ce => ce.PaintingsForSale.Any())
                                                    .ToList();

            var eventsForComboBox = new List<CollectionEvent>();
            eventsForComboBox.Add(new CollectionEvent { Id = 0, Name = "-- Виберіть аукціон --" });
            eventsForComboBox.AddRange(availableEvents);

            cmbAuctionEvents.DataSource = eventsForComboBox;
            cmbAuctionEvents.DisplayMember = "Name";
            cmbAuctionEvents.ValueMember = "Id";
            cmbAuctionEvents.SelectedIndex = 0;
        }

        private void cmbAuctionEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAvailablePaintings.SelectedIndexChanged -= cmbAvailablePaintings_SelectedIndexChanged;

            cmbAvailablePaintings.DataSource = null;
            lblPaintingTitle.Visible = false; 
            lblPurchasePrice.Visible = false; 
            btnSave.Enabled = false;

            if (cmbAuctionEvents.SelectedItem is CollectionEvent selectedEvent && selectedEvent.Id != 0)
            {
                var paintingsInEvent = selectedEvent.PaintingsForSale
                   .Select(pfs => new PaintingForAuctionDisplay
                   {
                       PaintingId = pfs.PaintingId,
                       PaintingTitle = DataManager.Instance.GetPaintingById(pfs.PaintingId)?.Title ?? "Невідомо",
                       Price = pfs.Price,
                       SourceEventName = selectedEvent.Name
                   })
                   .ToList();

                cmbAvailablePaintings.DataSource = paintingsInEvent;
                cmbAvailablePaintings.DisplayMember = "DisplayText";
                cmbAvailablePaintings.ValueMember = "PaintingId";

                lblAvailablePaintings.Visible = true;
                cmbAvailablePaintings.Visible = true;
                lblPaintingTitle.Visible = true; 
                lblPurchasePrice.Visible = true;

                cmbAvailablePaintings.SelectedIndexChanged += cmbAvailablePaintings_SelectedIndexChanged;

                if (paintingsInEvent.Any())
                {
                    cmbAvailablePaintings.SelectedIndex = 0;
                }
                else
                {
                    lblPaintingTitle.Text = "Назва: (Немає картин)";
                    lblPurchasePrice.Text = "Ціна покупки: (Немає картин)";
                    btnSave.Enabled = false;
                    MessageBox.Show("На цьому аукціоні немає доступних картин для додавання.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                lblAvailablePaintings.Visible = false;
                cmbAvailablePaintings.Visible = false;
                lblPaintingTitle.Visible = false;
                lblPurchasePrice.Visible = false;
                btnSave.Enabled = false;
            }
        }

        private void cmbAvailablePaintings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAvailablePaintings.SelectedItem is PaintingForAuctionDisplay selectedPainting)
            {
                _currentCollectionItem.PaintingId = selectedPainting.PaintingId;
                _currentCollectionItem.PurchasePrice = selectedPainting.Price;
                _currentCollectionItem.PurchaseDate = DateTime.Now; 
                _currentCollectionItem.SourceEventName = selectedPainting.SourceEventName;

                lblPaintingTitle.Text = $"Назва: {selectedPainting.PaintingTitle}";
                lblPurchasePrice.Text = $"Ціна покупки: {selectedPainting.Price:C}";

                lblPaintingTitle.Visible = true;
                lblPurchasePrice.Visible = true;
                btnSave.Enabled = true;
            }
            else
            {
                lblPaintingTitle.Visible = false;
                lblPurchasePrice.Visible = false;
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isNewItem && _currentCollectionItem.PaintingId == 0)
            {
                MessageBox.Show("Будь ласка, виберіть картину для додавання в колекцію.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _currentCollectionItem.PurchaseDate = dtpPurchaseDate.Value;

            try
            {
                if (_isNewItem)
                {
                    DataManager.Instance.AddMyCollectionItem(_currentCollectionItem);
                    MessageBox.Show("Картина успішно додана в колекцію!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataManager.Instance.UpdateMyCollectionItem(_currentCollectionItem);
                    MessageBox.Show("Запис у колекції успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Помилка збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла непередбачена помилка: {ex.Message}", "Критична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MyCollectionEditForm_Load(object sender, EventArgs e)
        {
        }

        private void cmbAvailablePaintings_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void lblPurchasePrice_Click(object sender, EventArgs e)
        {
        }
    }
}