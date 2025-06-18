using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coursework_Sytnik.Classes;

namespace Coursework_Sytnik
{
    public partial class MuseumEditForm : Form
    {
        private Museum _currentMuseum;
        private List<Painting> _allPaintings;
        private List<Painting> _selectedPaintingsInForm;
        private List<Painting> _availablePaintingsInForm;

        public MuseumEditForm()
        {
            InitializeComponent();
            _currentMuseum = new Museum();
            this.Text = "Додати новий музей";
            LoadAllPaintings();
            InitializePaintingListBoxes();
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnAddSelectedPainting.Click += btnAddSelectedPainting_Click;
            btnRemoveSelectedPainting.Click += btnRemoveSelectedPainting_Click;
        }

        public MuseumEditForm(int museumId)
        {
            InitializeComponent();
            this.Text = "Редагувати музей";

            _currentMuseum = DataManager.Instance.GetMuseumById(museumId);

            if (_currentMuseum != null)
            {
                txtName.Text = _currentMuseum.Name;
                txtAddress.Text = _currentMuseum.Address;
                txtCity.Text = _currentMuseum.City;
                txtCountry.Text = _currentMuseum.Country;
                txtCoordinateX.Text = _currentMuseum.CoordinateX.ToString(CultureInfo.InvariantCulture);
                txtCoordinateY.Text = _currentMuseum.CoordinateY.ToString(CultureInfo.InvariantCulture);

                LoadAllPaintings();
                InitializePaintingListBoxes();
                btnSave.Click += btnSave_Click;
                btnCancel.Click += btnCancel_Click;
                btnAddSelectedPainting.Click += btnAddSelectedPainting_Click;
                btnRemoveSelectedPainting.Click += btnRemoveSelectedPainting_Click;
            }
            else
            {
                MessageBox.Show("Музей не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void LoadAllPaintings()
        {
            _allPaintings = DataManager.Instance.Paintings.ToList();
        }

        private void InitializePaintingListBoxes()
        {
            var currentMuseumPaintingIds = _currentMuseum?.PaintingIds ?? new List<int>();

            _selectedPaintingsInForm = _allPaintings
                .Where(p => _currentMuseum.PaintingIds.Contains(p.Id))
                .ToList();

            _availablePaintingsInForm = _allPaintings
                .Where(p => !p.MuseumId.HasValue || p.MuseumId == 0 || p.MuseumId == _currentMuseum.Id)
                .Where(p => !_selectedPaintingsInForm.Any(sp => sp.Id == p.Id))
                .ToList();

            RefreshPaintingListBoxes();
        }

        private void RefreshPaintingListBoxes()
        {
            selectedPaintingsListBox.DataSource = null;
            selectedPaintingsListBox.DataSource = _selectedPaintingsInForm;
            selectedPaintingsListBox.DisplayMember = "Title";

            availablePaintingsListBox.DataSource = null;
            availablePaintingsListBox.DataSource = _availablePaintingsInForm;
            availablePaintingsListBox.DisplayMember = "Title";
        }

        private void btnAddSelectedPainting_Click(object sender, EventArgs e)
        {
            if (availablePaintingsListBox.SelectedItem is Painting selectedPainting)
            {
                _availablePaintingsInForm.Remove(selectedPainting);
                _selectedPaintingsInForm.Add(selectedPainting);
                RefreshPaintingListBoxes();
            }
        }

        private void btnRemoveSelectedPainting_Click(object sender, EventArgs e)
        {
            if (selectedPaintingsListBox.SelectedItem is Painting selectedPainting)
            {
                _selectedPaintingsInForm.Remove(selectedPainting);
                _availablePaintingsInForm.Add(selectedPainting);
                RefreshPaintingListBoxes();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Назва музею не може бути порожньою.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double x, y;

            if (!double.TryParse(txtCoordinateX.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out x) &&
                !double.TryParse(txtCoordinateX.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out x))
            {
                MessageBox.Show("Будь ласка, введіть дійсне число для координати X.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtCoordinateY.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out y) &&
                !double.TryParse(txtCoordinateY.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out y))
            {
                MessageBox.Show("Будь ласка, введіть дійсне число для координати Y.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentMuseum.Name = txtName.Text;
            _currentMuseum.Address = txtAddress.Text;
            _currentMuseum.City = txtCity.Text;
            _currentMuseum.Country = txtCountry.Text;
            _currentMuseum.CoordinateX = x; 
            _currentMuseum.CoordinateY = y;

            List<int> oldPaintingIdsForMuseum = new List<int>();
            if (_currentMuseum.Id != 0)
            {
                var existingMuseumInManager = DataManager.Instance.GetMuseumById(_currentMuseum.Id);
                if (existingMuseumInManager != null)
                {
                    oldPaintingIdsForMuseum = existingMuseumInManager.PaintingIds.ToList();
                }
            }

            _currentMuseum.PaintingIds = _selectedPaintingsInForm.Select(p => p.Id).ToList();

            if (_currentMuseum.Id == 0)
            {
                DataManager.Instance.AddMuseum(_currentMuseum);
            }
            else
            {
                DataManager.Instance.UpdateMuseum(_currentMuseum);
            }

            var removedPaintingIds = oldPaintingIdsForMuseum.Except(_currentMuseum.PaintingIds).ToList();
            foreach (var removedId in removedPaintingIds)
            {
                var painting = DataManager.Instance.GetPaintingById(removedId);
                if (painting != null && painting.MuseumId == _currentMuseum.Id)
                {
                    painting.MuseumId = null;
                    DataManager.Instance.UpdatePainting(painting);
                }
            }

            var addedPaintingIds = _currentMuseum.PaintingIds.Except(oldPaintingIdsForMuseum).ToList();
            foreach (var addedId in addedPaintingIds)
            {
                var painting = DataManager.Instance.GetPaintingById(addedId);
                if (painting != null)
                {
                    painting.MuseumId = _currentMuseum.Id;
                    DataManager.Instance.UpdatePainting(painting);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MuseumEditForm_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}