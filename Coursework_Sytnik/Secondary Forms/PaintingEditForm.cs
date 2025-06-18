using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Coursework_Sytnik.Classes;

namespace Coursework_Sytnik
{
    public partial class PaintingEditForm : Form
    {
        private Painting _currentPainting;
        private bool _isNewPainting;

        public PaintingEditForm()
        {
            InitializeComponent();
            _isNewPainting = true;
            _currentPainting = new Painting();
            this.Text = "Додати нову картину";
            InitializeData();
        }

        public PaintingEditForm(int paintingId)
        {
            InitializeComponent();
            _isNewPainting = false;
            _currentPainting = DataManager.Instance.GetPaintingById(paintingId);
            this.Text = "Редагувати картину";

            if (_currentPainting == null)
            {
                MessageBox.Show("Картину не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            InitializeData();
        }

        private void InitializeData()
        {
            cmbArtists.DataSource = DataManager.Instance.Artists.ToList();
            cmbArtists.DisplayMember = "FullName";
            cmbArtists.ValueMember = "Id";

            if (!_isNewPainting)
            {
                txtTitle.Text = _currentPainting.Title;
                numericUpDownYear.Value = _currentPainting.CreationYear;
                txtGenre.Text = _currentPainting.Genre;

                if (_currentPainting.ArtistId.HasValue)
                {
                    cmbArtists.SelectedValue = _currentPainting.ArtistId.Value;
                }
                else
                {
                    cmbArtists.SelectedIndex = -1;
                }
            }
            else
            {
                _currentPainting.MuseumId = null;
                numericUpDownYear.Value = DateTime.Now.Year;
            }

            numericUpDownYear.Maximum = DateTime.Now.Year;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Назва картини не може бути порожньою.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbArtists.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть художника.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numericUpDownYear.Value > DateTime.Now.Year)
            {
                MessageBox.Show($"Рік створення картини не може бути пізніше за {DateTime.Now.Year} рік.", "Некоректний рік", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Будь ласка, введіть жанр або стиль картини.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _currentPainting.Title = txtTitle.Text;
            _currentPainting.CreationYear = (int)numericUpDownYear.Value;
            _currentPainting.Genre = txtGenre.Text;
            _currentPainting.ArtistId = (int)cmbArtists.SelectedValue;


            if (_isNewPainting)
            {
                DataManager.Instance.AddPainting(_currentPainting);
            }
            else
            {
                DataManager.Instance.UpdatePainting(_currentPainting);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PaintingEditForm_Load(object sender, EventArgs e)
        {
        }
    }
}