using System;
using System.Collections.Generic;
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
    public partial class CollectionEventEditForm : Form
    {
        private CollectionEvent _currentEvent;
        private bool _isNewEvent;
        private BindingSource _paintingsBindingSource;


        private List<Painting> _allAvailablePaintings;
        private List<PaintingForSaleDisplay> _selectedPaintingsForEvent;
        private List<PaintingDisplayForSelection> _availablePaintingsForSelection;

        public class PaintingDisplayForSelection
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string ArtistName { get; set; }

            public override string ToString()
            {
                return $"{Title} (Художник: {ArtistName})";
            }
        }

        public class PaintingForSaleDisplay
        {
            public int PaintingId { get; set; }
            public string PaintingTitle { get; set; }
            public decimal Price { get; set; }

            public override string ToString()
            {
                return $"{PaintingTitle} (Ціна: {Price:C})";
            }
        }

        public CollectionEventEditForm()
        {
            InitializeComponent();
            _isNewEvent = true;
            _currentEvent = new CollectionEvent();
            this.Text = "Додати нову подію";
            InitializeForm();
        }

        public CollectionEventEditForm(int eventId)
        {
            InitializeComponent();
            _isNewEvent = false;
            _currentEvent = DataManager.Instance.GetCollectionEventById(eventId);
            this.Text = "Редагувати подію";

            if (_currentEvent == null)
            {
                MessageBox.Show("Подію не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnAddPaintingToEvent.Click += btnAddPaintingToEvent_Click;
            btnRemovePaintingFromEvent.Click += btnRemovePaintingFromEvent_Click;

            rbAuction.CheckedChanged += RadioButton_CheckedChanged;
            rbCommissionShop.CheckedChanged += RadioButton_CheckedChanged;

            _allAvailablePaintings = DataManager.Instance.Paintings.ToList();

            _selectedPaintingsForEvent = new List<PaintingForSaleDisplay>();
            _availablePaintingsForSelection = new List<PaintingDisplayForSelection>();

            if (!_isNewEvent)
            {
                txtEventName.Text = _currentEvent.Name;
                if (_currentEvent.IsAuction)
                {
                    rbAuction.Checked = true;
                    if (_currentEvent.EventDate.HasValue)
                    {
                        dtpEventDate.Value = _currentEvent.EventDate.Value;
                    }
                }
                else
                {
                    rbCommissionShop.Checked = true;
                }

                foreach (var pfs in _currentEvent.PaintingsForSale)
                {
                    var painting = DataManager.Instance.GetPaintingById(pfs.PaintingId);
                    if (painting != null)
                    {
                        _selectedPaintingsForEvent.Add(new PaintingForSaleDisplay
                        {
                            PaintingId = pfs.PaintingId,
                            PaintingTitle = painting.Title,
                            Price = pfs.Price
                        });
                    }
                }
            }
            else
            {
                rbAuction.Checked = true;
                dtpEventDate.Value = DateTime.Now;
            }

            PopulateAvailablePaintings();
            RefreshListBoxes();
            RadioButton_CheckedChanged(null, EventArgs.Empty);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dtpEventDate.Enabled = rbAuction.Checked;
        }

        private void PopulateAvailablePaintings()
        {
            _availablePaintingsForSelection.Clear();

            var paintingsInOtherEvents = DataManager.Instance.CollectionEvents
                .Where(ce => ce.Id != _currentEvent.Id)
                .SelectMany(ce => ce.PaintingsForSale)
                .Select(pfs => pfs.PaintingId)
                .Distinct()
                .ToHashSet();

            foreach (var painting in _allAvailablePaintings)
            {
                if (!_selectedPaintingsForEvent.Any(pfsd => pfsd.PaintingId == painting.Id) &&
                    !paintingsInOtherEvents.Contains(painting.Id))
                {
                    var artist = DataManager.Instance.GetArtistById(painting.ArtistId ?? 0);
                    _availablePaintingsForSelection.Add(new PaintingDisplayForSelection
                    {
                        Id = painting.Id,
                        Title = painting.Title,
                        ArtistName = artist != null ? artist.FullName : "Невідомий"
                    });
                }
            }
        }


        private void RefreshListBoxes()
        {
            availablePaintingsListBox.DataSource = null;
            availablePaintingsListBox.DataSource = _availablePaintingsForSelection.OrderBy(p => p.Title).ToList();
            availablePaintingsListBox.DisplayMember = "ToString";

            paintingsInEventListBox.DataSource = null;
            paintingsInEventListBox.DataSource = _selectedPaintingsForEvent.OrderBy(p => p.PaintingTitle).ToList();
            paintingsInEventListBox.DisplayMember = "ToString";
        }

        private void btnAddPaintingToEvent_Click(object sender, EventArgs e)
        {
            if (availablePaintingsListBox.SelectedItem is PaintingDisplayForSelection selectedPaintingDisplay)
            {
                if (DataManager.Instance.CollectionEvents
                    .Where(ce => ce.Id != _currentEvent.Id)
                    .SelectMany(ce => ce.PaintingsForSale)
                    .Any(pfs => pfs.PaintingId == selectedPaintingDisplay.Id))
                {
                    MessageBox.Show("Ця картина вже виставлена на продаж в іншій активній події і не може бути додана.", "Помилка додавання", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string priceInput = Microsoft.VisualBasic.Interaction.InputBox("Введіть ціну для картини:", "Встановлення ціни", "0");
                if (decimal.TryParse(priceInput, out decimal price) && price >= 0)
                {
                    _selectedPaintingsForEvent.Add(new PaintingForSaleDisplay
                    {
                        PaintingId = selectedPaintingDisplay.Id,
                        PaintingTitle = selectedPaintingDisplay.Title,
                        Price = price
                    });
                    _availablePaintingsForSelection.Remove(selectedPaintingDisplay);
                    RefreshListBoxes();
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть коректне числове значення для ціни.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину для додавання.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemovePaintingFromEvent_Click(object sender, EventArgs e)
        {
            if (paintingsInEventListBox.SelectedItem is PaintingForSaleDisplay selectedPaintingForEvent)
            {
                _selectedPaintingsForEvent.Remove(selectedPaintingForEvent);
                var originalPainting = DataManager.Instance.GetPaintingById(selectedPaintingForEvent.PaintingId);
                if (originalPainting != null)
                {
                    bool isInOtherEvents = DataManager.Instance.CollectionEvents
                        .Where(ce => ce.Id != _currentEvent.Id)
                        .SelectMany(ce => ce.PaintingsForSale)
                        .Any(pfs => pfs.PaintingId == originalPainting.Id);

                    if (!isInOtherEvents)
                    {
                        var artist = DataManager.Instance.GetArtistById(originalPainting.ArtistId ?? 0);
                        _availablePaintingsForSelection.Add(new PaintingDisplayForSelection
                        {
                            Id = originalPainting.Id,
                            Title = originalPainting.Title,
                            ArtistName = artist != null ? artist.FullName : "Невідомий"
                        });
                    }
                }
                RefreshListBoxes();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                MessageBox.Show("Назва події не може бути пустою.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbAuction.Checked && !dtpEventDate.Enabled)
            {
                MessageBox.Show("Для аукціону необхідно вказати дату проведення.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rbAuction.Checked && dtpEventDate.Value == DateTime.MinValue)
            {
                MessageBox.Show("Для аукціону необхідно вказати коректну дату проведення.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentEvent.Name = txtEventName.Text.Trim();
            _currentEvent.IsAuction = rbAuction.Checked;
            _currentEvent.EventDate = rbAuction.Checked ? (DateTime?)dtpEventDate.Value : null;

            _currentEvent.PaintingsForSale = _selectedPaintingsForEvent
                                                 .Select(pfsd => new PaintingForSale { PaintingId = pfsd.PaintingId, Price = pfsd.Price })
                                                 .ToList();



            try
            {
                if (_isNewEvent)
                {
                    DataManager.Instance.AddCollectionEvent(_currentEvent);
                    MessageBox.Show("Подію успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataManager.Instance.UpdateCollectionEvent(_currentEvent);
                    MessageBox.Show("Подію успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Помилка збереження події", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InitializeForm();
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

        private void CollectionEventEditForm_Load(object sender, EventArgs e)
        {
        }

        private void rbCommissionShop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CollectionEventEditForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnEditPaintingPrice_Click(object sender, EventArgs e)
        {
            if (paintingsInEventListBox.SelectedItem is PaintingForSaleDisplay selectedPaintingForEvent)
            {
                string priceInput = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Введіть нову ціну для картини '{selectedPaintingForEvent.PaintingTitle}':",
                    "Редагування ціни",
                    selectedPaintingForEvent.Price.ToString());

                if (decimal.TryParse(priceInput, out decimal newPrice) && newPrice >= 0)
                {
                    selectedPaintingForEvent.Price = newPrice;
                    RefreshListBoxes();
                    MessageBox.Show("Ціну успішно оновлено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть коректне числове значення для ціни.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть картину, ціну якої ви хочете відредагувати.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}