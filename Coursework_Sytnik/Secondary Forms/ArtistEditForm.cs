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
    public partial class ArtistEditForm : Form
    {
        private Artist _currentArtist;

        public ArtistEditForm()
        {
            InitializeComponent();
            InitializeEventHandlers();
            _currentArtist = new Artist();
            this.Text = "Додати нового художника";
            newStyleTextBox.Text = string.Empty;
        }

        public ArtistEditForm(int artistId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            this.Text = "Редагувати художника";

            _currentArtist = DataManager.Instance.GetArtistById(artistId);

            if (_currentArtist != null)
            {
                firstNameTextBox.Text = _currentArtist.FirstName;
                lastNameTextBox.Text = _currentArtist.LastName;
                yearsOfLifeTextBox.Text = _currentArtist.YearsOfLife;
                countryTextBox.Text = _currentArtist.Country;
                biographyTextBox.Text = _currentArtist.Biography;

                newStyleTextBox.Text = string.Join(", ", _currentArtist.Styles);
            }
            else
            {
                MessageBox.Show("Художника не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void InitializeEventHandlers()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) || string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                MessageBox.Show("Ім'я та прізвище художника не можуть бути пустими.", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentArtist.FirstName = firstNameTextBox.Text;
            _currentArtist.LastName = lastNameTextBox.Text;
            _currentArtist.YearsOfLife = yearsOfLifeTextBox.Text;
            _currentArtist.Country = countryTextBox.Text;
            _currentArtist.Biography = biographyTextBox.Text;

            _currentArtist.Styles = newStyleTextBox.Text
                                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(s => s.Trim())
                                        .Where(s => !string.IsNullOrEmpty(s))
                                        .ToList();

            if (_currentArtist.Id == 0)
            {
                DataManager.Instance.AddArtist(_currentArtist);
            }
            else
            {
                DataManager.Instance.UpdateArtist(_currentArtist);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ArtistEditForm_Load(object sender, EventArgs e)
        {
        }

    }
}